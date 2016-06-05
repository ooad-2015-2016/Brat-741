﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Communication;
using Microsoft.Maker.Serial;
using Microsoft.Maker.RemoteWiring;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using System.Threading;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjekatSpijunskaAgencija.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConnectionPage : Page
    {
        DispatcherTimer timeout;
        DateTime connectionAttemptStartedTime;
        DateTime timePageNavigatedTo;
        CancellationTokenSource cancelTokenSource;

        //string identifiers used to recognize drop-down selections
        private const string BLUETOOTH = "Bluetooth";
        private const string USB = "USB";
        private const string NETWORK = "Network";

        public ConnectionPage()
        {
            this.InitializeComponent();
            ConnectionMethodComboBox.SelectionChanged += ConnectionComboBox_SelectionChanged;
          //  App.Telemetry.TrackEvent("RemoteBlinky_Windows10_Launched");
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            //telemetry
            //App.Telemetry.TrackPageView("Connection_Page");
            timePageNavigatedTo = DateTime.UtcNow;

            if (ConnectionList.ItemsSource == null)
            {
                ConnectMessage.Text = "Select an item to connect to.";
                RefreshDeviceList();
            }
        }

        private void RefreshDeviceList()
        {
            //invoke the listAvailableDevicesAsync method of the correct Serial class. Since it is Async, we will wrap it in a Task and add a llambda to execute when finished
            Task<DeviceInformationCollection> task = null;
            if (ConnectionMethodComboBox.SelectedItem == null)
            {
                ConnectMessage.Text = "Select a connection method to continue.";
                return;
            }

            switch (ConnectionMethodComboBox.SelectedItem as String)
            {
                default:
                case BLUETOOTH:
                    ConnectionList.Visibility = Visibility.Visible;
                    NetworkConnectionGrid.Visibility = Visibility.Collapsed;
                    BaudRateStack.Visibility = Visibility.Visible;

                    //create a cancellation token which can be used to cancel a task
                    cancelTokenSource = new CancellationTokenSource();
                    cancelTokenSource.Token.Register(() => OnConnectionCancelled());

                    task = BluetoothSerial.listAvailableDevicesAsync().AsTask<DeviceInformationCollection>(cancelTokenSource.Token);
                    break;

                case USB:
                    ConnectionList.Visibility = Visibility.Visible;
                    NetworkConnectionGrid.Visibility = Visibility.Collapsed;
                    BaudRateStack.Visibility = Visibility.Visible;

                    //create a cancellation token which can be used to cancel a task
                    cancelTokenSource = new CancellationTokenSource();
                    cancelTokenSource.Token.Register(() => OnConnectionCancelled());

                    task = UsbSerial.listAvailableDevicesAsync().AsTask<DeviceInformationCollection>(cancelTokenSource.Token);
                    break;

                case NETWORK:
                    ConnectionList.Visibility = Visibility.Collapsed;
                    NetworkConnectionGrid.Visibility = Visibility.Visible;
                    BaudRateStack.Visibility = Visibility.Collapsed;

                    ConnectMessage.Text = "Enter a host and port to connect";
                    task = null;
                    break;
            }


            //the task, if created, is enumerating the devices available from the selected connection method. We will display the results to the UI so that they can be selected.
            if (task != null)
            {
                //store the returned DeviceInformation items when the task completes
                task.ContinueWith(listTask =>
                {
                    //store the result and populate the device list on the UI thread
                    var action = Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, new Windows.UI.Core.DispatchedHandler(() =>
                    {
                        Connections connections = new Connections();

                        var result = listTask.Result;
                        if (result == null || result.Count == 0)
                        {
                            ConnectMessage.Text = "No items found.";
                        }
                        else
                        {
                            foreach (DeviceInformation device in result)
                            {
                                connections.Add(new Connection(device.Name, device));
                            }
                            ConnectMessage.Text = "Select an item and press \"Connect\" to connect.";
                        }

                        ConnectionList.ItemsSource = connections;
                    }));
                });
            }
        }

        /****************************************************************
         *                       UI Callbacks                           *
         ****************************************************************/

        /// <summary>
        /// This function is called if the selection is changed on the Connection combo box
        /// </summary>
        /// <param name="sender">The object invoking the event</param>
        /// <param name="e">Arguments relating to the event</param>
        private void ConnectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshDeviceList();
        }

        /// <summary>
        /// Called if the Refresh button is pressed
        /// </summary>
        /// <param name="sender">The object invoking the event</param>
        /// <param name="e">Arguments relating to the event</param>
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshDeviceList();
        }

        /// <summary>
        /// Called if the Cancel button is pressed
        /// </summary>
        /// <param name="sender">The object invoking the event</param>
        /// <param name="e">Arguments relating to the event</param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            OnConnectionCancelled();
        }

        /// <summary>
        /// Called if the Connect button is pressed
        /// </summary>
        /// <param name="sender">The object invoking the event</param>
        /// <param name="e">Arguments relating to the event</param>
        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            //disable the buttons and set a timer in case the connection times out
            SetUiEnabled(false);

            DeviceInformation device = null;
            if (ConnectionList.SelectedItem != null)
            {
                var selectedConnection = ConnectionList.SelectedItem as Connection;
                device = selectedConnection.Source as DeviceInformation;
            }
            else if ((ConnectionMethodComboBox.SelectedItem as string) != NETWORK)
            {
                //if they haven't selected an item, but have chosen "usb" or "bluetooth", we can't proceed
                ConnectMessage.Text = "You must select an item to proceed.";
                SetUiEnabled(true);
                return;
            }

            //determine the selected baud rate
            uint baudRate = Convert.ToUInt32((BaudRateComboBox.SelectedItem as string));

            //connection properties dictionary, used only for telemetry data
            var properties = new Dictionary<string, string>();

            //use the selected device to create our communication object
            switch (ConnectionMethodComboBox.SelectedItem as string)
            {
                default:
                case BLUETOOTH:

                    //send telemetry about this connection attempt
                    properties.Add("Device_Name", device.Name);
                    properties.Add("Device_ID", device.Id);
                    properties.Add("Device_Kind", device.Kind.ToString());
                  //  App.Telemetry.TrackEvent("Bluetooth_Connection_Attempt", properties);
                    App.Connection = new BluetoothSerial(device);
                    break;

                case USB:

                    //send telemetry about this connection attempt
                    properties.Add("Device_Name", device.Name);
                    properties.Add("Device_ID", device.Id);
                    properties.Add("Device_Kind", device.Kind.ToString());
                    //App.Telemetry.TrackEvent("USB_Connection_Attempt", properties);

                    App.Connection = new UsbSerial(device);
                    break;

                case NETWORK:
                    string host = NetworkHostNameTextBox.Text;
                    string port = NetworkPortTextBox.Text;
                    ushort portnum = 0;

                    if (host == null || port == null)
                    {
                        ConnectMessage.Text = "You must enter host and IP.";
                        return;
                    }

                    try
                    {
                        portnum = Convert.ToUInt16(port);
                    }
                    catch (FormatException)
                    {
                        ConnectMessage.Text = "You have entered an invalid port number.";
                        return;
                    }

                    //send telemetry about this connection attempt
                    properties.Add("host", host);
                    properties.Add("port", portnum.ToString());
                    //App.Telemetry.TrackEvent("Network_Connection_Attempt", properties);

                    App.Connection = new NetworkSerial(new Windows.Networking.HostName(host), portnum);
                    break;
            }

            App.Arduino = new RemoteDevice(App.Connection);
            App.Arduino.DeviceReady += OnDeviceReady;
            App.Arduino.DeviceConnectionFailed += OnDeviceConnectionFailed;
            
            connectionAttemptStartedTime = DateTime.UtcNow;
            App.Connection.begin(baudRate, SerialConfig.SERIAL_8N1);

            //start a timer for connection timeout
            timeout = new DispatcherTimer();
            timeout.Interval = new TimeSpan(0, 0, 30);
            timeout.Tick += Connection_TimeOut;
            timeout.Start();
        }


        /****************************************************************
         *                  Event callbacks                             *
         ****************************************************************/

        private void OnDeviceConnectionFailed(string message)
        {
            var action = Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, new Windows.UI.Core.DispatchedHandler(() =>
            {
                timeout.Stop();

                //telemetry
                //App.Telemetry.TrackRequest("Connection_Failed_Event", DateTimeOffset.UtcNow, DateTime.UtcNow - connectionAttemptStartedTime, message, true);

                ConnectMessage.Text = "Connection attempt failed: " + message;
                SetUiEnabled(true);
            }));
        }

        private void OnDeviceReady()
        {
            var action = Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, new Windows.UI.Core.DispatchedHandler(() =>
            {
                timeout.Stop();

                //telemetry
                //App.Telemetry.TrackRequest("Connection_Success_Event", DateTimeOffset.UtcNow, DateTime.UtcNow - connectionAttemptStartedTime, string.Empty, true);
                //App.Telemetry.TrackMetric("Connection_Page_Time_Spent_In_Seconds", (DateTime.UtcNow - timePageNavigatedTo).TotalSeconds);

                //this.Frame.Navigate(typeof(MainPage));

                //OVDJE DODATI ONAJ ENUM DA PALI LEDICE KOJE TREBA!!!!


                //App.Arduino.digitalWrite(3, PinState.HIGH);
                //App.Arduino.digitalWrite(4, PinState.HIGH);
                //App.Arduino.digitalWrite(5, PinState.LOW);
                if (this.Frame != null && this.Frame.CanGoBack) this.Frame.GoBack();
            }));
        }

        private void Connection_TimeOut(object sender, object e)
        {
            var action = Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, new Windows.UI.Core.DispatchedHandler(() =>
            {
                timeout.Stop();

                //telemetry
                //App.Telemetry.TrackRequest("Connection_Timeout_Event", DateTimeOffset.UtcNow, DateTime.UtcNow - connectionAttemptStartedTime, string.Empty, true);

                ConnectMessage.Text = "Connection attempt timed out.";
                SetUiEnabled(true);
            }));
        }


        /****************************************************************
         *                  Helper functions                            *
         ****************************************************************/

        private void SetUiEnabled(bool enabled)
        {
            RefreshButton.IsEnabled = enabled;
            ConnectButton.IsEnabled = enabled;
            CancelButton.IsEnabled = !enabled;
        }

        /// <summary>
        /// This function is invoked if a cancellation is invoked for any reason on the connection task
        /// </summary>
        private void OnConnectionCancelled()
        {
            ConnectMessage.Text = "Connection attempt cancelled.";
            //App.Telemetry.TrackRequest("Connection_Cancelled_Event", DateTimeOffset.UtcNow, DateTime.UtcNow - connectionAttemptStartedTime, string.Empty, true);

            if (App.Connection != null)
            {
                App.Connection.ConnectionEstablished -= OnDeviceReady;
                App.Connection.ConnectionFailed -= OnDeviceConnectionFailed;
            }

            if (cancelTokenSource != null)
            {
                cancelTokenSource.Dispose();
            }

            App.Connection = null;
            App.Arduino = null;
            cancelTokenSource = null;

            SetUiEnabled(true);
        }
    }
}

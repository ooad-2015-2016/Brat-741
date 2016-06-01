using Microsoft.Maker.RemoteWiring;
using Microsoft.Maker.Serial;
using System;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjekatSpijunskaAgencija.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ArduinoView : Page
    {
        IStream connection;
        RemoteDevice arduino;
        public ArduinoView()
        {
            this.InitializeComponent();
            connection = new UsbSerial("VID_2341","PID_0043");
            arduino = new RemoteDevice(connection);

            connection.ConnectionEstablished += OnConnectionEstablished;

            connection.begin(9600, SerialConfig.SERIAL_8N1);
        }

        private void OnConnectionEstablished()
        {
            //enable the buttons on the UI thread!
            var action = Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, new Windows.UI.Core.DispatchedHandler(() => {
                OnButton.IsEnabled = true;
                OffButton.IsEnabled = true;
            }));
        }

        private void OnButton_Click(object sender, RoutedEventArgs e)
        {
            //turn the LED connected to pin 5 ON
            arduino.digitalWrite(5, PinState.HIGH);
        }

        private void OffButton_Click(object sender, RoutedEventArgs e)
        {
            //turn the LED connected to pin 5 OFF
            arduino.digitalWrite(5, PinState.LOW);
        }

    }
}

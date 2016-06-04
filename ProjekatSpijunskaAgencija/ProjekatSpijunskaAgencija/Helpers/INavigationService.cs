using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KompShopMVVM.KompShop.Helper
{
    public interface INavigationService
    {
        void Navigate(Type sourcePage);
        void Navigate(Type sourcePage, object parameter);
        void GoBack();
        bool CanGoBack();
        void SetCanGoBack(bool set);
    }
}

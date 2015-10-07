using System;
using Xamarin.Forms;
using Silkweb.Mobile.MountainForecast.Views;

namespace Silkweb.Mobile.MountainForecast
{
    public class App
    {
        public static Page GetMainPage()
        {    
            return new NavigationPage(new MainPage());
        }
    }
}


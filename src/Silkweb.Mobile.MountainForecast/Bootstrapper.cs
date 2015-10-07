using System;
using Autofac;
using Silkweb.Mobile.MountainForecast.Views;
using Xamarin.Forms;

namespace Silkweb.Mobile.MountainForecast
{
    public class Bootstrapper
    {
        public static void Run()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<MountainForecastModule>();
            var container = builder.Build();

            var page = container.Resolve<MountainAreasView>();
            MountainForecastApp.Current.MainPage = new NavigationPage(page);
        }
    }
}


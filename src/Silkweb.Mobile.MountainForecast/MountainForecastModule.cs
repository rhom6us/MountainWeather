using Autofac;
using Silkweb.Mobile.MountainForecast.Services;
using Silkweb.Mobile.MountainForecast.ViewModels;
using Silkweb.Mobile.MountainForecast.Views;
using Xamarin.Forms;
using Silkweb.Mobile.Core.Factories;
using Silkweb.Mobile.Core;

namespace Silkweb.Mobile.MountainForecast
{
    public class MountainForecastModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // service registration
            builder.RegisterType<MountainWeatherService>()
                .As<IMountainWeatherService>()
                .SingleInstance();

            // view model registration
            builder.RegisterType<MountainAreaViewModel>();

            builder.RegisterType<MountainAreasViewModel>()
                .SingleInstance();

            builder.RegisterType<ForecastReportViewModel>()
                .SingleInstance();

            // view registration
            builder.RegisterType<MountainAreasView>()
                .SingleInstance();

            builder.RegisterType<ForecastReportView>()
                .SingleInstance();           
        }
    }
}


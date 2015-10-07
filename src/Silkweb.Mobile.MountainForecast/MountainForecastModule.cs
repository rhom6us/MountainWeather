using System;
using Autofac;
using Silkweb.Mobile.MountainForecast.Services;
using Silkweb.Mobile.MountainForecast.ViewModels;
using Silkweb.Mobile.MountainForecast.Views;

namespace Silkweb.Mobile.MountainForecast
{
    public class MountainForecastModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MountainWeatherService>()
                .As<IMountainWeatherService>()
                .SingleInstance();

            builder.RegisterType<MountainAreaViewModel>()
                .AsSelf();

            builder.RegisterType<MountainAreasViewModel>()
                .AsSelf()
                .SingleInstance();

            builder.RegisterType<MountainAreasView>()
                .AsSelf()
                .SingleInstance();
        }
    }
}


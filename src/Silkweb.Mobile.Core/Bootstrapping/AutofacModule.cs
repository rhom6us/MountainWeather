using System;
using Autofac;
using Silkweb.Mobile.Core.Factories;
using Silkweb.Mobile.Core.Services;
using Xamarin.Forms;

namespace Silkweb.Mobile.Core.Bootstrapping
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // service registration
            builder.RegisterType<ViewFactory>()
                .As<IViewFactory>()
                .SingleInstance();

            builder.RegisterType<Navigator>()
                .As<INavigator>()
                .SingleInstance();

            builder.RegisterType<DialogService>()
                .As<IDialogService>()
                .SingleInstance();

            // navigation registration
            builder.Register<INavigation>(context => 
                App.Current.MainPage.Navigation
            ).SingleInstance();
        }
    }
}


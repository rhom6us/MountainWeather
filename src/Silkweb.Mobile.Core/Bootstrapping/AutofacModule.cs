using System;
using Autofac;
using Silkweb.Mobile.Core.Factories;
using Silkweb.Mobile.Core.Services;
using Xamarin.Forms;
using Silkweb.Mobile.Core.Interfaces;
using Silkweb.Mobile.Core.Views;

namespace Silkweb.Mobile.Core.Bootstrapping
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // service registration
            builder.RegisterType<DialogService>()
                .As<IDialogService>()
                .SingleInstance();

            builder.RegisterType<ViewFactory>()
                .As<IViewFactory>()
                .SingleInstance();

            builder.RegisterType<Navigator>()
                .As<INavigator>()
                .SingleInstance();

            builder.RegisterType<DialogService>()
                .As<IDialogService>()
                .SingleInstance();

            // current page resolver
            builder.RegisterInstance<Func<IPage>>(() =>
                {
                    if (App.Current == null || App.Current.MainPage == null)
                        return null;

                    // Check if we are using MasterDetailPage
                    var masterDetailPage = App.Current.MainPage as MasterDetailPage;

                    var page = masterDetailPage != null 
                        ? masterDetailPage.Detail 
                        : App.Current.MainPage;

                    // Check if page is a NavigationPage
                    var navigationPage = page as IPageContainer<Page>;

                    return navigationPage != null 
                        ? new PageProxy(navigationPage.CurrentPage)
                            : new PageProxy(page);
                });
        }
    }
}


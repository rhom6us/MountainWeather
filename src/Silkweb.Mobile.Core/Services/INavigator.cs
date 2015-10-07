using System;
using System.Threading.Tasks;
using Silkweb.Mobile.Core.ViewModels;

namespace Silkweb.Mobile.Core.Services
{
    /// <summary>
    /// This is an MVVM friendly version of INavigation that navigates with IViewModel rather than Page.
    ///  
    /// </summary>
    public interface INavigator
    {
        Task<IViewModel> PopAsync();

        Task<IViewModel> PopModalAsync();

        Task PopToRootAsync();

        Task<TViewModel> PushAsync<TViewModel>(Action<TViewModel> setStateAction = null) 
            where TViewModel : class, IViewModel;

        Task<TViewModel> PushAsync<TViewModel>(TViewModel viewModel) 
            where TViewModel : class, IViewModel;

        Task<TViewModel> PushModalAsync<TViewModel>(Action<TViewModel> setStateAction = null) 
            where TViewModel : class, IViewModel;

        Task<TViewModel> PushModalAsync<TViewModel>(TViewModel viewModel) 
            where TViewModel : class, IViewModel;
    }

//    public interface INavigation
//    {
//        Task<Page> PopAsync();
//
//        Task<Page> PopModalAsync();
//
//        Task PopToRootAsync();
//
//        Task PushAsync(Page page);
//
//        Task PushModalAsync(Page page);
//    }
}


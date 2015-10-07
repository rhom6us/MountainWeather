using System;
using Silkweb.Mobile.Core.Services;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Silkweb.Mobile.Core.Services
{
    public class DialogService : IDialogService
    {
        private readonly NavigationPage _navigationPage;

        public DialogService(NavigationPage navigationPage)
        {
            _navigationPage = navigationPage;
        }

        #region IDialogService implementation

        public async Task DisplayAlert( string title, string message)
        {
            await _navigationPage.CurrentPage.DisplayAlert(title, message, null);
        }

        #endregion
    }
}


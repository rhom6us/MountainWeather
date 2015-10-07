using System;
using Silkweb.Mobile.Core.Services;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Silkweb.Mobile.Core.Services
{
    public class DialogService : IDialogService
    {
        private readonly IPageContainer<Page> _navigationPage;

        public DialogService(IPageContainer<Page> navigationPage)
        {
            _navigationPage = navigationPage;
        }

        #region IDialogService implementation

        public async Task DisplayAlert( string title, string message)
        {
            var page = _navigationPage.CurrentPage;
            await page.DisplayAlert(title, message, "Cancel");
        }

        #endregion
    }
}


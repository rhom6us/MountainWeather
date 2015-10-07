using System;
using Silkweb.Mobile.Core.Services;
using Xamarin.Forms;
using System.Threading.Tasks;
using Silkweb.Mobile.Core.Interfaces;

namespace Silkweb.Mobile.Core.Services
{
    public class DialogService : IDialogService
    {
        private readonly Func<IPage> _pageResolver;

        public DialogService(Func<IPage> pageResolver)
        {
            _pageResolver = pageResolver;            
        }

        public void DisplayAlert( string title, string message, string cancel)
        {
            var page = _pageResolver();

            if (page == null)
                return;

            page.DisplayAlert(title, message, cancel);
        }

        public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            var page = _pageResolver();

            if (page == null)
                return false;

            return await page.DisplayAlert(title, message, accept, cancel);
        }

        public async Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons)
        {
            var page = _pageResolver();

            if (page == null)
                return null;

            return await page.DisplayActionSheet(title, cancel, destruction, buttons);
        }
    }
}


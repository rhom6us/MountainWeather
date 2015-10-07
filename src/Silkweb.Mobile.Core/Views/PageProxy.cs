using System;
using Xamarin.Forms;
using Silkweb.Mobile.Core.Interfaces;
using System.Threading.Tasks;

namespace Silkweb.Mobile.Core.Views
{
    public class PageProxy : IPage
    {
        private readonly Page _page;

        public PageProxy(Page page)
        {
            _page = page;
        }

        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await _page.DisplayAlert(title, message, cancel);
        }

        public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            return await _page.DisplayAlert(title, message, accept, cancel);
        }

        public async Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons)
        {
            return await _page.DisplayActionSheet(title, cancel, destruction, buttons);
        }

        public INavigation Navigation
        {
            get { return _page.Navigation; }
        }
    }
}


using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Silkweb.Mobile.Core.Interfaces
{
    public interface IPage
    {
        Task DisplayAlert(string title, string message, string cancel);

        Task<bool> DisplayAlert(string title, string message, string accept, string cancel);

        Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons);

        INavigation Navigation { get; }
    }
}


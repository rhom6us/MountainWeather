using System;
using System.Threading.Tasks;

namespace Silkweb.Mobile.Core.Services
{
    public interface IDialogService
    {
        Task DisplayAlert(string title, string message);
    }
}


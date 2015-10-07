using Microsoft.Phone.Controls;
using Xamarin.Forms;
using Silkweb.Mobile.MountainForecast;

namespace Silkweb.Mobile.MountainForecast.WinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
            Content = Silkweb.Mobile.MountainForecast.App.GetMainPage().ConvertPageToUIElement(this);
        }
    }
}

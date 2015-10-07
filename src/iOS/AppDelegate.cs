using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Xamarin.Forms;

namespace Silkweb.Mobile.MountainForecast.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        UIWindow window;

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Forms.Init();

            window = new UIWindow(UIScreen.MainScreen.Bounds);	

            window.RootViewController = MountainForecastApp.Current.MainPage.CreateViewController();

            window.MakeKeyAndVisible();
			
            return true;
        }
    }
}


using Silkweb.Mobile.MountainForecast.WinPhone.Resources;

namespace Silkweb.Mobile.MountainForecast.WinPhone
{
    /// <summary>
    /// Provides access to string resources.
    /// </summary>
    public class LocalizedStrings
    {
        private static AppResources _localizedResources = new AppResources();

        public AppResources LocalizedResources { get { return _localizedResources; } }
    }
}
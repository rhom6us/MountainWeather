using System;
using UIKit;
using Silkweb.Mobile.MountainWeather.Models;

namespace Silkweb.Mobile.MountainWeather.Native.iOS
{
    public partial class DetailViewController : UIViewController
    {
        private Location _location;

        public DetailViewController(IntPtr handle)
            : base(handle)
        {
        }

        public void SetDetailItem(Location location)
        {
            if (_location == location) return;
            _location = location;
            ConfigureView();
        }

        void ConfigureView()
        {
//            if (IsViewLoaded && _location != null)
//                detailDescriptionLabel.Text = _location.ToString();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();			
            ConfigureView();
        }
    }
}


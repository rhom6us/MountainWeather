using System;
using Silkweb.Mobile.MountainWeather.Models;
using Foundation;
using UIKit;

namespace Silkweb.Mobile.MountainWeather.Native.iOS
{
    internal partial class MasterViewController : UITableViewController
    {
        private MountainAreasSource _mountainAreasSource;

        public MasterViewController(IntPtr handle)
            : base(handle)
        {
            Title = NSBundle.MainBundle.LocalizedString("Master", "Master");
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            TableView.Source = _mountainAreasSource = new MountainAreasSource(this);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "showDetail")
            {
                var indexPath = TableView.IndexPathForSelectedRow;
                var item = _mountainAreasSource.Areas[indexPath.Row];

                ((DetailViewController)segue.DestinationViewController).SetDetailItem(item);
            }
        }
    }

}


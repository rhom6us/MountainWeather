using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using Silkweb.Mobile.MountainWeather.Services;
using Silkweb.Mobile.MountainWeather.Models;
using Foundation;
using UIKit;

namespace Silkweb.Mobile.MountainWeather.Native.iOS
{
    internal class MountainAreasSource : UITableViewSource
    {
        private static readonly NSString CellIdentifier = new NSString("Cell");
        private readonly MasterViewController _controller;

        public MountainAreasSource(MasterViewController controller)
        {
            this._controller = controller;
            GetAreas();
        }

        private async void GetAreas()
        {
            var service = new MountainWeatherService();
            var areas = await service.GetAreas();
            Areas = areas.ToList();
        }

        public IList<Location> Areas { get; set; }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return Areas != null ? Areas.Count() : 0;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CellIdentifier, indexPath);

            cell.TextLabel.Text = Areas != null ? Areas[indexPath.Row].Name : "Not loaded";

            return cell;
        }

        public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
        {
            return false;
        }
    }
}

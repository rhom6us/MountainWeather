using System;
using Silkweb.Mobile.Core.ViewModels;
using Silkweb.Mobile.MountainWeather.Models;
using System.Collections.Generic;
using System.Linq;
using Silkweb.Mobile.Core.Extensions;

namespace Silkweb.Mobile.MountainWeather.ViewModels
{
    public class HazardsViewModel : ViewModelBase
    {
        public HazardsViewModel(ForecastReport forecastReport)
        {
            var hazards = forecastReport.Hazards.Where(hazard => hazard.Risk != Risk.None).ToList();
            if (hazards.Any())
            {
                Hazards = hazards;
                Risk = hazards.Max(x => x.Risk);
            }

            Title = "Hazards";

            var date = forecastReport.ForecastDay0.Date;

            Date = string.Format(date.ToString("dddd d{0} MMMM"), date.DaySuffix());

            IssuedBy = string.Format("Issued by The Met Office on {0} at {1}",
                string.Format(date.ToString("d{0} MMM"), date.DaySuffix()),
                string.Format(date.ToString("hh:ss")));

            Area = forecastReport.Location;
        }

        public string Date { get; set; }

        public string IssuedBy { get; set; }

        public string Area { get; set; }

        public IEnumerable<Hazard> Hazards { get; private set; }

        public Risk Risk { get; set; }

    }
}


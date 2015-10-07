using System;
using Silkweb.Mobile.MountainWeather.Models;
using Silkweb.Mobile.Core.ViewModels;

namespace Silkweb.Mobile.MountainWeather.ViewModels
{
    public class ForecastReportViewModel : ViewModelBase
    {
        private string _forecast;

        public string Forecast
        {
            get { return _forecast; }
            set { SetProperty(ref _forecast, value); }
        }
    }
}


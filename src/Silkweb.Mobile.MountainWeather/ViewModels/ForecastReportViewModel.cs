using System;
using Silkweb.Mobile.MountainWeather.Models;
using Silkweb.Mobile.Core.ViewModels;
using System.Collections.Generic;

namespace Silkweb.Mobile.MountainWeather.ViewModels
{
    public class ForecastReportViewModel : ViewModelBase
    {
        private ForecastReport _forecastReport;

        public ForecastReport ForecastReport
        {
            get { return _forecastReport; }
            set { SetProperty(ref _forecastReport, value); }
        }
    }
}


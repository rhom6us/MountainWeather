using System;
using Silkweb.Mobile.MountainForecast.Models;
using Silkweb.Mobile.MountainForecast.Services;
using System.Windows.Input;
using Xamarin.Forms;
using Silkweb.Mobile.Core.Services;
using Silkweb.Mobile.Core.ViewModels;

namespace Silkweb.Mobile.MountainForecast.ViewModels
{
    public class MountainAreaViewModel : ViewModelBase
    {
        private readonly IMountainWeatherService _mountainWeatherService;
        private readonly INavigator _navigator;
        private readonly Location _location;

        public MountainAreaViewModel(Location location, 
            IMountainWeatherService mountainWeatherService,
            INavigator navigator)
        {
            _location = location;
            _navigator = navigator;
            _mountainWeatherService = mountainWeatherService;
            ShowForecastCommand = new Command(ShowForecast);
        }

        public string Name { get { return _location.Name; } }

        public ICommand ShowForecastCommand { get; set; }

        private void ShowForecast()
        {
            ForecastReport forecastReport = _mountainWeatherService.GetAreaForecast(_location.Id);

            _navigator.PushAsync<ForecastReportViewModel>(viewModel =>
                {
                    viewModel.Title = _location.Name;
                    viewModel.Forecast = forecastReport.Forecast;
                });
        }
    }
}


using System;
using Silkweb.Mobile.MountainWeather.Models;
using Silkweb.Mobile.MountainWeather.Services;
using System.Windows.Input;
using Xamarin.Forms;
using Silkweb.Mobile.Core.Services;
using Silkweb.Mobile.Core.ViewModels;

namespace Silkweb.Mobile.MountainWeather.ViewModels
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

        public DateTime IssuedDate { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

        public ICommand ShowForecastCommand { get; set; }

        private async void ShowForecast()
        {
            ForecastReport forecast = await _mountainWeatherService.GetAreaForecast(_location.Id);

            await _navigator.PushAsync<ForecastReportViewModel>(vm => 
                {
                    vm.Title = _location.Name;
                    vm.ForecastReport = forecast;
                }
            );
        }
    }
}


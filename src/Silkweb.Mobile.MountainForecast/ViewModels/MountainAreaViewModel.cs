using System;
using Silkweb.Mobile.MountainForecast.Models;
using Silkweb.Mobile.MountainForecast.Services;

namespace Silkweb.Mobile.MountainForecast.ViewModels
{
    public class MountainAreaViewModel
    {
        private IMountainWeatherService _mountainWeatherService;

        public MountainAreaViewModel(Location location, 
            IMountainWeatherService mountainWeatherService)
        {
            _mountainWeatherService = mountainWeatherService;
            Name = location.Name;
        }

        public string Name { get; set; }
    }
}


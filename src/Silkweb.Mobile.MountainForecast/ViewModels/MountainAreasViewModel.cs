using System;
using Silkweb.Mobile.MountainForecast.Services;
using Silkweb.Mobile.MountainForecast.Models;
using System.Collections.Generic;
using System.Linq;

namespace Silkweb.Mobile.MountainForecast.ViewModels
{
    public class MountainAreasViewModel
    {
        private readonly IMountainWeatherService _mountainWeatherService;
        private readonly Func<Location, MountainAreaViewModel> _areaViewModelFactory;

        public MountainAreasViewModel(IMountainWeatherService mountainWeatherService, 
            Func<Location, MountainAreaViewModel> areaViewModelFactory)
        {
            _areaViewModelFactory = areaViewModelFactory;
            _mountainWeatherService = mountainWeatherService;
            Title = "Mountain Areas";
            GetAreas();
        }

        public string Title { get; set; }

        public IEnumerable<MountainAreaViewModel> Areas { get; set; }

        private void GetAreas()
        {
            var areas = _mountainWeatherService.GetAreas();
            Areas = areas.Select(location => _areaViewModelFactory(location))
                .ToList();
        }
    }
}


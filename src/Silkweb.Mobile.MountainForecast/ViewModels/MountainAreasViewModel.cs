﻿using System;
using Silkweb.Mobile.MountainForecast.Services;
using Silkweb.Mobile.MountainForecast.Models;
using System.Collections.Generic;
using System.Linq;
using Silkweb.Mobile.Core.ViewModels;

namespace Silkweb.Mobile.MountainForecast.ViewModels
{
    public class MountainAreasViewModel : ViewModelBase
    {
        private readonly IMountainWeatherService _mountainWeatherService;
        private readonly Func<Location, MountainAreaViewModel> _areaViewModelFactory;

        public MountainAreasViewModel(IMountainWeatherService mountainWeatherService, 
            Func<Location, MountainAreaViewModel> areaViewModelFactory)
        {
            _areaViewModelFactory = areaViewModelFactory;
            _mountainWeatherService = mountainWeatherService;
            Title = "Mountain Areas";
            Areas = GetAreas();
        }

        public IEnumerable<MountainAreaViewModel> Areas { get; private set;}

        private IEnumerable<MountainAreaViewModel> GetAreas()
        {
            var areas = _mountainWeatherService.GetAreas();
            return areas.Select(location => _areaViewModelFactory(location)).ToList();
        }
    }
}


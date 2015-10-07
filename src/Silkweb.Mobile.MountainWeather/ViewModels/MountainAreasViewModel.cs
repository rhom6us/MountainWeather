using System;
using Silkweb.Mobile.MountainWeather.Services;
using Silkweb.Mobile.MountainWeather.Models;
using System.Collections.Generic;
using System.Linq;
using Silkweb.Mobile.Core.ViewModels;
using System.Threading.Tasks;

namespace Silkweb.Mobile.MountainWeather.ViewModels
{
    public class MountainAreasViewModel : ViewModelBase
    {
        private IEnumerable<MountainAreaViewModel> _areas;
        private readonly IMountainWeatherService _mountainWeatherService;
        private readonly Func<Location, MountainAreaViewModel> _areaViewModelFactory;

        public MountainAreasViewModel(IMountainWeatherService mountainWeatherService, 
            Func<Location, MountainAreaViewModel> areaViewModelFactory)
        {
            _areaViewModelFactory = areaViewModelFactory;
            _mountainWeatherService = mountainWeatherService;
            Title = "Mountain Areas";
            SetAreas();
        }

        public IEnumerable<MountainAreaViewModel> Areas
        {
            get  { return _areas; }
            set  { SetProperty(ref _areas, value); }
        }

        private async void SetAreas()
        {
            var locations = await _mountainWeatherService.GetAreas();

            Areas = locations
                .Select(location =>  _areaViewModelFactory(location))
                .ToList();
        }

//        private async void SetAreas()
//        {
//            var locations = await _mountainWeatherService.GetAreas();
//            var capabilities = await _mountainWeatherService.GetCapabilities();
//
//            Areas = locations.Join(capabilities, x => x.Name, x => x.Area, (x, y) => 
//                {
//                    var vm = _areaViewModelFactory(x);
//
//                    vm.IssuedDate = y.IssuedDate;
//                    vm.ValidFrom = y.ValidFrom;
//                    vm.ValidTo = y.ValidTo;
//
//                    return vm;
//                }).ToList();
//        }
    }
}


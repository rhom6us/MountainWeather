using System;
using Silkweb.Mobile.MountainWeather.Models;
using Silkweb.Mobile.Core.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms;
using Silkweb.Mobile.MountainWeather.Services;
using Silkweb.Mobile.Core.Interfaces;
using System.Windows.Input;
using Silkweb.Mobile.Core.Services;

namespace Silkweb.Mobile.MountainWeather.ViewModels
{
    public class ForecastReportViewModel : ViewModelBase
    {
        private readonly IMountainWeatherService _mountainWeatherService;
        private readonly Location _location;
        private readonly IDialogProvider _dialogProvider;
        private ForecastReport _forecastReport;
        private Exception _error;
        private bool _isVisible;
        private HazardsViewModel _hazardsViewModel;
        private readonly INavigator _navigator;

        public ForecastReportViewModel(
            Location location,
            IDialogProvider dialogProvider,
            IMountainWeatherService mountainWeatherService,
            INavigator navigator)
        {
            _location = location;
            _dialogProvider = dialogProvider;
            _mountainWeatherService = mountainWeatherService;
            _navigator = navigator;

            Title = location.Name;
            ShowHazardsCommand = new Command(ShowHazards);
            LoadForecast();
        }

        public List<SelectableViewModel> Items { get; set; }

        public ICommand ShowHazardsCommand { get; set; }

        public override void NavigatedTo()
        {
            if (_error != null)
            {
                _isVisible = true;
                ShowError();
            }
            else if (_forecastReport == null)
                LoadForecast();
        }

        public override void NavigatedFrom()
        {
            _isVisible = false;
        }

        public async void LoadForecast()
        {
            IsBusy = true;
            _forecastReport = null;

            try
            {
                _forecastReport = await _mountainWeatherService.GetAreaForecast(_location.Id);

                if (_forecastReport == null)
                    return;

                var date = _forecastReport.ForecastDay0.Date;

                Items = new List<SelectableViewModel>
                {
                        new ForecastViewModel(_forecastReport.ForecastDay0) { IssuedDate = _forecastReport.IssueDateTime },
                        new ForecastViewModel(_forecastReport.ForecastDay1) { IssuedDate = _forecastReport.IssueDateTime },
                        new OutlookViewModel(_forecastReport.OutlookDay2, date.AddDays(2)) { IssuedDate = _forecastReport.IssueDateTime },
                        new OutlookViewModel(_forecastReport.OutlookDay3, date.AddDays(3)) { IssuedDate = _forecastReport.IssueDateTime },
                        new OutlookViewModel(_forecastReport.OutlookDay4, date.AddDays(4)) { IssuedDate = _forecastReport.IssueDateTime }
                };
            }
            catch (Exception ex)
            {
                _error = ex;
                if (_isVisible)
                    ShowError();
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void ShowError()
        {
            if (_error == null)
                return;

            var result = await _dialogProvider.DisplayActionSheet(_error.Message, "Cancel", null, "Retry");
            _error = null;

            if (result == "Retry")
                LoadForecast();
        }

        private void ShowHazards()
        {
            if (_hazardsViewModel == null)
                _hazardsViewModel = new HazardsViewModel(_forecastReport);

            _navigator.PushAsync<HazardsViewModel>(_hazardsViewModel);
        }
    }
}


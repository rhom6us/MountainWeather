using System;
using NUnit.Framework;
using Silkweb.Mobile.MountainWeather.ViewModels;

namespace Silkweb.Mobile.MountainWeather.Tests.ViewModels
{
    [TestFixture]
    public class ForecastReportViewModelFixture
    {
        [Test]
        public void CreatesWithForecast()
        {
            bool forecastChanged = false;
            var viewModel = new ForecastReportViewModel();

            viewModel.PropertyChanged += (sender, e) => 
                {
                    if (e.PropertyName == "Forecast" && viewModel.Forecast == "Test Forecast")
                    {
                        forecastChanged = true;
                    }
                };

            viewModel.Forecast = "Test Forecast";

            Assert.That(forecastChanged, Is.True);
        }

    }

}


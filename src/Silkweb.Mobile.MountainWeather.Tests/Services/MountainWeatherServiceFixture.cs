using System;
using NUnit.Framework;
using Silkweb.Mobile.MountainWeather.Services;
using System.Linq;
using Moq;
using Silkweb.Mobile.Core.Services;

namespace Silkweb.Mobile.MountainWeather.Tests.Services
{
    [TestFixture]
    public class MountainWeatherServiceFixture
    {
        [Test, Ignore] // Current issue with 'Type Load Exception'
        public async void ReturnsMountainAreas()
        {
            var dialogSerivce = new Mock<IDialogService>();
            var service = new MountainWeatherService(dialogSerivce.Object);

            var areas = await service.GetAreas();

            Assert.That(areas, Is.Not.Null);
            Assert.That(areas.Count(), Is.GreaterThan(1));
        }

        [Test, Ignore] // Current issue with 'Type Load Exception'
        public async void ReturnAreaForecastReport()
        {
            var dialogSerivce = new Mock<IDialogService>();
            var service = new MountainWeatherService(dialogSerivce.Object);

            var forecastReport = await service.GetAreaForecast(101);

            Assert.That(forecastReport, Is.Not.Null);
            Assert.That(forecastReport.ForecastDay0, Is.Not.Null);
        }
    }
}


using System;
using NUnit.Framework;
using Silkweb.Mobile.MountainWeather.Services;
using System.Linq;

namespace Silkweb.Mobile.MountainWeather.Tests.Services
{
    [TestFixture]
    public class MountainWeatherServiceFixture
    {
        [Test]
        public void ReturnsMountainAreas()
        {
            var service = new MountainWeatherService();

            var areas = service.GetAreas();

            Assert.That(areas, Is.Not.Null);
            Assert.That(areas.Count(), Is.GreaterThan(1));
        }

        [Test]
        public void ReturnAreaForecastReport()
        {
            var service = new MountainWeatherService();

            var forecastReport = service.GetAreaForecast(100);

            Assert.That(forecastReport, Is.Not.Null);
            Assert.That(forecastReport.Forecast, Is.EqualTo("Today will be fine and dry."));
        }
    }
}


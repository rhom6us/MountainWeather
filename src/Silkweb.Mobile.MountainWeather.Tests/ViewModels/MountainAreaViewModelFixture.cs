using System;
using NUnit.Framework;
using Silkweb.Mobile.MountainWeather.ViewModels;
using Silkweb.Mobile.MountainWeather.Models;
using Silkweb.Mobile.MountainWeather.Services;
using Moq;
using Silkweb.Mobile.Core.Services;

namespace Silkweb.Mobile.MountainWeather.Tests.ViewModels
{
    [TestFixture]
    public class MountainAreaViewModelFixture
    {
        [Test]
        public void ShowsForecastWhenShowForecastCommandExecutes()
        {
            var location = new Location { Id = 100, Name = "Area 1" };
            var service = new Mock<IMountainWeatherService>();
            var forecast = new ForecastReport { Forecast = "Test forecast" };
            service.Setup(x => x.GetAreaForecast(100)).Returns(forecast);
            var navigator = new Mock<INavigator>();
            var viewModel = new MountainAreaViewModel(location, service.Object, navigator.Object);

            Assert.That(viewModel.Name, Is.EqualTo(location.Name));

            viewModel.ShowForecastCommand.Execute(null);

            service.Verify(x => x.GetAreaForecast(100));
        }
    }
}


using Silkweb.Mobile.MountainWeather.Models;
using System.Collections.Generic;

namespace Silkweb.Mobile.MountainWeather.Services
{
    public interface IMountainWeatherService
    {
        IEnumerable<Location> GetAreas();

        ForecastReport GetAreaForecast(int id);
    }
}


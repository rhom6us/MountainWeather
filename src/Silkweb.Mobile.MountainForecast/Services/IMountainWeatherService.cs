using Silkweb.Mobile.MountainForecast.Models;
using System.Collections.Generic;

namespace Silkweb.Mobile.MountainForecast.Services
{
    public interface IMountainWeatherService
    {
        IEnumerable<Location> GetAreas();

        ForecastReport GetAreaForecast(int id);
    }
}


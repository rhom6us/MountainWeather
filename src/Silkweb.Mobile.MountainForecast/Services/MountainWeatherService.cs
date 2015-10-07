using Silkweb.Mobile.MountainForecast.Models;
using System.Collections.Generic;

namespace Silkweb.Mobile.MountainForecast.Services
{
    public class MountainWeatherService : IMountainWeatherService
    {
        public IEnumerable<Location> GetAreas()
        {
            return new Location[]
            {
                new Location { Id = 100, Name = "Area 1" },
                new Location { Id = 100, Name = "Area 2" },
                new Location { Id = 100, Name = "Area 3" },
                new Location { Id = 100, Name = "Area 4" },
                new Location { Id = 100, Name = "Area 5" },
            };
        }
    }
}


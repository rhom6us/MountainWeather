using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silkweb.Mobile.MountainForecast.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            Title = "Mountain Forecast";
            Forecast = "Tomorrow is going to be nice and sunny";
        }

        public string Title { get; set; }

        public string Forecast { get; set; }
    }
}

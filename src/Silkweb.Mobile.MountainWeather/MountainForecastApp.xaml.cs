using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Silkweb.Mobile.MountainWeather.Views;
using Silkweb.Mobile.MountainWeather.ViewModels;
using Silkweb.Mobile.Core;
using Autofac;

namespace Silkweb.Mobile.MountainWeather
{	
	public partial class MountainWeatherApp : App
	{	
		public MountainWeatherApp()
		{
			InitializeComponent();

            var bootstrapper = new Bootstrapper(this);
            bootstrapper.Run();
		}

        public new static App Current
        {
            get { return App.Current ?? new MountainWeatherApp();  }
        }
	}
}


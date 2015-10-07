using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Silkweb.Mobile.MountainForecast.Views;
using Silkweb.Mobile.MountainForecast.ViewModels;
using Silkweb.Mobile.Core;
using Autofac;

namespace Silkweb.Mobile.MountainForecast
{	
	public partial class MountainForecastApp : App
	{	
		public MountainForecastApp()
		{
			InitializeComponent();

            var bootstrapper = new Bootstrapper(this);
            bootstrapper.Run();
		}

        public new static App Current
        {
            get { return App.Current ?? new MountainForecastApp();  }
        }
	}
}


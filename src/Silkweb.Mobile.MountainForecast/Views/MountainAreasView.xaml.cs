using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Silkweb.Mobile.MountainForecast.ViewModels;

namespace Silkweb.Mobile.MountainForecast.Views
{	
	public partial class MountainAreasView : ContentPage
	{	
        public MountainAreasView (MountainAreasViewModel viewModel)
		{
			InitializeComponent ();

            BindingContext = viewModel;
		}
	}
}


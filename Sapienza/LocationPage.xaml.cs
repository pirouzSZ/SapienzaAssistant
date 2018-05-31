using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Sapienza
{
	public partial class LocationPage : ContentPage
	{
		public string ScalaCdetails = "Scala C is in front of Uni Credit Bank ";


		public LocationPage()
		{
			//BindingContext = new MainViewModel();
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			MainMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(41.903743, 12.517133), Distance.FromMeters(200)));

			var scalaC = new Pin
			{
				
				Position = new Position(41.903743, 12.517133),
				Label = "Scala C"
			};

			var Museum = new Pin
			{
				
				Position = new Position(41.903377, 12.515748),
				Label = "Modern Art Museum"
			};
           
			MainMap.Pins.Add(scalaC);
			MainMap.Pins.Add(Museum);

            scalaC.Clicked += Pin_Clicked;
			Museum.Clicked += Pin_Clicked;
		}

		private void Pin_Clicked(object sender, EventArgs e)
		{
			var selectedPin = sender as Pin;
			DisplayAlert(selectedPin.Label, ScalaCdetails, "Got It!");
		}

	
	}
}

using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Sapienza
{
	public partial class AboutPage : ContentPage
	{
		public AboutPage()
		{
			NavigationPage.SetHasNavigationBar(this, false);
			AbsoluteLayout peakLayout = new AbsoluteLayout
			{
				HeightRequest = 250,
				BackgroundColor = Color.Black
			};

			var title = new Label
			{
				Text = "Sapienza University",
				FontSize = 30,
				FontFamily = "AvenirNext-DemiBold",
				TextColor = Color.White
			};

			var where = new Label
			{
				Text = "Italy, Rome",
				TextColor = Color.FromHex("#ddd"),
				FontFamily = "AvenirNextCondensed-Medium"
			};

			var image = new Image()
			{
				Source = "/Users/pirouz/Projects/xamarin projects/Sapienza/Sapienza/Resources/sapienzaback.jpeg",
				Aspect = Aspect.AspectFill,
			};

			var overlay = new BoxView()
			{
				Color = Color.Black.MultiplyAlpha(.7f)
			};

			var pin = new Image()
			{
				Source = "/Users/pirouz/Projects/xamarin projects/Sapienza/Sapienza/Resources/white-pin-hi.png",
				HeightRequest = 25,
				WidthRequest = 25
			};

			var description = new Frame()
			{
				Padding = new Thickness(10, 5),
				HasShadow = false,
				BackgroundColor = Color.FromHex("#77202D"),
				Content = new Label()
				{
					FontSize = 14,
					TextColor = Color.FromHex("#ddd"),
					Text = "The Sapienza University of Rome (Italian: Sapienza – Università di Roma), also called simply Sapienza or the University of Rome, is a collegiate research university located in Rome, Italy. Formally known as Università degli Studi di Roma 'La Sapienza', it is one of the largest European universities by enrollments and one of the oldest in history, founded in 1303. The University is one of the most prestigious Italian universities, commonly ranking first in national rankings and in Southern Europe."
				}
			};

			AbsoluteLayout.SetLayoutFlags(overlay, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds(overlay, new Rectangle(0, 1, 1, 0.3));

			AbsoluteLayout.SetLayoutFlags(image, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds(image, new Rectangle(0f, 0f, 1f, 1f));

			AbsoluteLayout.SetLayoutFlags(title, AbsoluteLayoutFlags.PositionProportional);
			AbsoluteLayout.SetLayoutBounds(title,
				new Rectangle(0.1, 0.85, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize)
			);

			AbsoluteLayout.SetLayoutFlags(where, AbsoluteLayoutFlags.PositionProportional);
			AbsoluteLayout.SetLayoutBounds(where,
				new Rectangle(0.1, 0.95, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize)
			);

			AbsoluteLayout.SetLayoutFlags(pin, AbsoluteLayoutFlags.PositionProportional);
			AbsoluteLayout.SetLayoutBounds(pin,
				new Rectangle(0.95, 0.9, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize)
			);

			peakLayout.Children.Add(image);
			peakLayout.Children.Add(overlay);
			peakLayout.Children.Add(title);
			peakLayout.Children.Add(where);
			peakLayout.Children.Add(pin);

			Content = new StackLayout()
			{
				BackgroundColor = Color.FromHex("#77202D"),
				Children = {
					peakLayout,
					description,
				}
			};

		}
	}
}

using FabrikamFoods.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace FabrikamFoods
{
    public partial class DescriptionPage : ContentPage
    {
        public DescriptionPage()
        {
            var layout = new StackLayout { Padding = new Thickness(35, 15) };
            this.Content = layout;
            var label1 = new Label { Text = "Location: Auckland CBD", TextColor = Color.FromHex("#000000"), FontSize = 20 };
            var label2 = new Label { Text = "Atrium on Elliott, Level 4, 21-25, Elliott Street", TextColor = Color.FromHex("#000000"), FontSize = 14 };
            var label3 = new Label { Text = "Opening hours", TextColor = Color.FromHex("#000000"), FontSize = 14 };
            var label4 = new Label { Text = "All days 11:30 AM to 10 PM", TextColor = Color.FromHex("#000000"), FontSize = 14 };
            var map = new Map(
            MapSpan.FromCenterAndRadius(
                    new Position(-36.8497437, 174.7632797), Distance.FromMiles(0.3)))
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
            };

            var position = new Position(-36.8497437, 174.7632797); // Latitude, Longitude
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = "Fabrikam Foods",
                Address = "Auckland CBD, Atrium on Elliott, Level 4, 21-25, Elliott Street"
            };
            map.Pins.Add(pin);


            var label5 = new Label { Text = "Niche and modern resturant. Welcoming atmosphere and good food, come try the Fabrikam taste!", TextColor = Color.FromHex("#000000"), FontSize = 14 };

            layout.Children.Add(label1);
            layout.Children.Add(label2);
            layout.Children.Add(label3);
            layout.Children.Add(label4);
            layout.Children.Add(map);
            layout.Children.Add(label5);
        }

    }
}

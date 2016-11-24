using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FabrikamFoods
{
    public partial class NavigationPage : ContentPage
    {
        public double myPoints;
        public string myUsername;
        public NavigationPage(string username, double points)
        {
            myPoints = points;
            myUsername = username;
            var layout = new StackLayout { Padding = new Thickness(35, 15) };
            this.Content = layout;

            var label1 = new Label { Text = "Welcome " + username, TextColor = Color.FromHex("#000000"), FontSize = 20 };

            var burgerImage = new Image { Aspect = Aspect.AspectFit };
            burgerImage.Source = ImageSource.FromFile("burger.jpg");

            var juiceImage = new Image { Aspect = Aspect.AspectFit };
            juiceImage.Source = ImageSource.FromFile("juice.jpg");

            Button description = new Button
            {
                Text = "Description",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };
            description.Clicked += OnButtonClicked1;

            Button menu = new Button
            {
                Text = "Menu",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };
            menu.Clicked += OnButtonClicked2;

            layout.Children.Add(label1);
            layout.Children.Add(burgerImage);
            layout.Children.Add(menu);
            layout.Children.Add(description);
            layout.Children.Add(juiceImage);
            
        }

        async void OnButtonClicked1(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            await Navigation.PushModalAsync(new DescriptionPage());
        }

        async void OnButtonClicked2(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            await Navigation.PushModalAsync(new MenuPage(myUsername, myPoints));
        }
    }
}

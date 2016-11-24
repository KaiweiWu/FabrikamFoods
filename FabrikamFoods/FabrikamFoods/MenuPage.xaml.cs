using FabrikamFoods.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FabrikamFoods
{
    public partial class MenuPage : ContentPage
    {
        public string usernameS;
        public string pinCode = "123a";
        public string enteredPin;
        public MenuPage(string username, double points)
        {
            usernameS = username;
            String pointStars = String.Concat(Enumerable.Repeat("x", (int)points));
            InitializeComponent();

            var label1 = new Label { Text = "Points: " + pointStars, TextColor = Color.FromHex("#000000"), FontSize = 14 };
            var label2 = new Label { Text = "(Reach 10 to receive a free meal)", TextColor = Color.FromHex("#000000"), FontSize = 14 };
            layout.Children.Add(label1);
            layout.Children.Add(label2);

            var entry = new Entry { IsPassword = true, Placeholder = "PinCode" };
            entry.Completed += Entry_Completed;
            entry.TextChanged += Entry_TextChanged;
            layout.Children.Add(entry);

            Button addPoints = new Button
            {
                Text = "addPoints",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };
            addPoints.Clicked += OnButtonClicked1;
            layout.Children.Add(addPoints);
        }

        private async void ViewTimeline_Clicked(object sender, EventArgs e)
        {
            List<menutable> menu = await AzureManager.AzureManagerInstance.GetMenuTable();
            MenuList.ItemsSource = menu;

        }

        void Entry_Completed(object sender, EventArgs e)
        {
            enteredPin = ((Entry)sender).Text; //cast sender to access the properties of the Entry

        }

        void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            string oldText = e.OldTextValue;
            enteredPin = e.NewTextValue;
        }

        async void OnButtonClicked1(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            if (pinCode == enteredPin)
            {
                List<usertable> users = await AzureManager.AzureManagerInstance.GetUsers();
                foreach (usertable u in users)
                {
                    if (usernameS == u.username)
                    {
                        u.points += 1;
                        await AzureManager.AzureManagerInstance.UpdateUser(u);
                        await DisplayAlert("Point added, restart app to view", "Great", "Done");
                        return;
                    }
                }
            } else
            {
                await DisplayAlert("Wrong pincode", "Ask the manager for today's code", "Yes sir");
                return;
            }
        }
    }
}

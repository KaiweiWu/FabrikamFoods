using FabrikamFoods.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FabrikamFoods
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public string usernameS = "";
        public string passwordS = "";


        void Username_Completed(object sender, EventArgs e)
        {
            usernameS = ((Entry)sender).Text; //cast sender to access the properties of the Entry
        }

        void Password_Completed(object sender, EventArgs e)
        {
            passwordS = ((Entry)sender).Text; //cast sender to access the properties of the Entry
        }

        void User_TextChanged(object sender, TextChangedEventArgs e)
        {
            string oldText = e.OldTextValue;
            usernameS = e.NewTextValue;
        }

        void Pass_TextChanged(object sender, TextChangedEventArgs e)
        {
            string oldText = e.OldTextValue;
            passwordS = e.NewTextValue;
        }

    async void OnButtonClicked1(object sender, EventArgs args)
        {
            Button button = (Button)sender;

            List<usertable> users = await AzureManager.AzureManagerInstance.GetUsers();
            foreach (usertable u in users)
            {
                if (usernameS == u.username)
                {
                    await DisplayAlert("Username already exists", "Please change it :)", "Fine :(");
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(usernameS))
            {
                await DisplayAlert("Username cannot be whitespace", "Don't try to trick me :)", "Fine :(");
                return;
            }

            if (string.IsNullOrWhiteSpace(passwordS))
            {
                await DisplayAlert("Password cannot be whitespace", "Don't try to trick me :)", "Fine :(");
                return;
            }

            usertable entry = new usertable()
            {
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now,
                password = passwordS,
                username = usernameS,
                points = 0
            };

            await AzureManager.AzureManagerInstance.AddUser(entry);

            await DisplayAlert("Successfully signed up!", "Great", "Thanks");
        }

        async void OnButtonClicked2(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            List<usertable> users = await AzureManager.AzureManagerInstance.GetUsers();
            foreach (usertable u in users)
            {
                if (usernameS == u.username)
                {
                    if (passwordS == u.password)
                    {
                        await Navigation.PushModalAsync(new NavigationPage(usernameS, u.points));
                        return;
                    }
                }
            }
            await DisplayAlert("Username or Password incorrect", "Sorry about that :(", "You are forgiven.");

        }

        async void OnButtonClicked3(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            await Navigation.PushModalAsync(new NavigationPage("Dear Guest", 0));
        }
    }
}

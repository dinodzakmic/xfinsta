using System;
using System.Collections.Generic;
using Plugin.Connectivity;
using Xamarin.Auth;
using Xamarin.Forms;
using XFInsta.Model;

namespace XFInsta.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            CheckAccounts();
            base.OnAppearing();
        }

        private void CheckAccounts()
        {
            AccountData.InstagramAccount = null;
            if (Settings.InstagramState != "" && Settings.InstagramAccessToken != "" && Settings.InstagramExpiresIn != "")
            {
                Dictionary<string, string> properties = new Dictionary<string, string>
                {
                    {"state", Settings.InstagramState},
                    {"access_token", Settings.InstagramAccessToken},
                    {"expires_in", Settings.InstagramExpiresIn}
                };


                AccountData.InstagramAccount = new Account(Settings.InstagramUsername, properties);
            }            
        }

        
        private async void OnInstagramlicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
                await DisplayAlert("No Connection", "It appears you are not connected to the Internet", "OK");
            else
            {
                InstagramLogin.IsEnabled = false;
                if (AccountData.InstagramAccount == null)
                {
                    OAuth2Authenticator auth = new OAuth2Authenticator(
                        clientId: "e3ba4107e32e4eaaace69a6353c3e3d4",
                        scope: "basic",
                        authorizeUrl: new Uri("https://api.instagram.com/oauth/authorize/"),
                        redirectUrl: new Uri("https://www.instagram.com/"));

                    await Navigation.PushModalAsync(new AuthLoginPage(auth) {Title = "Instagram"});
                }
                else
                {
                    await Navigation.PushModalAsync(new ProfilePage() {Title = "Instagram"});
                }
                InstagramLogin.IsEnabled = true;
            }
        }     
    }
}

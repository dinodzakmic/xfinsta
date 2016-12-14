using System;
using System.Collections.Generic;
using Plugin.Connectivity;
using Xamarin.Auth;
using Xamarin.Forms;
using XFInsta.Model;
using XFInsta.ViewModels;

namespace XFInsta.Views
{
    public partial class ProfilePage : ContentPage
    {
        private string _account;
        public InstagramViewModel InstagramVM;
        public ProfilePage()
        {
            InitializeComponent();

            InstagramVM = new InstagramViewModel();
            BindingContext = InstagramVM;
          
        }
        protected override void OnAppearing()
        {
            PopulateValues();
            base.OnAppearing();
        }
        private void PopulateValues()
        {
            if (AccountData.InstagramAccount != null)
            {
                GetInstagramData();
            }
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private async void GetInstagramData()
        {
            try
            {                
                var request = new OAuth2Request("GET", new Uri("https://api.instagram.com/v1/users/self/media/recent/"), null, AccountData.InstagramAccount );
                var response = await request.GetResponseAsync();
                var txt = await response.GetResponseTextAsync();
                InstagramVM.InitDataAsync(txt);

            }
            catch (Exception e)
            {
                await DisplayAlert("Logged Out", "Sorry, you were logged out of Instagram!", "OK");
                SignOut();
            }
        }       

        private void SignOut()
        {
            Settings.InstagramUsername = "";
            Settings.InstagramState = "";
            Settings.InstagramAccessToken = "";
            Settings.InstagramExpiresIn = "";

            Navigation.PopModalAsync();
        }


        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView) sender).SelectedItem = null;
        }
    }
}

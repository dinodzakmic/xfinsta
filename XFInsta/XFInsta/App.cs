﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Xamarin.Auth;
using Xamarin.Forms;
using XFInsta.Model;
using XFInsta.Views;

namespace XFInsta
{
    public class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new LoginPage()) { Title="Log In" };  
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

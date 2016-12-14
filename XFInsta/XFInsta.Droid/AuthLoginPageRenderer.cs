using System;
using System.Collections.Generic;
using Android.App;
using XFInsta;
using XFInsta.Droid;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFInsta.Model;

[assembly: ExportRenderer(typeof(AuthLoginPage), typeof(AuthLoginPageRenderer))]
namespace XFInsta.Droid
{
    public class AuthLoginPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
            AuthLoginPage page = e.NewElement as AuthLoginPage;
            var activity = this.Context as Activity;

            if (page != null)
            {
                var auth = page.Authenticator;

                auth.Completed += (sender, eventArgs) => {
                                                             if (eventArgs.IsAuthenticated)
                                                             {
                    
                                                                 if (eventArgs.Account.Properties.Count == 1)
                                                                 {
                                                                     Settings.InstagramUsername = eventArgs.Account.Username;
                                                                     Settings.InstagramAccessToken  = eventArgs.Account.Properties["access_token"];

                                                                     Dictionary<string, string> properties = new Dictionary<string, string>
                                                                     {
                                                                         {"state", Settings.InstagramState},
                                                                         {"access_token", Settings.InstagramAccessToken},
                                                                         {"expires_in", Settings.InstagramAccessToken}
                                                                     };

                                                                     Account account = new Account(Settings.InstagramUsername, properties);
                                                                     AccountData.InstagramAccount = account;
                                                                     page.InstagramLoginAction.Invoke();
                                                                 }                   
                                                                 else
                                                                     page.FailedLoginAction.Invoke();
                                                             }
                                                             else
                                                             {
                                                                 page.FailedLoginAction.Invoke();
                                                             }
                };

                activity?.StartActivity(auth.GetUI(activity));
            }
        }
    }
}
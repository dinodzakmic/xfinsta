using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Forms;

namespace XFInsta
{
    public class AuthLoginPage : Page
    {
        public OAuth2Authenticator Authenticator;

        public AuthLoginPage(OAuth2Authenticator authenticator)
        {
            this.Authenticator = authenticator;
        }
        public Action InstagramLoginAction => new Action(LoadInstagram);
        public Action FailedLoginAction => new Action(GoBack);

        private void LoadInstagram()
        {
            Navigation.PopModalAsync();
            Navigation.PushModalAsync(new Views.ProfilePage() { Title = "Instagram" });
        }
            
        private void GoBack()
        {
            Navigation.PopModalAsync();
        }
    }
}

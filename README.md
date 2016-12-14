# xfinsta

In order to use Instagram API, you'll need to create Instagram profile and register for developer options on https://www.instagram.com/developer/.

After that, create your API client following Instagram documentation(add few Sandbox users, set Redirect Uri to "https://www.instagram.com", uncheck Disable implicit OAuth etc.)

Copy your Client ID in LoginPage.xaml.cs -> OnInstagramClicked func -> 

 OAuth2Authenticator auth = new OAuth2Authenticator(
                        clientId: "YOUR_CLIENT_ID",
                        scope: "basic",
                        authorizeUrl: new Uri("https://api.instagram.com/oauth/authorize/"),
                        redirectUrl: new Uri("https://www.instagram.com/"));

using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace XFInsta.Model
{
    public static class Settings
    {
        #region Instagram
        private const string instagramUsername = "instagramUsername";
        private static readonly string defaultInstagramUsername = "";

        public static string InstagramUsername
        {
            get { return AppSettings.GetValueOrDefault<string>(instagramUsername, defaultInstagramUsername); }
            set { AppSettings.AddOrUpdateValue<string>(instagramUsername, value); }
        }

        private const string instagramState = "instagramState";
        private static readonly string defaultInstagramState = "";

        public static string InstagramState
        {
            get { return AppSettings.GetValueOrDefault<string>(instagramState, defaultInstagramState); }
            set { AppSettings.AddOrUpdateValue<string>(instagramState, value); }
        }

        private const string instagramAccessToken = "instagramAccessToken";
        private static readonly string defaultInstagramAccessToken = "";

        public static string InstagramAccessToken
        {
            get { return AppSettings.GetValueOrDefault<string>(instagramAccessToken, defaultInstagramAccessToken); }
            set { AppSettings.AddOrUpdateValue<string>(instagramAccessToken, value); }
        }

        private const string instagramExpiresIn = "instagramExpiresIn";
        private static readonly string defaultInstagramExpiresIn = "";

        public static string InstagramExpiresIn
        {
            get { return AppSettings.GetValueOrDefault<string>(instagramExpiresIn, defaultInstagramExpiresIn); }
            set { AppSettings.AddOrUpdateValue<string>(instagramExpiresIn, value); }
        }
        #endregion

        #region Language
        private const string language = "language";
        private static readonly string defaultLanguage = "en-GB";

        public static string Language
        {
            get { return AppSettings.GetValueOrDefault<string>(language, defaultLanguage); }
            set { AppSettings.AddOrUpdateValue<string>(language, value); }
        }

        #endregion

        private static ISettings AppSettings => CrossSettings.Current;
    }
}

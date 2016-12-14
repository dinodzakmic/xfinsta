using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using XFInsta.Model;

namespace XFInsta.ViewModels
{
    public class InstagramViewModel : INotifyPropertyChanged
    {
        private List<InstagramItem> _instagramItems;

        public List<InstagramItem> InstagramItems
        {
            get { return _instagramItems; }
            set
            {
                _instagramItems = value;
                OnPropertyChanged();
            }
        }


        private bool _loadingData;

        public bool LoadingData
        {
            get { return _loadingData; }
            set
            {
                _loadingData = value;
                OnPropertyChanged();
            }
        }
        public InstagramViewModel()
        {
            LoadingData = true;
        }

        public async void InitDataAsync(string json)
        {
            JObject response = JsonConvert.DeserializeObject<dynamic>(json);

            var items = response.Value<JArray>("data");

            try
            {
                var instagramItems = items.Select(item => new InstagramItem
                {
                    UserName = item.Value<JObject>("user").Value<string>("username"),
                    FullName = item.Value<JObject>("user").Value<string>("full_name"),
                    ProfilePicture = item.Value<JObject>("user").Value<string>("profile_picture"),
                    LowResolutionUrl =
                        item.Value<JObject>("images").Value<JObject>("low_resolution").Value<string>("url"),
                    StandardResolutionUrl =
                        item.Value<JObject>("images").Value<JObject>("standard_resolution").Value<string>("url"),
                    ThumbnailUrl = item.Value<JObject>("images").Value<JObject>("thumbnail").Value<string>("url"),
                    Text = item.Value<JObject>("caption").Value<string>("text"),
                    CreatedTime = item.Value<JObject>("caption").Value<string>("created_time"),
                    LikesCount = item.Value<JObject>("likes").Value<int>("count"),
                    CommentsCount = item.Value<JObject>("comments").Value<int>("count")
                }).ToList();

                InstagramItems = instagramItems;
            }
            catch (Exception e)
            {

            }
            finally
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                LoadingData = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

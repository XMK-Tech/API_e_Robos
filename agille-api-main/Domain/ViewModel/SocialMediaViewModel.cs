using AgilleApi.Domain.Enums;
using System;

namespace AgilleApi.Domain.ViewModel
{
    public class SocialMediaViewModel
    {
        public SocialMediaViewModel(SocialMediaEnum type, string url)
        {
            Url = url;
            Type = type;
        }

        public string Url { get; set; }
        public SocialMediaEnum Type { get; set; }
    }
}

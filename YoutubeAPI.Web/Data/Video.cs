using System;

namespace YoutubeAPI.Web.Data
{
    public class Video
    {
        //public string playlistId { get; set; }
        public string channelId { get; set; }
        public Channel Channel { get; set; }
        public string videoId { get; set; }
        public DateTime publishedAt { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string thumbnail_default_url { get; set; }
        public bool watched { get; set; }
    }
}

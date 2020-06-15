using System;
using System.Collections.Generic;
using System.Text;

namespace Ex4_FASE1
{
    class Video
    {
        public Video(string url, string title, List<string> tags)
        {
            this.URL = url;
            this.Title = title;
            this.Tags = tags;
        }
        public string URL { get; set; }
        public string Title { get; set; }
        public List<string> Tags { get; set; }
    }
}

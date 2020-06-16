using System;
using System.Collections.Generic;
using System.Text;

namespace Ex4_FASE3
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
        public void PerformActions(VideoActions action)
        {
            switch (action)
            {
                case VideoActions.AddTag:
                    Console.WriteLine("Which tag would you like to add?");
                    break;
                case VideoActions.Play:
                    Console.WriteLine("Started playing video");
                    break;
                case VideoActions.Pause:
                    Console.WriteLine("Video paused");
                    break;
                case VideoActions.Stop:
                    Console.WriteLine("Stopped video reproduction");
                    break;
                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        }
    }
}

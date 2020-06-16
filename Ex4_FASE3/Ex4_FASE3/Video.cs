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
            Status = VideoStatus.Stop;
        }
        public string URL { get; set; }
        public string Title { get; set; }
        public List<string> Tags { get; set; }
        public VideoStatus Status { get; set; }
        public void SetStatus(VideoStatus action)
        {
            switch (action)
            {
                case VideoStatus.AddTag:
                    Console.WriteLine("Which tag would you like to add?");
                    break;
                case VideoStatus.Play:
                    Console.WriteLine("The video is playing!");
                    this.Status = VideoStatus.Play;
                    break;
                case VideoStatus.Pause:
                    Console.WriteLine("Video paused");
                    this.Status = VideoStatus.Pause;
                    break;
                case VideoStatus.Stop:
                    Console.WriteLine("Stopped video reproduction");
                    this.Status = VideoStatus.Stop;
                    break;
                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;

namespace Ex4_FASE2
{
    class User
    {
        public User()
        {
            registration = DateTime.Now;
        }

        public User(string username, string name, string surname, string password)
        {
            this.Username = username;
            this.Name = name;
            this.Surname = surname;
            this.Password = password;
            registration = DateTime.Now;
        }

        DateTime registration;
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }

        List<Video> videoList = new List<Video>();  

        public Video NewVideo(string url, string title, List<string> tags)
        {
            Video newVideo = new Video(url, title, tags);
            videoList.Add(newVideo);
            return newVideo;
        }
        public void AllVideos()
        {
            int count = 1;
            foreach (Video video in videoList)
            {
                Console.WriteLine($"{count}. URL: {video.URL}, Title: \"{video.Title}\"");

                string tagsPrint = "Tags: ";

                foreach (string tag in video.Tags)
                {
                    tagsPrint.Concat(tag).Concat(", ");
                }
                tagsPrint = tagsPrint.Remove(tagsPrint.Length - ", ".Length);

                Console.WriteLine(tagsPrint);

                count++;
            }
        }
    }
}

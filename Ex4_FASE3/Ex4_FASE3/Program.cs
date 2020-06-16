using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex4_FASE3
{
    class Program
    {
        static List<User> userList = new List<User>();

        static bool CheckString(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                Console.WriteLine("Invalid input");
                return true;
            }
            else
            {
                return false;
            }
        }

        static string AskUser(string reference)
        {
            string input;
            bool check;
            do
            {
                Console.Write($"{reference}: ");
                input = Console.ReadLine();
                check = CheckString(input);
            } while (check);
            return input;
        }

        static int CheckMainMenu(int upperRange)
        {
            int chosenOption = 0;
            try
            {
                chosenOption = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Input must be an integer. " + e.Message);
            }

            if (chosenOption <= 0 || chosenOption > upperRange)
            {
                Console.WriteLine("Index out of range");
            }
            return chosenOption;
        }
        
        static void MainMenu(User loggedUser)
        {
            if (!loggedUser.VideoList.Any())
            {
                string url, title;
                List<string> videoTags = new List<string>();
                Console.WriteLine("You don't have any videos yet. Let's add some!");
                videoTags.Add(AskUser("Add one tag. You can add more later"));
                url = AskUser("URL");
                title = AskUser("Title");

                Video newVideo = new Video(url, title, videoTags);

                Console.WriteLine($"\"{newVideo.Title}\" has been uploaded successfully");
                
                return;
            }

            Console.WriteLine("These are your videos. To select one, write its index in the command line.");

            int total = loggedUser.AllVideos();
            int chosenOption;

            chosenOption = CheckMainMenu(total);

            if (!Convert.ToBoolean(chosenOption))
            {
                return;
            }

            Video chosenVideo = loggedUser.VideoList[chosenOption];

            Console.WriteLine($"You have selected \"{chosenVideo.Title}\". Now write the index of the action you would like to perform:");
            Console.WriteLine("1. Add tags");
            Console.WriteLine("2. Play video");

            chosenOption = CheckMainMenu(2);

            if (!Convert.ToBoolean(chosenOption))
            {
                return;
            }
            if (chosenOption == 1)
            {
                chosenVideo.SetStatus(VideoStatus.AddTag);
                chosenVideo.Tags.Add(AskUser("Add a new tag"));
            }
            else
            {
                chosenVideo.SetStatus(VideoStatus.Play);
                Console.WriteLine("1. Pause video");
                Console.WriteLine("2. Stop video");

                chosenOption = CheckMainMenu(2);

                if (!Convert.ToBoolean(chosenOption))
                {
                    return;
                }
                if (chosenOption == 1)
                {
                    chosenVideo.SetStatus(VideoStatus.Pause);
                }
                else
                {
                    chosenVideo.SetStatus(VideoStatus.Stop);
                }
            }
            return;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to videos.NET. Do you have an account (yes / no)?");
            string answer = Console.ReadLine();
            if (String.Equals(answer, "yes", StringComparison.OrdinalIgnoreCase))
            {
                bool correctUser = false;
                while(!correctUser)
                {
                    string username = AskUser("Username");
                    foreach (User user in userList)
                    {
                        if (String.Equals(username, user.Username))
                        {
                            correctUser = true;
                            Console.Write("Password: ");
                            string password = Console.ReadLine();
                            if (String.Equals(password, user.Password))
                            {
                                Console.WriteLine($"Welcome, {username}!");
                                MainMenu(user);
                            }
                            else
                            {
                                Console.WriteLine("Invalid password");
                            }
                        }
                    }
                    if (!correctUser)
                    {
                        Console.WriteLine("Invalid username");
                    }
                }
            }
            else if (String.Equals(answer, "no", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Then, please sign up.");
                string newUsername, name, surname, password;
                bool foundUser = false;
                do
                {
                    newUsername = AskUser("Username");

                    foreach (User user in userList)
                    {
                        if (String.Equals(newUsername, user.Username))
                        {
                            foundUser = true;
                            Console.WriteLine("This username is already in use");
                            continue;
                        }
                    }

                    password = AskUser("Password");
                    name = AskUser("Name");
                    surname = AskUser("Surname");

                    User NewUser = new User(newUsername, name, surname, password);
                    userList.Add(NewUser);

                    Console.WriteLine($"Welcome, {NewUser.Username}!");
                    MainMenu(NewUser);
                } while (foundUser);
            }
            else
            {
                Console.WriteLine("Invalid answer. Exiting program.");
            }
        }
    }
}

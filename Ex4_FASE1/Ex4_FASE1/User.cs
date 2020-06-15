using System;
using System.Collections.Generic;
using System.Text;

namespace Ex4_FASE1
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
    }
}

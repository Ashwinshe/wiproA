using Config;
using System;

namespace Models
{
    public class User
    {
        public string Username { get; private set; }
        private string Password;
        private int FailedAttempts;
        public bool IsLocked { get; private set; }

        public User(string name, string password)
        {
            Username = name;
            Password = password;
            FailedAttempts = 0;
            IsLocked = false;

            AppConfig.RegisterUser();
        }

        public void Login(string password)
        {
            if (IsLocked)
            {
                Console.WriteLine(Username + " account is LOCKED");
                return;
            }

            if (Password == password)
            {
                Console.WriteLine(Username + " login successful");
                FailedAttempts = 0;
            }
            else
            {
                FailedAttempts++;
                Console.WriteLine("Wrong password for " + Username);

                if (FailedAttempts >= AppConfig.MaxLoginAttempts)
                {
                    IsLocked = true;
                    Console.WriteLine(Username + " account locked");
                }
            }
        }
    }
}

using System;

namespace Collections
{
    public class User : IUser
    {
        public User(string fullName, string username, uint? age)
        {
            Age = age;
            FullName = fullName;
            if (username != null)
            {
                Username = username;
            } else
            {
                throw new ArgumentException("Can't insert a null username");
            }
        }
        
        public uint? Age { get; }
        
        public string FullName { get; }
        
        public string Username { get; }

        public bool IsAgeDefined => Age != null;
        
        // TODO implement missing methods (try to autonomously figure out which are the necessary methods)
    }
}

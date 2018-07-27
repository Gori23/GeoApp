using System;
using System.Collections.Generic;
using System.Text;

namespace LocPeek.Models
{
    class User
    {
        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string UserName { get; protected set; }
        public string FullName { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected User()
        {

        }

        public User( string userName, string password)
        { 
            UserName = userName;
            Password = password;
        }
        public bool CheckInformation()
        {
            if (!String.IsNullOrEmpty(this.UserName) && !String.IsNullOrEmpty(this.Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}


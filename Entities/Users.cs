using System;
using System.Collections.Generic;
using System.Text;

namespace PunchTheClock.Entities
{
    class Users
    {
        public List<User> ListUsers { get; set; }

        public Users()
        {
            ListUsers = new List<User>();
        }
    }
}

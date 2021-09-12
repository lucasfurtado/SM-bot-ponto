using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace PunchTheClock.Entities
{
    public static class Users
    {
        public static ConcurrentDictionary<ulong,User> AllUsers = new ConcurrentDictionary<ulong, User>();
    }
}

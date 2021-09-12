using PunchTheClock.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PunchTheClock.BBL
{
    public class PuchingInBBL
    {
        public Task AddUser(ulong id)
        {
            User user = new User(id);
            Users.AllUsers.TryAdd(id, user);
            return Task.CompletedTask;
        }

        public Task PauseTime(ulong id)
        {
            if(Users.AllUsers.TryGetValue(id, out User user))
            {
                user.PausesAt.Add(DateTime.Now);
            }
            return Task.CompletedTask;
        }

        public Task BackIn(ulong id)
        {
            if(Users.AllUsers.TryGetValue(id, out User user))
            {
                user.PausesOutAt.Add(DateTime.Now);
            }
            return Task.CompletedTask;
        }

        public double ExitTime(ulong id)
        {
            double totalTime = 0;
            if (Users.AllUsers.TryGetValue(id, out User user))
            {
                totalTime = user.CalculateTotalTime();
            }
            return totalTime;
        }
    }
}

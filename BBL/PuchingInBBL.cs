using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using PunchTheClock.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PunchTheClock.BBL
{
    public class PuchingInBBL
    {
        public bool AddUser(ulong id)
        {
            if(Users.AllUsers.TryGetValue(id, out User user))
            {
                return false;
            }
            else
            {
                User addUser = new User(id);
                Users.AllUsers.TryAdd(id, addUser);
                return true;
            }
        }

        public bool PauseTime(ulong id)
        {
            if(Users.AllUsers.TryGetValue(id, out User user))
            {
                if(!user.IsPaused && user.IsOnline && !user.IsOffline)
                {
                    user.PausesAt.Add(DateTime.Now);
                    user.IsPaused = true;
                    user.IsOnline = false;
                    return true;
                }
            }
            return false;
        }

        public bool BackIn(ulong id)
        {
            if(Users.AllUsers.TryGetValue(id, out User user))
            {
                if (user.IsPaused && !user.IsOnline && !user.IsOffline)
                {
                    user.PausesOutAt.Add(DateTime.Now);
                    user.IsPaused = false;
                    user.IsOnline = true;
                    return true;
                }
            }
            return false;
        }

        public double ExitTime(ulong id)
        {
            double totalTime = 0;
            if (Users.AllUsers.TryGetValue(id, out User user))
            {
                if(!user.IsPaused && user.IsOnline && !user.IsOffline)
                {
                    totalTime = user.CalculateTotalTime();
                    user.IsOffline = true;
                    user.IsOnline = false;
                    user.IsPaused = false;
                }
            }
            return totalTime;
        }

        public Task RemoveUser(ulong id)
        {
            Users.AllUsers.TryRemove(id, out User user);
            return Task.CompletedTask;
        }

        public double CurrentTime(DiscordUser? user, CommandContext ctx)
        {
            if (user != null)
            {
                if (Users.AllUsers.TryGetValue(user.Id, out User auxUser))
                {
                    if (auxUser.IsPaused) return -1;
                    if (auxUser.IsOnline && !auxUser.IsPaused) return auxUser.CalculateTotalTime();
                }
                return -2;
            }
            else
            {
                if (Users.AllUsers.TryGetValue(ctx.User.Id, out User auxUser))
                {
                    if (auxUser.IsPaused) return -1;
                    if (auxUser.IsOnline && !auxUser.IsPaused) return auxUser.CalculateTotalTime();
                }
                return -2;
            }
        }

        public int UserStatus(DiscordUser? user, CommandContext ctx)
        {
            if(user != null)
            {
                if (Users.AllUsers.TryGetValue(user.Id, out User auxUser))
                {
                    if (auxUser.IsPaused == true) return 1;
                    else return 2;
                }
                return 3;
            }
            else
            {
                if (Users.AllUsers.TryGetValue(ctx.User.Id, out User auxUser))
                {
                    if (auxUser.IsPaused == true) return 1;
                    else return 2;
                }
                return 3;
            }
        }
    }
}

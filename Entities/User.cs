using System;
using System.Collections.Generic;
using System.Text;

namespace PunchTheClock.Entities
{
    public  class User
    {

        public ulong Id { get; private set; }
        public double TotalTime { get; private set; }
        public DateTime EnterAt { get; private set; }
        public DateTime ExitAt { get; private set; }
        public List<DateTime> PausesAt { get; private set; }
        public List<DateTime> PausesOutAt { get; private set; }

        public User(ulong id)
        {
            Id = id;
            TotalTime = 0;
            EnterAt = DateTime.Now;
            PausesAt = new List<DateTime>();
            PausesOutAt = new List<DateTime>();
        }

        public double CalculateTotalTime()
        {
            ExitAt = DateTime.Now;
            double pauseTime = 0;
            for (int i = 0; i < PausesAt.Count; i++)
            {
                pauseTime += (PausesOutAt[i] - PausesAt[i]).TotalHours;
            }
            TotalTime = (ExitAt - EnterAt).TotalHours - pauseTime;
            return TotalTime;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PunchTheClock.Entities
{
    public  class User
    {

        public ulong Id { get; private set; }
        public ulong TotalTime { get; private set; }
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
            TimeSpan minusTime = new TimeSpan();
            TimeSpan totalTime = new TimeSpan();
            for (int i = 0; i < PausesAt.Count; i++)
            {
                minusTime = (PausesOutAt[i] - PausesAt[i]) + minusTime;
            }
            totalTime = (EnterAt - ExitAt) - minusTime;
            return totalTime.TotalHours;
        }
    }
}

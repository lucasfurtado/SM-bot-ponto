using System;
using System.Collections.Generic;
using System.Text;

namespace PunchTheClock.Entities
{
    class User
    {

        public ulong Id { get; private set; }
        public ulong TotalTime { get; private set; }
        public DateTime EnterAt { get; private set; }
        public DateTime? ExitAt { get; private set; }
        public List<DateTime> PausesAt { get; private set; }
        public List<DateTime> PausesOutAt { get; private set; }

        public User(ulong id)
        {
            Id = id;
            TotalTime = 0;
            EnterAt = DateTime.Now;
            ExitAt = null;
            PausesAt = new List<DateTime>();
        }

        public void CalculateTotalTime()
        {
            //code
            //here
        }
    }
}

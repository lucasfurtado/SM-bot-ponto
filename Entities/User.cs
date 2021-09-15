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
        public bool IsOnline { get; set; }
        public bool IsPaused { get; set; }
        public bool IsOffline { get; set; }

        public User(ulong id)
        {
            Id = id;
            TotalTime = 0;
            EnterAt = DateTime.Now;
            PausesAt = new List<DateTime>();
            PausesOutAt = new List<DateTime>();
            IsOnline = true;
            IsPaused = false;
            IsOffline = false;
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

        public double CalculeteTotalTimeAsPaused()
        {
            double pauseTime = 0;
            if (PausesAt.Count == 1)
            {
                TotalTime = (PausesAt[0] - EnterAt).TotalHours;
            }
            else
            {
                for (int i = 0; i < PausesAt.Count-1; i++)
                {
                    pauseTime += (PausesOutAt[i] - PausesAt[i]).TotalHours;
                }
                TotalTime = (PausesAt[PausesAt.Count - 1] - EnterAt).TotalHours - pauseTime;
            }
            return TotalTime;
        }
    }
}

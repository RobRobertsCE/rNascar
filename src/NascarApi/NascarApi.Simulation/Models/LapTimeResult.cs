using System;

namespace NascarApi.Simulation.Models
{
    public class LapTimeResult
    {
        public virtual double LapTime { get; set; }
        public virtual double LapSpeed { get; set; }

        public TimeSpan Elapsed
        {
            get
            {
                return TimeSpan.Parse(LapTime.ToString());
            }
        }
    }
}

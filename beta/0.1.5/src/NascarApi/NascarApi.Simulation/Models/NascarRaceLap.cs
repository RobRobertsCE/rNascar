using System;

namespace NascarApi.Mock.Models
{
    public class NascarRaceLap : NascarLap, IComparable
    {
        public int VehicleId { get; set; }
        public int DriverId { get; set; }

        public int Position { get; set; }
        public int LeaderLap { get; set; }
        public int LapsSincePit { get; set; }
        public bool PitThisLap { get; set; }
        public bool IsLuckyDog { get; set; }

        public double Delta { get; set; }
        public double DeltaLeader { get; set; }

        public double DeltaPhysical { get; set; }

        public double TotalTime { get; set; }

        public bool IsLeadLap
        {
            get
            {
                return LeaderLap == LapNumber;
            }
        }
        public int LapsBehind
        {
            get
            {
                return LeaderLap - LapNumber;
            }
        }

        public NascarRaceLap()
            : base()
        {

        }

        public int CompareTo(object obj)
        {
            return TotalTime.CompareTo(((NascarRaceLap)obj).TotalTime);
        }
    }
}

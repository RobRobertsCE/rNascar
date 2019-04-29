using System;

namespace NascarApi.Simulation.Models
{
    public class NascarRaceLap : NascarLap, IComparable
    {
        public int VehicleId { get; set; }
        public int DriverId { get; set; }

        public int Position { get; set; }
        public int LeaderLap { get; set; }
        public int LapsSincePit { get; set; }
        public bool PitOutLap { get; set; }
        public bool PitInLap { get; set; }
        public bool IsLuckyDog { get; set; }

        public double Delta { get; set; }
        public double DeltaLeader { get; set; }

        public double DeltaPhysical { get; set; }
        public double DeltaTravelledLeader { get; set; }

        public double TotalTime { get; set; }
        public double AverageLapTime
        {
            get
            {
                return TotalTime / LapNumber;
            }
        }

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
            var lapNumberComparison = LapNumber.CompareTo(((NascarRaceLap)obj).LapNumber);

            if (lapNumberComparison != 0)
                return lapNumberComparison * -1;
            else
                return AverageLapTime.CompareTo(((NascarRaceLap)obj).AverageLapTime);
        }
    }
}

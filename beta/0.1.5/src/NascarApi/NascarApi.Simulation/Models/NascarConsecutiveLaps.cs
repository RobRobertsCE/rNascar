using System.Collections.Generic;
using System.Linq;

namespace NascarApi.Mock.Models
{
    public class NascarConsecutiveLaps
    {
        public int DriverId { get; set; }
        public int VehicleId { get; set; }
        public int StartLap
        {
            get
            {
                return Laps.Min(l => l.LapNumber);
            }
        }
        public int EndLap
        {
            get
            {
                return Laps.Max(l => l.LapNumber);
            }
        }
        public int LapCount
        {
            get
            {
                return Laps.Count;
            }
        }
        public double AverageLapSpeed
        {
            get
            {
                return Laps.Average(l => l.LapSpeed);
            }
        }
        public double AverageLapTime
        {
            get
            {
                return Laps.Average(l => l.LapTime);
            }
        }
        public double BestLapSpeed
        {
            get
            {
                return BestLap.LapSpeed;
            }
        }
        public double BestLapTime
        {
            get
            {
                return BestLap.LapTime;
            }
        }
        public double BestLapNumber
        {
            get
            {
                return BestLap.LapNumber;
            }
        }
        public NascarLap BestLap
        {
            get
            {
                return Laps.OrderBy(l => l.LapTime).FirstOrDefault();
            }
        }
        public IList<NascarLap> Laps { get; set; }
    }
}

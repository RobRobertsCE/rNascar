namespace rNascarTimingAndScoring.Models
{
    public class TSDriverModel
    {
        public int Position { get; set; }
        public string CarNumber { get; set; }
        public string Manufacturer { get; set; }
        public string Driver { get; set; }
        public double BehindLeader { get; set; }
        public double BehindNext { get; set; }
        public double LastLapTime { get; set; }
        public double FastestLapTime { get; set; }
        public double FastestLapNumber { get; set; }
        public int LapsComplete { get; set; }
        public int LastPitLap { get; set; }
        public int StartPosition { get; set; }
        public VehicleStatus VehicleStatus { get; set; }
        public bool IsOnTrack { get; set; }
        public bool FastestThisLap { get; set; }
        public bool IsUserFavorite { get; set; }
    }
}

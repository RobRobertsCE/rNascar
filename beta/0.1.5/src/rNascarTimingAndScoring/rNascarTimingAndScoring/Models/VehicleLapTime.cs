namespace rNascarTimingAndScoring.Models
{
    public class VehicleLapTime
    {
        public string CarNumber { get; set; }
        public string Driver { get; set; }
        public int LapNumber { get; set; }
        public TrackState TrackState { get; set; }
        public VehicleStatus VehicleStatus { get; set; }
        public double LapTime { get; set; }
        public double LapSpeed { get; set; }

        public override string ToString()
        {
            return $"Car {CarNumber} Lap {LapNumber} - {LapTime.ToString("#0.00")}";
        }
    }
}

namespace rNascarTimingAndScoring.Models
{
    public class NLapAverage
    {
        public string CarNumber { get; set; }
        public string Driver { get; set; }
        public int StartLap { get; set; }
        public int EndLap { get; set; }
        public double AverageLapTime { get; set; }
        public double AverageLapSpeed { get; set; }
        public bool HasEnoughLaps { get; set; } = true;

        public override string ToString()
        {
            return $"Car {CarNumber} {StartLap} - {EndLap} {AverageLapTime.ToString("#0.00")}";
        }
    }
}

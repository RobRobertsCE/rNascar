namespace NascarApi.Client.Models
{
    public class LapAverageModel
    {
        public string EventId { get; set; }
        public string CarNumber { get; set; }
        public string Driver { get; set; }
        public double AverageSpeed { get; set; }
        public double AverageTime { get; set; }
        public int LapCount { get; set; }
        public int StartLap { get; set; }
        public int EndLap { get; set; }
    }
}

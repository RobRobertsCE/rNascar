namespace NascarApi.Client.Models
{
    public class LapTimeModel
    {
        public string EventId { get; set; }
        public string CarNumber { get; set; }
        public string Driver { get; set; }
        public int LapNumber { get; set; }
        public double LapTime { get; set; }
        public double LapSpeed { get; set; }
    }
}

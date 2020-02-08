namespace NascarApi.Client.Dto
{
    public class LapAverageDto
    {
        public int Position { get; set; }
        public string CarNumber { get; set; }
        public string Driver { get; set; }
        public double AverageSpeed { get; set; }
        public double AverageTime { get; set; }
        public int StartLap { get; set; }
        public int EndLap { get; set; }
    }
}

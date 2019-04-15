namespace NascarApi.Client.Dto
{
    public class VehicleLapDto
    {
        public string CarNumber { get; set; }
        public string Driver { get; set; }
        public int LapNumber { get; set; }
        public double LapSpeed { get; set; }
        public double LapTime { get; set; }
    }
}

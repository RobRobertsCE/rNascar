namespace NascarApi.Mock.Models
{
    public class QualifyingResult : LapTimeResult
    {
        public int Position { get; set; }
        public int Round { get; set; }
        public int VehicleId { get; set; }
        public int DriverId { get; set; }
    }
}

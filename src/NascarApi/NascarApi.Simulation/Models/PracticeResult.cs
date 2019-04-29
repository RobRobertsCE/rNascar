namespace NascarApi.Simulation.Models
{
    public class PracticeResult : LapTimeResult
    {
        public int Position { get; set; }
        public int VehicleId { get; set; }
        public int DriverId { get; set; }
    }
}

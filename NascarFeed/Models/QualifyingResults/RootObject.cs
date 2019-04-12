namespace NascarFeed.Models.QualifyingResults
{
    public class RootObject
    {
        public int run_id { get; set; }
        public string car_number { get; set; }
        public int driver_id { get; set; }
        public int finishing_position { get; set; }
        public double best_lap_time { get; set; }
        public double best_lap_speed { get; set; }
        public int best_lap_number { get; set; }
        public int laps_completed { get; set; }
        public string comment { get; set; }
        public double delta_leader { get; set; }
        public string driver_name { get; set; }
        public string manufacturer { get; set; }
        public string sponsor { get; set; }
    }
}

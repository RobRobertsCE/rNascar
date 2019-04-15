namespace NascarApi.Models.LiveQualifyingData
{
    public class RootObject
    {
        public int run_id { get; set; }
        public int series_id { get; set; }
        public int qualifying_round { get; set; }
        public int position { get; set; }
        public string vehicle_number { get; set; }
        public int driver_id { get; set; }
        public string full_name { get; set; }
        public int laps_completed { get; set; }
        public int best_lap { get; set; }
        public double best_lap_time { get; set; }
        public double best_lap_speed { get; set; }
        public string comment { get; set; }
        public bool is_on_track { get; set; }
        public bool is_current_round { get; set; }
        public int time_limit { get; set; }
        public double last_lap_time { get; set; }
    }
}

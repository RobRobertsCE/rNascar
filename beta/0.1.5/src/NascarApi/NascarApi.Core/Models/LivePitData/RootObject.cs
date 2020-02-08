namespace NascarApi.Models.LivePitData
{
    public class RootObject
    {
        public string vehicle_number { get; set; }
        public string driver_name { get; set; }
        public string vehicle_manufacturer { get; set; }
        public int leader_lap { get; set; }
        public int lap_count { get; set; }
        public int pit_in_flag_status { get; set; }
        public int pit_out_flag_status { get; set; }
        public double pit_in_race_time { get; set; }
        public double pit_out_race_time { get; set; }
        public double total_duration { get; set; }
        public double box_stop_race_time { get; set; }
        public double box_leave_race_time { get; set; }
        public double pit_stop_duration { get; set; }
        public double in_travel_duration { get; set; }
        public double out_travel_duration { get; set; }
        public string pit_stop_type { get; set; }
        public bool left_front_tire_changed { get; set; }
        public bool left_rear_tire_changed { get; set; }
        public bool right_front_tire_changed { get; set; }
        public bool right_rear_tire_changed { get; set; }
        public int previous_lap_time { get; set; }
        public int next_lap_time { get; set; }
    }
}

using System.Collections.Generic;

namespace NascarApi.Client.Models
{
    public class Vehicle
    {
        public int average_restart_speed { get; set; }
        public int average_running_position { get; set; }
        public double average_speed { get; set; }
        public int best_lap { get; set; }
        public double best_lap_speed { get; set; }
        public double best_lap_time { get; set; }
        public string vehicle_manufacturer { get; set; }
        public string vehicle_number { get; set; }
        public Driver driver { get; set; }
        public double vehicle_elapsed_time { get; set; }
        public int fastest_laps_run { get; set; }
        public int laps_position_improved { get; set; }
        public int laps_completed { get; set; }
        public List<LapsLed> laps_led { get; set; }
        public double last_lap_speed { get; set; }
        public double last_lap_time { get; set; }
        public int passes_made { get; set; }
        public int passing_differential { get; set; }
        public int position_differential_last_10_percent { get; set; }
        public List<PitStop> pit_stops { get; set; }
        public int qualifying_status { get; set; }
        public int running_position { get; set; }
        public int status { get; set; }
        public double delta { get; set; }
        public string sponsor_name { get; set; }
        public int starting_position { get; set; }
        public int times_passed { get; set; }
        public int quality_passes { get; set; }
        public bool is_on_track { get; set; }
        public bool is_on_dvp { get; set; }
    }
}

using System.Collections.Generic;
using Newtonsoft.Json;

namespace NascarApi.Models.LiveFeed
{
    public class RootObject
    {
        public int lap_number { get; set; }
        public int elapsed_time { get; set; }
        public int flag_state { get; set; }
        public int race_id { get; set; }
        public int laps_in_race { get; set; }
        public int laps_to_go { get; set; }
        public List<Vehicle> vehicles { get; set; }
        public int run_id { get; set; }
        public string run_name { get; set; }
        public int series_id { get; set; }
        public int time_of_day { get; set; }
        public int track_id { get; set; }
        public double track_length { get; set; }
        public string track_name { get; set; }
        public int run_type { get; set; }
        public int number_of_caution_segments { get; set; }
        public int number_of_caution_laps { get; set; }
        public int number_of_lead_changes { get; set; }
        public int number_of_leaders { get; set; }
        public int avg_diff_1to3 { get; set; }
        public Stage stage { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

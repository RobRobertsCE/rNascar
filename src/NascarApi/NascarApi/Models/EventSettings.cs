using System;

namespace NascarApi.Models
{
    public class EventSettings
    {
        public int season { get; set; } = DateTime.Now.Year;
        public int series_id { get; set; }
        public int race_id { get; set; }
        public int run_type { get; set; }
        public int run_id { get; set; }
        public int track_id { get; set; }
        public double track_length { get; set; }
        public string run_name { get; set; }
    }
}

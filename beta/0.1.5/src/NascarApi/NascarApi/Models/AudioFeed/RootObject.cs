using System.Collections.Generic;

namespace NascarApi.Models.AudioFeed
{
    public class RootObject
    {
        public int historical_race_id { get; set; }
        public string race_name { get; set; }
        public int run_type { get; set; }
        public string track_name { get; set; }
        public int series_id { get; set; }
        public List<AudioConfig> audio_config { get; set; }
    }
}

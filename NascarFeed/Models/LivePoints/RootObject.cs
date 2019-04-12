namespace NascarFeed.Models.LivePoints
{
    public class RootObject
    {
        public int bonus_points { get; set; }
        public string car_number { get; set; }
        public int delta_leader { get; set; }
        public int delta_next { get; set; }
        public string first_name { get; set; }
        public int driver_id { get; set; }
        public bool is_in_chase { get; set; }
        public bool is_points_eligible { get; set; }
        public bool is_rookie { get; set; }
        public string last_name { get; set; }
        public int membership_id { get; set; }
        public int points { get; set; }
        public int points_position { get; set; }
        public int points_earned_this_race { get; set; }
        public int stage_1_points { get; set; }
        public bool stage_1_winner { get; set; }
        public int stage_2_points { get; set; }
        public bool stage_2_winner { get; set; }
        public int stage_3_points { get; set; }
        public bool stage_3_winner { get; set; }
        public object wins { get; set; }
        public object top_5 { get; set; }
        public object top_10 { get; set; }
        public object poles { get; set; }
        public int series_id { get; set; }
        public int race_id { get; set; }
        public int run_id { get; set; }
    }
}

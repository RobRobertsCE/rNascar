namespace NascarFeed.Models.PointStandings
{
    public class RootObject
    {
        public int position { get; set; }
        public string driver_name { get; set; }
        public int points { get; set; }
        public int playoff_points { get; set; }
        public int playoff_rank { get; set; }
        public int bonus_points { get; set; }
        public int delta_next { get; set; }
        public int delta_leader { get; set; }
        public int delta_leader_playoff { get; set; }
        public int delta_chase { get; set; }
        public int starts { get; set; }
        public int poles { get; set; }
        public int wins { get; set; }
        public int stage_1_wins { get; set; }
        public int stage_2_wins { get; set; }
        public int playoff_race_wins { get; set; }
        public int playoff_stage_wins { get; set; }
        public int top_5 { get; set; }
        public int top_10 { get; set; }
        public int laps_led { get; set; }
        public int dnf { get; set; }
        public double winnings { get; set; }
        public int driver_id { get; set; }
        public string driver_first_name { get; set; }
        public string driver_last_name { get; set; }
        public string driver_suffix { get; set; }
        public string car_no { get; set; }
        public string manufacturer { get; set; }
        public int? delta_playoff { get; set; }
        public int projected_playoff_points { get; set; }
        public int stage_points { get; set; }
    }
}

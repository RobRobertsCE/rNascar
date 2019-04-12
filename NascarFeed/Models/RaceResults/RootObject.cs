namespace NascarFeed.Models.RaceResults
{
    public class RootObject
    {
        public int result_id { get; set; }
        public int finishing_position { get; set; }
        public int starting_position { get; set; }
        public string car_number { get; set; }
        public string driver_fullname { get; set; }
        public int driver_id { get; set; }
        public string hometown_city { get; set; }
        public string hometown_state { get; set; }
        public int team_id { get; set; }
        public string team_name { get; set; }
        public int qualifying_order { get; set; }
        public int qualifying_position { get; set; }
        public int qualifying_speed { get; set; }
        public int laps_led { get; set; }
        public int times_led { get; set; }
        public string car_make { get; set; }
        public string car_model { get; set; }
        public string sponsor { get; set; }
        public int points_earned { get; set; }
        public int bonus_points_earned { get; set; }
        public int playoff_points_earned { get; set; }
        public int laps_completed { get; set; }
        public string finishing_status { get; set; }
        public int winnings { get; set; }
        public int series_id { get; set; }
        public int race_season { get; set; }
        public int race_id { get; set; }
        public string owner_fullname { get; set; }
        public string crew_chief_fullname { get; set; }
        public int points_position { get; set; }
        public int points_delta { get; set; }
        public int owner_id { get; set; }
        public string official_car_number { get; set; }
    }
}

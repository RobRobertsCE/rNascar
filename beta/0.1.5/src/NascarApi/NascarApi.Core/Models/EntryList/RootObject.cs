namespace NascarApi.Models.EntryList
{
    public class RootObject
    {
        public int driver_id { get; set; }
        public int crew_chief_id { get; set; }
        public int team_id { get; set; }
        public string vehicle_number { get; set; }
        public string driver_name { get; set; }
        public string driver_hometown { get; set; }
        public string owner_name { get; set; }
        public string team_name { get; set; }
        public string manufacturer { get; set; }
        public string sponsor { get; set; }
    }
}

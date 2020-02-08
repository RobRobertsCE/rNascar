namespace NascarApi.Models.LiveFlagData
{
    public class RootObject
    {
        public int lap_number { get; set; }
        public int flag_state { get; set; }
        public double elapsed_time { get; set; }
        public string comment { get; set; }
        public string beneficiary { get; set; }
        public double time_of_day { get; set; }
    }
}

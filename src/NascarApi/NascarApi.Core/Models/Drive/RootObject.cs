namespace NascarApi.Models.Drive
{
    public class RootObject
    {
        public Analytics analytics { get; set; }
        public Data data { get; set; }
        public bool live { get; set; }
        public Widgets widgets { get; set; }
        public Services services { get; set; }
    }
}

using System.Collections.Generic;

namespace NascarFeed.Models.Drive
{
    public class Video
    {
        public string id { get; set; }
        public string cameraType { get; set; }
        public string iconURL { get; set; }
        public Ima ima { get; set; }
        public string poster { get; set; }
        public string title { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string vehicleNumber { get; set; }
        public string streamType { get; set; }
        public bool is360 { get; set; }
        public List<Source> sources { get; set; }
    }
}

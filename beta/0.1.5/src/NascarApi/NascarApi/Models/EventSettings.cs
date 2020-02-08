using System;

namespace NascarApi.Models
{
    public class EventSettings
    {
        public int season { get; set; } = DateTime.Now.Year;
        public int seriesId { get; set; }
        public int eventId { get; set; }
        public int activityId { get; set; }
        public int sessionId { get; set; }
        public int trackId { get; set; }
        public double trackLength { get; set; }
    }
}

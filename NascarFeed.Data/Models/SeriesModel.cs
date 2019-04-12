using System.Collections.Generic;

namespace NascarFeed.Data.Models
{
    public class SeriesModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int year { get; set; }

        public IList<EventModel> seriesEvents { get; set; }

        public SeriesModel()
        {
            seriesEvents = new List<EventModel>();
        }
    }
}

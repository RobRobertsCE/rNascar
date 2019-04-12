using System.Collections.Generic;

namespace NascarFeed.Data.Models
{
    public class EventModel
    {
        public int id { get; set; }
        public int name { get; set; }
        public int sequence { get; set; }

        public IList<SessionModel> sessions { get; set; }

        public EventModel()
        {
            sessions = new List<SessionModel>();
        }
    }
}

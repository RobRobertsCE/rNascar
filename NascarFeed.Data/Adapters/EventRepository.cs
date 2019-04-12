using System.Collections.Generic;
using System.Linq;
using NascarFeed.Data.Models;
using NascarFeed.Data.Ports;

namespace NascarFeed.Data.Adapters
{
    class EventRepository : IEventRepository
    {
        private List<EventModel> _events = new List<EventModel>();

        public EventRepository()
        {

        }
        
        public EventModel GetEvent(int id)
        {
            return _events.FirstOrDefault(e => e.id == id);
        }
    }
}

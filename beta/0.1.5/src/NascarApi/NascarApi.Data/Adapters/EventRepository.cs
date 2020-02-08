using System.Collections.Generic;
using System.Linq;
using NascarApi.Data.Models;
using NascarApi.Data.Ports;

namespace NascarApi.Data.Adapters
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

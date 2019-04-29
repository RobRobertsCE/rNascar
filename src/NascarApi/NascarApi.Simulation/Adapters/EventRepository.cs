using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NascarApi.Simulation.Models;
using NascarApi.Simulation.Ports;

namespace NascarApi.Simulation.Adapters
{
    class EventRepository : IEventRepository
    {
        private IList<NascarEvent> _events = new List<NascarEvent>();

        public async Task<NascarEvent> Get(int eventId)
        {
            return await Task.FromResult(_events.FirstOrDefault(e => e.EventId == eventId));
        }

        public async Task<NascarEvent> Save(NascarEvent nascarEvent)
        {
            if (nascarEvent.EventId == 0)
            {
                nascarEvent.EventId = await GetNextEventId();
            }
            else
            {
                var existing = await Get(nascarEvent.EventId);

                if (existing != null)
                {
                    _events.Remove(existing);
                }
            }

            _events.Add(nascarEvent);

            return await Task.FromResult(nascarEvent);
        }

        public async Task<int> GetNextEventId()
        {
            int nextEventId = _events.Count == 0 ? 1 : _events.Max(e => e.EventId) + 1;

            return await Task.FromResult(nextEventId);
        }
    }
}

using System.Threading.Tasks;
using NascarApi.Simulation.Models;

namespace NascarApi.Simulation.Ports
{
    public interface IEventRepository
    {
        Task<NascarEvent> Get(int eventId);
        Task<NascarEvent> Save(NascarEvent nascarEvent);
        Task<int> GetNextEventId();
    }
}

using System.Threading.Tasks;
using NascarApi.Mock.Models;

namespace NascarApi.Mock.Ports
{
    public interface IEventRepository
    {
        Task<NascarEvent> Get(int eventId);
        Task<NascarEvent> Save(NascarEvent nascarEvent);
        Task<int> GetNextEventId();
    }
}

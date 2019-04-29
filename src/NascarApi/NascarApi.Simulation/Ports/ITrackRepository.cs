using System.Collections.Generic;
using System.Threading.Tasks;
using NascarApi.Simulation.Models;

namespace NascarApi.Simulation.Ports
{
    public interface ITrackRepository
    {
        Task<NascarTrack> GetAsync(int eventId);
        Task<IEnumerable<NascarTrack>> GetListAsync();
        Task<NascarTrack> SaveAsync(NascarTrack item);
    }
}

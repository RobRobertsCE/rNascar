using System.Collections.Generic;
using System.Threading.Tasks;
using NascarApi.Mock.Models;

namespace NascarApi.Mock.Ports
{
    public interface ITrackRepository
    {
        Task<NascarTrack> GetAsync(int eventId);
        Task<IEnumerable<NascarTrack>> GetListAsync();
        Task<NascarTrack> SaveAsync(NascarTrack item);
    }
}

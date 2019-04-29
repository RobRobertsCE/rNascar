using System.Collections.Generic;
using System.Threading.Tasks;
using NascarApi.Simulation.Models;

namespace NascarApi.Simulation.Ports
{
    public interface IDriverRepository
    {
        Task<NascarDriver> GetAsync(int eventId);
        Task<IEnumerable<NascarDriver>> GetListAsync();
        Task<NascarDriver> SaveAsync(NascarDriver item);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using NascarApi.Simulation.Models;

namespace NascarApi.Simulation.Ports
{
    public interface ISeriesRepository
    {

        Task<NascarSeries> GetAsync(int eventId);
        Task<IEnumerable<NascarSeries>> GetListAsync();
        Task<NascarSeries> SaveAsync(NascarSeries item);
    }
}

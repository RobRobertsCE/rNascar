using System.Collections.Generic;
using System.Threading.Tasks;
using NascarApi.Mock.Models;

namespace NascarApi.Mock.Ports
{
    public interface ISeriesRepository
    {

        Task<NascarSeries> GetAsync(int eventId);
        Task<IEnumerable<NascarSeries>> GetListAsync();
        Task<NascarSeries> SaveAsync(NascarSeries item);
    }
}

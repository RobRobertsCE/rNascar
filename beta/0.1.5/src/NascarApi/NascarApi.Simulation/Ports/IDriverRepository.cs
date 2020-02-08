using System.Collections.Generic;
using System.Threading.Tasks;
using NascarApi.Mock.Models;

namespace NascarApi.Mock.Ports
{
    public interface IDriverRepository
    {
        Task<NascarDriver> GetAsync(int eventId);
        Task<IEnumerable<NascarDriver>> GetListAsync();
        Task<NascarDriver> SaveAsync(NascarDriver item);
    }
}

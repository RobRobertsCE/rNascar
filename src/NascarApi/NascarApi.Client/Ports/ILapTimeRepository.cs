using System.Collections.Generic;
using System.Threading.Tasks;
using NascarApi.Client.Models;

namespace NascarApi.Client.Ports
{
    public interface ILapTimeRepository
    {
        Task<bool> InsertAsync(LapTimeModel model);
        Task<IEnumerable<LapTimeModel>> GetListAsync(string eventId, string carNumber = null);
        Task<LapTimeModel> GetAsync(string eventId, string carNumber, int lapNumber);
    }
}

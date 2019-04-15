using System.Collections.Generic;
using System.Threading.Tasks;
using NascarApi.Client.Dto;
using NascarApi.Client.Models;

namespace NascarApi.Client.Ports
{
    public interface ILapTimeService
    {
        Task<bool> InsertAsync(LapTimeModel model);

        Task<IEnumerable<VehicleLapDto>> GetVehicleLapTimes(string eventId, string carNumber);

        Task<IEnumerable<LapAverageDto>> GetFastest10LapAverages(string eventId);
        Task<IEnumerable<LapAverageDto>> GetFastest20LapAverages(string eventId);

        Task<IEnumerable<LapAverageDto>> GetLast10LapAverages(string eventId);
        Task<IEnumerable<LapAverageDto>> GetLast20LapAverages(string eventId);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NascarApi.Client.Dto;
using NascarApi.Client.Models;
using NascarApi.Client.Ports;

namespace NascarApi.Client.Adapters
{
    public class LapTimeService : ILapTimeService
    {
        #region fields

        private readonly ILapTimeRepository _lapTimeRepository;

        #endregion

        #region ctor

        public LapTimeService(ILapTimeRepository lapTimeRepository)
        {
            _lapTimeRepository = lapTimeRepository ?? throw new ArgumentNullException(nameof(lapTimeRepository));
        }

        #endregion

        #region public

        public async Task<IEnumerable<VehicleLapDto>> GetVehicleLapTimes(string eventId, string carNumber)
        {
            try
            {
                var models = await _lapTimeRepository.GetListAsync(eventId, carNumber);

                return models.Select(m => new VehicleLapDto()
                {
                    CarNumber = m.CarNumber,
                    Driver = m.Driver,
                    LapNumber = m.LapNumber,
                    LapTime = m.LapTime,
                    LapSpeed = m.LapSpeed
                }).OrderBy(l => l.LapNumber);
            }
            catch (Exception ex)
            {
                return await Task.FromException<IEnumerable<VehicleLapDto>>(ex);
            }
        }

        public async Task<IEnumerable<LapAverageDto>> GetFastest10LapAverages(string eventId)
        {
            try
            {
                var models = await _lapTimeRepository.GetListAsync(eventId);

                return models.Select(m => new LapAverageDto()
                {
                    CarNumber = m.CarNumber,
                    Driver = m.Driver,
                    StartLap = 0,
                    EndLap = 0,
                    AverageSpeed = 0.0,
                    AverageTime = 0.0
                }).OrderBy(l => l.AverageTime);
            }
            catch (Exception ex)
            {
                return await Task.FromException<IEnumerable<LapAverageDto>>(ex);
            }
        }

        public async Task<IEnumerable<LapAverageDto>> GetFastest20LapAverages(string eventId)
        {
            try
            {
                var models = await _lapTimeRepository.GetListAsync(eventId);

                return models.Select(m => new LapAverageDto()
                {
                    CarNumber = m.CarNumber,
                    Driver = m.Driver,
                    StartLap = 0,
                    EndLap = 0,
                    AverageSpeed = 0.0,
                    AverageTime = 0.0
                }).OrderBy(l => l.AverageTime);
            }
            catch (Exception ex)
            {
                return await Task.FromException<IEnumerable<LapAverageDto>>(ex);
            }
        }

        public async Task<IEnumerable<LapAverageDto>> GetLast10LapAverages(string eventId)
        {
            try
            {
                var models = await _lapTimeRepository.GetListAsync(eventId);

                return models.Select(m => new LapAverageDto()
                {
                    CarNumber = m.CarNumber,
                    Driver = m.Driver,
                    StartLap = 0,
                    EndLap = 0,
                    AverageSpeed = 0.0,
                    AverageTime = 0.0
                }).OrderBy(l => l.AverageTime);
            }
            catch (Exception ex)
            {
                return await Task.FromException<IEnumerable<LapAverageDto>>(ex);
            }
        }

        public async Task<IEnumerable<LapAverageDto>> GetLast20LapAverages(string eventId)
        {
            try
            {
                var models = await _lapTimeRepository.GetListAsync(eventId);

                return models.Select(m => new LapAverageDto()
                {
                    CarNumber = m.CarNumber,
                    Driver = m.Driver,
                    StartLap = 0,
                    EndLap = 0,
                    AverageSpeed = 0.0,
                    AverageTime = 0.0
                }).OrderBy(l => l.AverageTime);
            }
            catch (Exception ex)
            {
                return await Task.FromException<IEnumerable<LapAverageDto>>(ex);
            }
        }

        public async Task<bool> InsertAsync(LapTimeModel model)
        {
            return await _lapTimeRepository.InsertAsync(model);
        }

        #endregion
    }
}

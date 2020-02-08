using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NascarApi.Mock.Models;
using NascarApi.Mock.Ports;
using NascarApi.Mock.Extensions;
using NascarApi.Mock.Internal;

namespace NascarApi.Mock.Adapters
{
    class EventGenerator : IEventGenerator
    {
        #region fields

        private readonly IEventRepository _eventRepository;
        private readonly ITrackRepository _trackRepository;
        private readonly IDriverRepository _driverRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ISeriesRepository _seriesRepository;
        private Random _random = new Random(DateTime.Now.Millisecond);

        #endregion

        #region ctor

        public EventGenerator(
            IEventRepository eventRepository,
            ITrackRepository trackRepository,
            IDriverRepository driverRepository,
            IVehicleRepository vehicleRepository,
            ISeriesRepository seriesRepository)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
            _trackRepository = trackRepository ?? throw new ArgumentNullException(nameof(trackRepository));
            _driverRepository = driverRepository ?? throw new ArgumentNullException(nameof(driverRepository));
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
            _seriesRepository = seriesRepository ?? throw new ArgumentNullException(nameof(seriesRepository));
        }

        #endregion

        #region public 

        public async Task<NascarEvent> GenerateEventAsync(int trackId, NascarSeries series)
        {
            var tracksRepo = new TrackRepository();
            var track = await tracksRepo.GetAsync(trackId);

            return await GenerateEventAsync(track, series);
        }

        public async Task<NascarEvent> GenerateEventAsync(NascarTrack track, NascarSeries series)
        {
            try
            {
                var vehicles = await _vehicleRepository.GetListAsync();

                var newEvent = new NascarEvent(track, series, vehicles.Take(50).ToList());

                newEvent = await _eventRepository.Save(newEvent);

                return newEvent;
            }
            catch (Exception ex)
            {
                return await Task.FromException<NascarEvent>(ex);
            }
        }

        #endregion
    }
}

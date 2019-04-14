using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using NascarFeed.Ports;
using rNascarTimingAndScoring.Models;

namespace rNascarTimingAndScoring.ViewModels
{
    public class RaceViewModel : ViewModelBase, IRaceViewModel
    {
        #region properties

        public BindingList<TSDriverModel> LeaderboardModels { get; set; } = new BindingList<TSDriverModel>();
        public BindingList<TSGridRowModel> TenLapAverageModels { get; set; } = new BindingList<TSGridRowModel>();
        public BindingList<TSGridRowModel> LapLeaderModels { get; set; } = new BindingList<TSGridRowModel>();
        public BindingList<TSGridRowModel> FastestLapModels { get; set; } = new BindingList<TSGridRowModel>();
        public BindingList<TSGridRowModel> BiggestMoverModels { get; set; } = new BindingList<TSGridRowModel>();
        public BindingList<TSGridRowModel> OffThePaceModels { get; set; } = new BindingList<TSGridRowModel>();
        public BindingList<TSGridRowModel> PointStandingsModels { get; set; } = new BindingList<TSGridRowModel>();

        #endregion

        #region ctor

        public RaceViewModel(IApiClient apiClient)
            : base(apiClient)
        {

        }

        #endregion

        #region public

        public override async Task UpdateFeedDataAsync()
        {
            var liveFeedData = await GetLiveFeedAsync();

            LeaderboardModels = new BindingList<TSDriverModel>(FormatLeaderboardData(liveFeedData));
            LapLeaderModels = new BindingList<TSGridRowModel>(FormatLapLeaders(liveFeedData));
            FastestLapModels = new BindingList<TSGridRowModel>(FormatFastestLapData(liveFeedData));
            BiggestMoverModels = new BindingList<TSGridRowModel>(FormatBiggestMoversData(liveFeedData));
            OffThePaceModels = new BindingList<TSGridRowModel>(FormatOffThePaceData(liveFeedData));

            var pointsFeed = await GetPointsFeedAsync();

            PointStandingsModels = new BindingList<TSGridRowModel>(FormatPointsData(pointsFeed));

            var lapAverageFeed = await GetLapAverageFeedAsync();

            TenLapAverageModels = new BindingList<TSGridRowModel>(FormatTenLapAverages(lapAverageFeed));

            Console.WriteLine(TenLapAverageModels.RaiseListChangedEvents.ToString());
        }

        #endregion

        #region protected

        protected virtual IList<TSGridRowModel> FormatLapLeaders(NascarFeed.Models.LiveFeed.RootObject feedData)
        {
            var models = new List<TSGridRowModel>();

            foreach (var vehicle in feedData.vehicles.Where(v => v.laps_led.Count > 0))
            {
                var model = new TSLapLeaderGridRowModel()
                {
                    CarNumber = vehicle.vehicle_number,
                    Driver = vehicle.driver.full_name,
                    TotalLapsLed = vehicle.laps_led.Sum(l => l.end_lap - l.start_lap),
                    TotalTimesLed = vehicle.laps_led.Count
                };

                model.Value = $"{model.TotalLapsLed} laps ({model.TotalTimesLed}x)";

                models.Add(model);
            }

            var sortedModels = models.OrderByDescending(m => ((TSLapLeaderGridRowModel)m).TotalLapsLed).ToList();

            for (int i = 0; i < models.Count; i++)
            {
                sortedModels[i].Index = i;
            }

            return sortedModels;
        }

        protected virtual IList<TSGridRowModel> FormatTenLapAverages(NascarFeed.Models.LapAverage.RootObject feedData)
        {
            var models = new List<TSGridRowModel>();

            if (feedData.TenLapAverage != null)
            {
                foreach (var average in feedData.TenLapAverage.OrderBy(a => a.pos))
                {
                    var model = new TSTenLapAverageGridRowModel()
                    {
                        Index = Int32.Parse(average.pos),
                        CarNumber = average.carNumber,
                        Driver = average.dName,
                        TenLapAverage = average.lapSpeedAverage
                    };

                    model.Value = $"{average.lapSpeedAverage} ({average.fromLap}-{average.toLap})";

                    models.Add(model);
                }
            }

            var sortedModels = models.OrderByDescending(m => ((TSLapLeaderGridRowModel)m).TotalLapsLed).ToList();

            for (int i = 0; i < models.Count; i++)
            {
                sortedModels[i].Index = i;
            }

            return sortedModels;
        }

        protected virtual IList<TSDriverModel> FormatLeaderboardData(NascarFeed.Models.LiveFeed.RootObject feedData)
        {
            double previousDelta = 0.0;

            var models = new List<TSDriverModel>();

            foreach (var vehicle in feedData.vehicles)
            {
                var model = new TSDriverModel()
                {
                    Position = vehicle.running_position,
                    CarNumber = vehicle.vehicle_number,
                    Driver = vehicle.driver.full_name,
                    BehindLeader = vehicle.delta,
                    Manufacturer = vehicle.vehicle_manufacturer,
                    StartPosition = vehicle.starting_position,
                    LastLapTime = vehicle.last_lap_time,
                    FastestLapTime = vehicle.best_lap_time,
                    FastestLapNumber = vehicle.best_lap,
                    LastPitLap = vehicle.pit_stops.Count > 0 ? vehicle.pit_stops.LastOrDefault().pit_in_leader_lap : 0,
                    LapsComplete = vehicle.laps_completed,
                    BehindNext = vehicle.delta < 0 ?
                        previousDelta < 0 ?
                            vehicle.delta - previousDelta :
                            vehicle.delta :
                        vehicle.delta - previousDelta
                };

                models.Add(model);

                previousDelta = vehicle.delta;
            }

            return models;
        }

        protected virtual IList<TSGridRowModel> FormatBiggestMoversData(NascarFeed.Models.LiveFeed.RootObject feedData)
        {
            var models = new List<TSGridRowModel>();

            var vehicleGains = feedData.vehicles.Select(v => new
            {
                CarNumber = v.vehicle_number,
                Driver = v.driver.full_name,
                Gain = v.position_differential_last_10_percent
            });

            int index = 0;

            foreach (var vehicle in vehicleGains.OrderByDescending(v => v.Gain).Take(8))
            {
                var model = new TSGridRowModel()
                {
                    Index = index,
                    CarNumber = vehicle.CarNumber,
                    Driver = vehicle.Driver,
                    Value = vehicle.Gain.ToString()
                };

                models.Add(model);

                index++;
            }

            return models;
        }

        protected virtual IList<TSGridRowModel> FormatOffThePaceData(NascarFeed.Models.LiveFeed.RootObject feedData)
        {
            var models = new List<TSGridRowModel>();

            var vehicleGains = feedData.vehicles.
                Where(v => v.status == 1). // Status 1=running, 2=off track, 3=out of event?
                Select(v => new
                {
                    CarNumber = v.vehicle_number,
                    Driver = v.driver.full_name,
                    Gain = v.position_differential_last_10_percent
                });

            int index = 0;

            foreach (var vehicle in vehicleGains.OrderBy(v => v.Gain).Take(8))
            {
                var model = new TSGridRowModel()
                {
                    Index = index,
                    CarNumber = vehicle.CarNumber,
                    Driver = vehicle.Driver,
                    Value = vehicle.Gain.ToString()
                };

                models.Add(model);

                index++;
            }

            return models;
        }

        protected virtual IList<TSGridRowModel> FormatFastestLapData(NascarFeed.Models.LiveFeed.RootObject feedData)
        {
            var models = new List<TSGridRowModel>();

            var vehicleGains = feedData.vehicles.
                Select(v => new
                {
                    CarNumber = v.vehicle_number,
                    Driver = v.driver.full_name,
                    FastestLap = v.best_lap_speed
                });

            int index = 0;

            foreach (var vehicle in vehicleGains.OrderByDescending(v => v.FastestLap))
            {
                var model = new TSGridRowModel()
                {
                    Index = index,
                    CarNumber = vehicle.CarNumber,
                    Driver = vehicle.Driver,
                    Value = vehicle.FastestLap.ToString("###.##")
                };

                models.Add(model);

                index++;
            }

            return models;
        }

        protected virtual IList<TSGridRowModel> FormatPointsData(IList<NascarFeed.Models.LivePoints.RootObject> feedData)
        {
            var models = new List<TSGridRowModel>();

            int index = 0;

            foreach (var driverPoints in feedData.OrderByDescending(v => v.points))
            {
                var model = new TSGridRowModel()
                {
                    Index = index,
                    CarNumber = driverPoints.car_number,
                    Driver = $"{driverPoints.first_name} {driverPoints.last_name}",
                    Value = driverPoints.points.ToString()
                };

                models.Add(model);

                index++;
            }

            return models;
        }

        protected virtual async Task<NascarFeed.Models.LiveFeed.RootObject> GetLiveFeedAsync()
        {
            return await ApiClient.GetLiveFeedAsync();
        }

        protected virtual async Task<IList<NascarFeed.Models.LivePoints.RootObject>> GetPointsFeedAsync()
        {
            return await ApiClient.GetLivePointsAsync(EventSettings);
        }

        protected virtual async Task<NascarFeed.Models.LapAverage.RootObject> GetLapAverageFeedAsync()
        {
            return await ApiClient.GetLapAveragesAsync(EventSettings);
        }

        #endregion
    }
}

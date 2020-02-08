using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NascarApi.Mock.Internal;
using NascarApi.Mock.Models;
using NascarApi.Mock.Ports;

namespace NascarApi.Mock.Adapters
{
    class PracticeSimulator : IPracticeSimulator
    {
        #region fields

        private LapTimeService _lapTimeService;

        #endregion

        #region public

        public async virtual Task<NascarEvent> SimulatePracticeAsync(NascarEvent raceEvent)
        {
            _lapTimeService = new LapTimeService(raceEvent.Track);

            NascarPracticeRun p1 = raceEvent.Runs.OfType<NascarPracticeRun>().FirstOrDefault(r => r.RunType == NascarRunType.Practice1);
            if (p1 != null)
            {
                p1.Vehicles = raceEvent.Vehicles;
                SimulatePracticeRun(p1);
                PopulateResults(p1);
            }

            NascarPracticeRun p2 = raceEvent.Runs.OfType<NascarPracticeRun>().FirstOrDefault(r => r.RunType == NascarRunType.Practice2);
            if (p2 != null)
            {
                p2.Vehicles.Clear();
                p2.Vehicles = raceEvent.Vehicles;
                SimulatePracticeRun(p2);
                PopulateResults(p2);
            }

            NascarPracticeRun p3 = raceEvent.Runs.OfType<NascarPracticeRun>().FirstOrDefault(r => r.RunType == NascarRunType.FinalPractice);
            if (p3 != null)
            {
                p3.Vehicles.Clear(); ;
                p3.Vehicles = raceEvent.Vehicles;
                SimulatePracticeRun(p3);
                PopulateResults(p3);
            }

            return await Task.FromResult(raceEvent);
        }

        #endregion

        #region protected

        protected virtual void PopulateResults(NascarPracticeRun pRun)
        {
            var results = pRun.ConsecutiveLaps
                  .GroupBy(g => new { g.VehicleId, g.DriverId })
                  .Select((item, index) => new { item, index })
                  .Select(g => new PracticeResult()
                  {
                      Position = g.index,
                      VehicleId = g.item.Key.VehicleId,
                      DriverId = g.item.Key.DriverId,
                      LapTime = g.item.Min(l => l.BestLap.LapTime),
                      LapSpeed = g.item.Max(l => l.BestLap.LapSpeed)
                  })
                  .ToList();

            var orderedResults = results.OrderBy(r => r.LapTime);

            int i = 1;
            foreach (PracticeResult result in orderedResults)
            {
                result.Position = i;
                i++;
            }

            pRun.Results = orderedResults.ToList();

            PrintResults(pRun);
        }


        protected virtual void SimulatePracticeRun(NascarPracticeRun run)
        {
            Console.WriteLine($"Simulating {run.RunType.ToString()} for series {run.SeriesId}");

            var timesOnTrack = 3;

            foreach (NascarVehicle vehicle in run.Vehicles)
            {
                int lapNumber = 0;

                for (int i = 0; i < timesOnTrack; i++)
                {
                    var laps = new NascarConsecutiveLaps()
                    {
                        VehicleId = vehicle.VehicleId,
                        Laps = GetLaps(lapNumber + 1)
                    };

                    run.ConsecutiveLaps.Add(laps);

                    lapNumber = laps.Laps.Max(l => l.LapNumber);
                }
            }
        }

        protected virtual IList<NascarLap> GetLaps(int startingLapNumber)
        {
            IList<NascarLap> laps = new List<NascarLap>();

            var lapCount = 5;

            for (int i = startingLapNumber; i < (lapCount + startingLapNumber); i++)
            {
                var lapTimeResult = _lapTimeService.GetLapTime();

                laps.Add(new NascarLap()
                {
                    LapNumber = i,
                    LapTime = lapTimeResult.LapTime,
                    LapSpeed = lapTimeResult.LapSpeed
                });
            }

            return laps;
        }

        #endregion

        #region private

        private void PrintResults(NascarPracticeRun run)
        {
            Console.WriteLine($" Practice Round {run.Round} Results");

            foreach (PracticeResult result in run.Results.OrderBy(r => r.Position))
            {
                Console.WriteLine($"{result.Position} Car# {result.VehicleId} {result.LapTime} {result.LapSpeed}");
            }

            Console.WriteLine();
        }

        #endregion
    }
}

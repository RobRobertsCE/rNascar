using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NascarApi.Simulation.Internal;
using NascarApi.Simulation.Models;
using NascarApi.Simulation.Ports;

namespace NascarApi.Simulation.Adapters
{
    class QualifyingSimulator : IQualifyingSimulator
    {
        #region fields

        private LapTimeService _lapTimeService;

        #endregion

        #region public

        public async virtual Task<NascarEvent> SimulateQualifyingAsync(NascarEvent raceEvent)
        {
            _lapTimeService = new LapTimeService(raceEvent.Track);

            NascarQualifyingRun q1 = raceEvent.Runs.OfType<NascarQualifyingRun>().FirstOrDefault(r => r.RunType == NascarRunType.QualifyingStage1);
            if (q1 != null)
            {
                q1.Vehicles = raceEvent.Vehicles;
                SimulateQualifyingRun(q1);
                PopulateResults(q1, raceEvent.Series.QualifyingRound1Count.Value);
            }

            NascarQualifyingRun q2 = raceEvent.Runs.OfType<NascarQualifyingRun>().FirstOrDefault(r => r.RunType == NascarRunType.QualifyingStage2);
            if (q2 != null)
            {
                q2.Vehicles.Clear();
                foreach (QualifyingResult result in q1.Results.OrderBy(r => r.Position).Take(raceEvent.Series.QualifyingRound2Count.Value))
                {
                    q2.Vehicles.Add(new NascarVehicle()
                    {
                        DriverId = result.DriverId,
                        VehicleId = result.VehicleId
                    });
                }
                SimulateQualifyingRun(q2);
                PopulateResults(q2, raceEvent.Series.QualifyingRound2Count.Value);
            }

            NascarQualifyingRun q3 = raceEvent.Runs.OfType<NascarQualifyingRun>().FirstOrDefault(r => r.RunType == NascarRunType.FinalQualifyingStage);
            if (q3 != null)
            {
                q3.Vehicles.Clear();
                foreach (QualifyingResult result in q2.Results.OrderBy(r => r.Position).Take(raceEvent.Series.QualifyingFinalRoundCount))
                {
                    q3.Vehicles.Add(new NascarVehicle()
                    {
                        DriverId = result.DriverId,
                        VehicleId = result.VehicleId
                    });
                }
                SimulateQualifyingRun(q3);
                PopulateResults(q3, raceEvent.Series.QualifyingFinalRoundCount);
            }

            ((List<QualifyingResult>)raceEvent.QualifyingResults).AddRange(q1.Results.OrderBy(r => r.Position).Skip(raceEvent.Series.QualifyingRound2Count.Value));
            ((List<QualifyingResult>)raceEvent.QualifyingResults).AddRange(q2.Results.OrderBy(r => r.Position).Skip(raceEvent.Series.QualifyingFinalRoundCount));
            ((List<QualifyingResult>)raceEvent.QualifyingResults).AddRange(q3.Results.OrderBy(r => r.Position).Take(raceEvent.Series.QualifyingRound1Count.Value));

            PrintQualifyingResults(raceEvent);

            return await Task.FromResult(raceEvent);
        }

        #endregion

        #region protected

        protected virtual void PopulateResults(NascarQualifyingRun qRun, int count)
        {
            var results = qRun.ConsecutiveLaps
                  .GroupBy(g => new { g.VehicleId, g.DriverId })
                  .Select((item, index) => new { item, index })
                  .Select(g => new QualifyingResult()
                  {
                      Position = g.index,
                      Round = qRun.Round,
                      VehicleId = g.item.Key.VehicleId,
                      DriverId = g.item.Key.DriverId,
                      LapTime = g.item.Min(l => l.BestLap.LapTime),
                      LapSpeed = g.item.Max(l => l.BestLap.LapSpeed)
                  })
                  .ToList();

            var orderedResults = results.OrderBy(r => r.LapTime).Take(count);

            int i = 1;
            foreach (QualifyingResult qResult in orderedResults)
            {
                qResult.Position = i;
                i++;
            }

            qRun.Results = orderedResults.ToList();

            PrintRoundResults(qRun);
        }

        protected virtual void SimulateQualifyingRun(NascarQualifyingRun run)
        {
            Console.WriteLine($"Simulating {run.RunType.ToString()} for series {run.SeriesId}");

            var timesOnTrack = 1;

            foreach (NascarVehicle vehicle in run.Vehicles)
            {
                int lapNumber = 0;

                for (int i = 0; i < timesOnTrack; i++)
                {
                    var laps = new NascarConsecutiveLaps()
                    {
                        DriverId = vehicle.DriverId,
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

        private void PrintRoundResults(NascarQualifyingRun qrun)
        {
            Console.WriteLine($" Qualifying Round {qrun.Round} Results");

            foreach (QualifyingResult q in qrun.Results.OrderBy(r => r.Position))
            {
                Console.WriteLine($"{q.Position} Car# {q.VehicleId} {q.LapTime} {q.LapSpeed}");
            }

            Console.WriteLine();
        }

        private void PrintQualifyingResults(NascarEvent qEvent)
        {
            Console.WriteLine($"*** Event Qualifying Results ***");

            foreach (QualifyingResult q in qEvent.QualifyingResults.OrderBy(r => r.Position))
            {
                Console.WriteLine($"{q.Position} Car# {q.VehicleId} {q.LapTime} {q.LapSpeed} {q.Round}");
            }

            Console.WriteLine();
        }

        #endregion
    }
}

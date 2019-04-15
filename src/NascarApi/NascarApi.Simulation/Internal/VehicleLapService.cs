using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NascarApi.Mock.Models;

namespace NascarApi.Mock.Internal
{
    public class VehicleLapService
    {
        #region fields

        private readonly NascarEvent _raceEvent;
        private readonly LapTimeService _lapTimeService;
        private readonly Random _pitRandom = new Random(DateTime.Now.Millisecond);
        private readonly int _baseLapTime;

        #endregion

        #region ctor

        public VehicleLapService(NascarEvent raceEvent)
        {
            _raceEvent = raceEvent ?? throw new ArgumentNullException(nameof(raceEvent));

            if (raceEvent.Track == null)
                throw new ArgumentNullException(nameof(raceEvent.Track));

            _baseLapTime = raceEvent.Track.BaseLapTime;

            _lapTimeService = new LapTimeService(raceEvent.Track);
        }

        #endregion

        #region public

        public List<NascarRaceLap> GetStartingLineup(NascarEvent raceEvent, NascarRaceRun stage1)
        {
            return StartingLineup(raceEvent, stage1);
        }

        public List<NascarRaceLap> UpdateRaceLaps(List<NascarRaceLap> lastLaps, VehicleLapState state)
        {
            List<NascarRaceLap> newLaps = null;

            switch (state)
            {
                case VehicleLapState.OneToGreenFlag:
                    {
                        newLaps = OneToGoLaps(lastLaps);
                        break;
                    }
                case VehicleLapState.GreenFlag:
                    {
                        newLaps = GreenFlagLaps(lastLaps);
                        break;
                    }
                case VehicleLapState.CautionFlag:
                    {
                        newLaps = CautionLaps(lastLaps);
                        break;
                    }
                default:
                    {
                        throw new ArgumentException($"Invalid VehicleLapState: {state.ToString()}");
                    }
            }

            PrintStandings(newLaps, state == VehicleLapState.CautionFlag, state == VehicleLapState.OneToGreenFlag);

            return newLaps;
        }

        #endregion

        #region protected

        protected virtual NascarRaceLap[] GetNewRaceLaps(List<NascarRaceLap> lastLaps, VehicleLapState state)
        {
            NascarRaceLap[] newLaps = lastLaps.Select(l => new NascarRaceLap()
            {
                Position = l.Position,
                DriverId = l.DriverId,
                VehicleId = l.VehicleId,
                TotalTime = l.TotalTime,
                LapNumber = l.LapNumber,
                LapsSincePit = l.LapsSincePit,
                PitThisLap = l.PitThisLap,
                IsLuckyDog = l.IsLuckyDog,
                LeaderLap = l.LeaderLap
            }).ToArray();

            LapTimeResult lapTimeResult = null;
            for (int i = 0; i < newLaps.Length; i++)
            {
                if (newLaps[i].PitThisLap)
                {
                    lapTimeResult = _lapTimeService.GetPitLapTime();
                    newLaps[i].LapsSincePit = -1;
                    newLaps[i].PitThisLap = false;
                }
                else if (state == VehicleLapState.CautionFlag || state == VehicleLapState.OneToGreenFlag)
                {
                    lapTimeResult = _lapTimeService.GetCautionLapTime();
                }
                else if (state == VehicleLapState.GreenFlag)
                {
                    lapTimeResult = _lapTimeService.GetLapTime(newLaps[i].LapsSincePit);
                }

                newLaps[i].LapTime = lapTimeResult.LapTime;
                newLaps[i].LapSpeed = lapTimeResult.LapSpeed;
                newLaps[i].TotalTime += lapTimeResult.LapTime;
                newLaps[i].LapNumber += 1;
                newLaps[i].LeaderLap += 1;
                newLaps[i].LapsSincePit += 1;
            }

            Array.Sort(newLaps);

            if (newLaps[0].LapsBehind > 0)
            {
                for (int i = 0; i < newLaps.Length; i++)
                {
                    newLaps[i].LapNumber += newLaps[0].LapsBehind;
                }
            }

            return newLaps;
        }

        protected virtual List<NascarRaceLap> OneToGoLaps(List<NascarRaceLap> lastLaps)
        {
            NascarRaceLap[] newLaps = GetNewRaceLaps(lastLaps, VehicleLapState.OneToGreenFlag);

            newLaps[0].Position = 1;
            newLaps[0].Delta = 0;
            newLaps[0].DeltaLeader = 0;

            int leaderLapNumber = newLaps[0].LapNumber;
            double leaderTotalTime = newLaps[0].TotalTime;

            for (int i = 1; i < newLaps.Length; i++)
            {
                newLaps[i].Position = i + 1;

                double deltaLeader = newLaps[i].TotalTime - leaderTotalTime;
                int deltaLaps = (int)(deltaLeader / _baseLapTime);

                if (deltaLaps >= 1)
                {
                    // vehicle is laps down
                    newLaps[i].Delta = deltaLaps * -1;
                    newLaps[i].DeltaLeader = deltaLaps * -1;
                    newLaps[i].LapNumber = leaderLapNumber - deltaLaps;
                }
                else
                {
                    // vehicle is on lead lap
                    newLaps[i].Delta = newLaps[i].TotalTime - newLaps[i - 1].TotalTime;
                    newLaps[i].DeltaLeader = newLaps[i].TotalTime - leaderTotalTime;
                    newLaps[i].LapNumber = leaderLapNumber;
                }
            }

            var luckyDog = newLaps.FirstOrDefault(l => l.IsLuckyDog);

            if (luckyDog != null)
            {
                var lastCarOnLeadLap = newLaps.Where(l => l.IsLeadLap).OrderByDescending(l => l.Position).LastOrDefault();
                var luckyDogTimeDelta = luckyDog.TotalTime - lastCarOnLeadLap.TotalTime;

                luckyDog.TotalTime -= (luckyDogTimeDelta + .001);
                luckyDog.LapTime -= luckyDogTimeDelta;
                luckyDog.LapNumber += 1;
                luckyDog.IsLuckyDog = false;
            }

            // close 'em up
            double cumulativeDeltaLeader = 0.0;
            double spacingBetweenRows = 0.5;
            for (int i = 1; i < newLaps.Length; i++)
            {
                int rowNumber = (int)i / 2;

                if (newLaps[i].IsLeadLap)
                {
                    var thisDeltaGap = newLaps[i].DeltaLeader - (spacingBetweenRows * rowNumber);
                    newLaps[i].LapTime -= thisDeltaGap;
                    newLaps[i].TotalTime -= thisDeltaGap;
                    newLaps[i].Delta = newLaps[i].TotalTime - newLaps[i - 1].TotalTime;
                    newLaps[i].DeltaLeader = newLaps[i].TotalTime - leaderTotalTime;
                    newLaps[i].DeltaPhysical = newLaps[i].DeltaLeader;

                    cumulativeDeltaLeader += newLaps[i].DeltaLeader;
                }
                else
                {
                    // physical seconds behind leader, not counting laps
                    var physicalDeltaLeader = (newLaps[i].TotalTime - leaderTotalTime) % _baseLapTime;
                    var physicalDeltaGap = physicalDeltaLeader - (spacingBetweenRows * rowNumber);

                    newLaps[i].TotalTime -= physicalDeltaGap;
                    newLaps[i].LapTime -= physicalDeltaGap;
                    newLaps[i].DeltaPhysical = Math.Round((newLaps[i].TotalTime - leaderTotalTime) % _baseLapTime, 3);

                    cumulativeDeltaLeader += physicalDeltaGap;
                }

                newLaps[i].LapSpeed = _lapTimeService.GetLapSpeed(newLaps[i].LapTime);
            }

            return newLaps.ToList();
        }

        protected virtual List<NascarRaceLap> CautionLaps(List<NascarRaceLap> lastLaps)
        {
            NascarRaceLap[] newLaps = GetNewRaceLaps(lastLaps, VehicleLapState.CautionFlag);

            newLaps[0].Position = 1;
            newLaps[0].Delta = 0;
            newLaps[0].DeltaLeader = 0;

            int leaderLapNumber = newLaps[0].LapNumber;
            double leaderTotalTime = newLaps[0].TotalTime;

            for (int i = 1; i < newLaps.Length; i++)
            {
                newLaps[i].Position = i + 1;

                double deltaLeader = newLaps[i].TotalTime - leaderTotalTime;
                int deltaLaps = (int)(deltaLeader / _baseLapTime);

                if (deltaLaps >= 1)
                {
                    // vehicle is laps down
                    newLaps[i].Delta = deltaLaps * -1;
                    newLaps[i].DeltaLeader = deltaLaps * -1;
                    newLaps[i].LapNumber = leaderLapNumber - deltaLaps;
                }
                else
                {
                    // vehicle is on lead lap
                    newLaps[i].Delta = newLaps[i].TotalTime - newLaps[i - 1].TotalTime;
                    newLaps[i].DeltaLeader = newLaps[i].TotalTime - leaderTotalTime;
                    newLaps[i].LapNumber = leaderLapNumber;
                }
            }

            // close 'em up
            double cumulativeDeltaLeader = 0.0;
            double spacingBetweenCars = 0.5;
            for (int i = 1; i < newLaps.Length; i++)
            {
                if (newLaps[i].IsLeadLap)
                {
                    var thisDeltaGap = newLaps[i].DeltaLeader - (spacingBetweenCars * i);
                    newLaps[i].LapTime -= thisDeltaGap;
                    newLaps[i].TotalTime -= thisDeltaGap;
                    newLaps[i].Delta = newLaps[i].TotalTime - newLaps[i - 1].TotalTime;
                    newLaps[i].DeltaLeader = newLaps[i].TotalTime - leaderTotalTime;
                    newLaps[i].DeltaPhysical = newLaps[i].DeltaLeader;

                    cumulativeDeltaLeader += newLaps[i].DeltaLeader;
                }
                else
                {
                    // physical seconds behind leader, not counting laps
                    var physicalDeltaLeader = (newLaps[i].TotalTime - leaderTotalTime) % _baseLapTime;
                    var physicalDeltaGap = physicalDeltaLeader - (spacingBetweenCars * i);

                    newLaps[i].TotalTime -= physicalDeltaGap;
                    newLaps[i].LapTime -= physicalDeltaGap;
                    newLaps[i].DeltaPhysical = Math.Round((newLaps[i].TotalTime - leaderTotalTime) % _baseLapTime, 3);

                    cumulativeDeltaLeader += physicalDeltaGap;
                }

                newLaps[i].LapSpeed = _lapTimeService.GetLapSpeed(newLaps[i].LapTime);
            }

            return newLaps.ToList();
        }

        protected virtual List<NascarRaceLap> GreenFlagLaps(List<NascarRaceLap> lastLaps)
        {
            NascarRaceLap[] newLaps = GetNewRaceLaps(lastLaps, VehicleLapState.GreenFlag);

            newLaps[0].Position = 1;
            newLaps[0].Delta = 0;
            newLaps[0].DeltaLeader = 0;

            int leaderLapNumber = newLaps[0].LapNumber;
            double leaderTotalTime = newLaps[0].TotalTime;

            for (int i = 1; i < newLaps.Length; i++)
            {
                newLaps[i].Position = i + 1;

                double deltaLeader = newLaps[i].TotalTime - leaderTotalTime;
                int deltaLaps = (int)(deltaLeader / _baseLapTime);

                if (deltaLaps >= 1)
                {
                    // vehicle is laps down
                    newLaps[i].Delta = deltaLaps * -1;
                    newLaps[i].DeltaLeader = deltaLaps * -1;
                    newLaps[i].LapNumber = leaderLapNumber - deltaLaps;
                }
                else
                {
                    // vehicle is on lead lap
                    newLaps[i].Delta = newLaps[i].TotalTime - newLaps[i - 1].TotalTime;
                    newLaps[i].DeltaLeader = newLaps[i].TotalTime - leaderTotalTime;
                    newLaps[i].LapNumber = leaderLapNumber;
                    newLaps[i].DeltaPhysical = Math.Round((newLaps[i].TotalTime - leaderTotalTime) % _baseLapTime, 3);
                }
            }

            return newLaps.ToList();
        }

        protected virtual List<NascarRaceLap> StartingLineup(NascarEvent raceEvent, NascarRaceRun stage1)
        {
            List<NascarRaceLap> raceLaps = new List<NascarRaceLap>();
            int position = 1;
            double leaderTotalTime = 0;

            foreach (QualifyingResult vehicle in raceEvent.QualifyingResults.OrderBy(q => q.Position))
            {
                vehicle.Position = position;

                double deltaRow = 0.5;

                double deltaNext = vehicle.Position == 1 ? 0 : (vehicle.Position % 2) == 0 ? 0.0 : 0.5;

                double deltaLeader = vehicle.Position <= 2 ? 0 : Math.Round((double)((vehicle.Position - 1) / 2), 0) * deltaRow;

                var newLap = new NascarRaceLap()
                {
                    Position = vehicle.Position,
                    VehicleId = vehicle.VehicleId,
                    DriverId = vehicle.DriverId,
                    LapNumber = 0,
                    LeaderLap = 0,
                    Delta = Math.Round(deltaNext, 3),
                    DeltaLeader = Math.Round(deltaLeader, 3),
                    LapSpeed = 0,
                    LapTime = 0,
                    TotalTime = 0
                };

                raceLaps.Add(newLap);

                if (leaderTotalTime == 0)
                    leaderTotalTime = newLap.TotalTime;

                position++;
            }

            Console.WriteLine("Starting Lineup");

            PrintStandings(raceLaps, false, false);

            return raceLaps;
        }

        protected virtual List<NascarRaceLap> HandlePitStops(List<NascarRaceLap> thisLaps, int pitWindow, bool underCaution, bool leadLapOnly)
        {
            if (underCaution)
            {
                foreach (NascarRaceLap thisLap in thisLaps.Where(l => l.LapsSincePit > (pitWindow * .3) && leadLapOnly ? l.IsLeadLap : true))
                {
                    DoPitStop(thisLap);
                }
            }
            else
            {
                var pitWindowRange = (int)(pitWindow * .25);

                foreach (NascarRaceLap thisLap in thisLaps.Where(l => l.LapsSincePit > (pitWindow - pitWindowRange)))
                {
                    if (thisLap.LapsSincePit > pitWindow)
                    {
                        // pit now
                        DoPitStop(thisLap);
                    }
                    else
                    {
                        var margin = 1 - (thisLap.LapsSincePit / (double)pitWindow);
                        var threshold = margin * pitWindowRange;
                        var rawValue = _pitRandom.Next(pitWindowRange);
                        var value = ((double)rawValue / pitWindowRange) * 10;
                        if (value > threshold)
                        {
                            // pit now
                            DoPitStop(thisLap);
                        }
                    }
                }
            }

            // reset positions, deltas
            var newLaps = thisLaps.OrderBy(l => l.TotalTime).ToList();

            double leaderTotalTime = newLaps[0].TotalTime;

            for (int i = 0; i < newLaps.Count; i++)
            {
                newLaps[i].Position = i + 1;
                newLaps[i].Delta = Math.Round(i == 0 ? 0 : newLaps[i].TotalTime - newLaps[i - 1].TotalTime, 3);
                newLaps[i].DeltaLeader = newLaps[i].TotalTime - leaderTotalTime;
            }

            return newLaps;
        }

        protected virtual NascarRaceLap DoPitStop(NascarRaceLap thisLap)
        {
            Console.WriteLine($"Car {thisLap.VehicleId} Pitting...");

            var originalLapTime = thisLap.LapTime;
            var pitLapTime = _lapTimeService.GetPitLapTime();
            var pitTime = pitLapTime.LapTime - originalLapTime;

            thisLap.LapTime = pitLapTime.LapTime;
            thisLap.LapSpeed = pitLapTime.LapSpeed;
            thisLap.TotalTime += pitTime;
            thisLap.Delta += pitTime;
            thisLap.DeltaLeader += pitTime;

            thisLap.LapsSincePit = 0;

            return thisLap;
        }

        #endregion

        #region private

        private void PrintStandings(List<NascarRaceLap> raceLaps, bool isUnderCaution, bool oneToGo = false)
        {
            if (oneToGo)
                Console.WriteLine($"Lap {raceLaps[0].LapNumber} ***** ##### ONE TO GO ##### *****");
            else if (isUnderCaution)
                Console.WriteLine($"Lap {raceLaps[0].LapNumber} ***** CAUTION *****");
            else
                Console.WriteLine($"Lap {raceLaps[0].LapNumber}");

            Console.WriteLine($"              Delta     Delta   Laps    Lap     Lap      Total");
            Console.WriteLine($"     [CAR]    Next      Leader  Down    Time    Speed    Elapsed");
            for (int x = 0; x < raceLaps.Count; x++)
            {
                var rl = raceLaps[x];
                Console.WriteLine($"{String.Format("{0,-2}", rl.Position)} - [{String.Format("{0,2}", rl.VehicleId)}]   {String.Format("{0,7}", rl.Delta < 0 ? rl.Delta.ToString("####") : rl.Delta.ToString("##.##0"))}   {String.Format("{0,7}", rl.DeltaLeader < 0 ? rl.DeltaLeader.ToString("####") : rl.DeltaLeader.ToString("##.##0"))}     {(rl.IsLeadLap ? "  " : String.Format("{0,-2}", rl.LeaderLap - rl.LapNumber))}    {String.Format("{0,6}", rl.LapTime.ToString("###.##0"))}  {String.Format("{0,6}", rl.LapSpeed.ToString("###.##0"))}   {String.Format("{0,6}", rl.TotalTime.ToString("######.##0"))}  {rl.DeltaPhysical} {(rl.LapsSincePit == 0 ? "Pit Stop" : "       ")}  {(rl.IsLuckyDog ? "Lucky Dog" : "         ")}");
            }

            Console.WriteLine();
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using NascarApi.Simulation.Models;
using NascarApi.Simulation.Ports;

namespace NascarApi.Simulation.Internal
{
    public class VehicleLapService : IVehicleLapService
    {
        #region fields

        private readonly Random _pitRandom = new Random(DateTime.Now.Millisecond);

        #endregion

        #region properties

        public ILapTimeService LapTimeService { get; set; }

        #endregion

        #region ctor

        protected VehicleLapService(ILapTimeService lapTimeService)
        {
            LapTimeService = lapTimeService ?? throw new ArgumentNullException(nameof(lapTimeService));
        }

        public VehicleLapService(NascarTrack track)
        {
            if (track == null)
                throw new ArgumentNullException(nameof(track));

            LapTimeService = new LapTimeService(track);
        }

        #endregion

        #region public

        public List<NascarRaceLap> GetStartingLineup(NascarEvent raceEvent)
        {
            NascarRaceRun stage1 = raceEvent
                .Runs
                .OfType<NascarRaceRun>()
                .FirstOrDefault(r => r.RunType == NascarRunType.RaceStage1);

            return StartingLineup(raceEvent, stage1);
        }

        public virtual List<NascarRaceLap> UpdateRaceLaps(List<NascarRaceLap> lastLaps, RaceState state)
        {
            LapState lapState = LapState.OneToGreenFlag;
            switch (state)
            {
                case RaceState.PreRace:
                    {
                        lapState = LapState.OneToGreenFlag;
                        break;
                    }
                case RaceState.GreenFlag:
                case RaceState.WhiteFlag:
                case RaceState.Checkered:
                case RaceState.Overdrive:
                    {
                        lapState = LapState.GreenFlag;
                        break;
                    }
                case RaceState.Caution:
                case RaceState.OneToGo:
                case RaceState.EndOfStage:
                    {
                        lapState = LapState.CautionFlag;
                        break;
                    }
            }
            return UpdateRaceLaps(lastLaps, lapState);
        }

        public virtual List<NascarRaceLap> UpdateRaceLaps(List<NascarRaceLap> lastLaps, LapState state)
        {
            List<NascarRaceLap> newLaps = null;

            switch (state)
            {
                case LapState.OneToGreenFlag:
                    {
                        newLaps = OneToGoLaps(lastLaps);
                        break;
                    }
                case LapState.GreenFlag:
                    {
                        newLaps = GreenFlagLaps(lastLaps);
                        break;
                    }
                case LapState.CautionFlag:
                    {
                        newLaps = CautionLaps(lastLaps);
                        break;
                    }
                default:
                    {
                        throw new ArgumentException($"Invalid LapState: {state.ToString()}");
                    }
            }

            PrintStandings(newLaps, state);

            return newLaps;
        }

        #endregion

        #region protected

        protected virtual NascarRaceLap[] GetNewRaceLaps(List<NascarRaceLap> lastLaps, LapState state)
        {
            NascarRaceLap[] newLaps = lastLaps.Select(l => new NascarRaceLap()
            {
                Position = l.Position,
                DriverId = l.DriverId,
                VehicleId = l.VehicleId,
                TotalTime = l.TotalTime,
                LapNumber = l.LapNumber,
                LapsSincePit = l.LapsSincePit,
                PitInLap = l.PitInLap,
                PitOutLap = l.PitOutLap,
                IsLuckyDog = l.IsLuckyDog,
                LeaderLap = l.LeaderLap
            }).ToArray();

            LapTimeResult lapTimeResult = null;
            for (int i = 0; i < newLaps.Length; i++)
            {
                if (newLaps[i].PitInLap && !newLaps[i].PitOutLap)
                {
                    newLaps[i].LapsSincePit = -1;
                    newLaps[i].PitOutLap = true;
                }
                else
                {
                    if (!newLaps[i].PitInLap && newLaps[i].PitOutLap)
                    {
                        lapTimeResult = LapTimeService.GetPitInLapTime();
                        newLaps[i].PitOutLap = false;
                    }

                    if (newLaps[i].PitInLap && newLaps[i].PitOutLap)
                    {
                        lapTimeResult = LapTimeService.GetPitOutLapTime();
                        LapTimeResult pitLapTimeResult = null;

                        if (state == LapState.CautionFlag || state == LapState.OneToGreenFlag)
                            pitLapTimeResult = LapTimeService.GetCautionLapTime();
                        else if (state == LapState.GreenFlag)
                            pitLapTimeResult = LapTimeService.GetLapTime(0);

                        lapTimeResult.LapTime += pitLapTimeResult.LapTime;
                        lapTimeResult.LapSpeed = LapTimeService.GetLapSpeed(lapTimeResult.LapTime);

                        newLaps[i].PitInLap = false;
                    }
                    else if (state == LapState.CautionFlag || state == LapState.OneToGreenFlag)
                    {
                        lapTimeResult = LapTimeService.GetCautionLapTime();
                    }
                    else if (state == LapState.GreenFlag)
                    {
                        lapTimeResult = LapTimeService.GetLapTime(newLaps[i].LapsSincePit);
                    }
                    newLaps[i].LapNumber += 1;
                    newLaps[i].LapTime = lapTimeResult.LapTime;
                    newLaps[i].LapSpeed = lapTimeResult.LapSpeed;
                    newLaps[i].TotalTime += lapTimeResult.LapTime;
                    newLaps[i].LapsSincePit += 1;
                }
            }

            Array.Sort(newLaps);

            newLaps[0].LeaderLap = newLaps[0].LapNumber;
            newLaps[0].Delta = 0;
            newLaps[0].DeltaLeader = 0;
            newLaps[0].Position = 1;

            double leaderTotalTime = newLaps[0].TotalTime;
            int leaderLap = newLaps[0].LeaderLap;

            for (int i = 1; i < newLaps.Length; i++)
            {
                newLaps[i].Position = i + 1;
                newLaps[i].LeaderLap = leaderLap;

                if (newLaps[i].LapsBehind > 0)
                {
                    // vehicle is laps down
                    newLaps[i].Delta = newLaps[i].LapsBehind * -1;
                    newLaps[i].DeltaLeader = newLaps[i].LapsBehind * -1;
                    newLaps[i].DeltaPhysical = Math.Round((newLaps[i].TotalTime - (newLaps[0].AverageLapTime * newLaps[i].LapNumber)) % LapTimeService.BaseLapTime, 3);
                    newLaps[i].DeltaTravelledLeader = newLaps[i].TotalTime - (newLaps[0].AverageLapTime * newLaps[i].LapNumber) + (LapTimeService.BaseLapTime * newLaps[i].LapsBehind);
                }
                else
                {
                    // vehicle is on lead lap
                    newLaps[i].Delta = newLaps[i].TotalTime - newLaps[i - 1].TotalTime;
                    newLaps[i].DeltaLeader = newLaps[i].TotalTime - leaderTotalTime;
                    newLaps[i].DeltaPhysical = Math.Round((newLaps[i].TotalTime - leaderTotalTime) % LapTimeService.BaseLapTime, 3);
                    newLaps[i].DeltaTravelledLeader = newLaps[i].DeltaLeader;
                }
            }

            return newLaps;
        }

        protected virtual List<NascarRaceLap> OneToGoLaps(List<NascarRaceLap> lastLaps)
        {
            NascarRaceLap[] newLaps = GetNewRaceLaps(lastLaps, LapState.OneToGreenFlag);

            //////var luckyDog = newLaps.FirstOrDefault(l => l.IsLuckyDog);

            //////if (luckyDog != null)
            //////{
            //////    var lastCarOnLeadLap = newLaps.Where(l => l.IsLeadLap).OrderByDescending(l => l.Position).LastOrDefault();
            //////    var luckyDogTimeDelta = luckyDog.TotalTime - lastCarOnLeadLap.TotalTime;

            //////    luckyDog.TotalTime -= (luckyDogTimeDelta + .001);
            //////    luckyDog.LapTime -= luckyDogTimeDelta;
            //////    luckyDog.LapNumber += 1;
            //////    luckyDog.IsLuckyDog = false;
            //////}

            double leaderTotalTime = newLaps[0].TotalTime;

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
                    newLaps[i].DeltaTravelledLeader = newLaps[i].DeltaLeader;

                    cumulativeDeltaLeader += newLaps[i].DeltaLeader;
                }
                else
                {
                    // physical seconds behind leader, not counting laps
                    var physicalDeltaLeader = (newLaps[i].TotalTime - leaderTotalTime) % LapTimeService.BaseLapTime;
                    var physicalDeltaGap = physicalDeltaLeader - (spacingBetweenRows * rowNumber);

                    newLaps[i].TotalTime -= physicalDeltaGap;
                    newLaps[i].LapTime -= physicalDeltaGap;
                    newLaps[i].DeltaPhysical = Math.Round((newLaps[i].TotalTime - leaderTotalTime) % LapTimeService.BaseLapTime, 3);
                    newLaps[i].DeltaTravelledLeader = newLaps[i].TotalTime - leaderTotalTime + (LapTimeService.BaseLapTime * newLaps[i].LapsBehind);

                    cumulativeDeltaLeader += physicalDeltaGap;
                }

                newLaps[i].LapSpeed = LapTimeService.GetLapSpeed(newLaps[i].LapTime);
            }

            return newLaps.ToList();
        }

        protected virtual List<NascarRaceLap> CautionLaps(List<NascarRaceLap> lastLaps)
        {
            NascarRaceLap[] newLaps = GetNewRaceLaps(lastLaps, LapState.CautionFlag);

            double leaderTotalTime = newLaps[0].TotalTime;

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
                    newLaps[i].DeltaTravelledLeader = newLaps[i].DeltaLeader;

                    cumulativeDeltaLeader += newLaps[i].DeltaLeader;
                }
                else
                {
                    // physical seconds behind leader, not counting laps
                    var physicalDeltaLeader = (newLaps[i].TotalTime - leaderTotalTime) % LapTimeService.BaseLapTime;
                    var physicalDeltaGap = physicalDeltaLeader - (spacingBetweenCars * i);

                    newLaps[i].TotalTime -= physicalDeltaGap;
                    newLaps[i].LapTime -= physicalDeltaGap;
                    newLaps[i].DeltaPhysical = Math.Round((newLaps[i].TotalTime - leaderTotalTime) % LapTimeService.BaseLapTime, 3);
                    newLaps[i].DeltaTravelledLeader = newLaps[i].TotalTime - leaderTotalTime + (LapTimeService.BaseLapTime * newLaps[i].LapsBehind);

                    cumulativeDeltaLeader += physicalDeltaGap;
                }

                newLaps[i].LapSpeed = LapTimeService.GetLapSpeed(newLaps[i].LapTime);
            }

            return newLaps.ToList();
        }

        protected virtual List<NascarRaceLap> GreenFlagLaps(List<NascarRaceLap> lastLaps)
        {
            return GetNewRaceLaps(lastLaps, LapState.GreenFlag).ToList();
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
                    DeltaTravelledLeader = Math.Round(deltaLeader, 3),
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

            PrintStandings(raceLaps, LapState.OneToGreenFlag);

            return raceLaps;
        }

        protected virtual void PrintStandings(List<NascarRaceLap> raceLaps, LapState state)
        {
            Console.WriteLine($"End of Lap {raceLaps[0].LapNumber} {state.ToString()}");
            Console.WriteLine();
            Console.WriteLine($"              Delta     Delta   Laps     Lap        Lap       Total        Delta    Actual              Lucky      Leader    Lap");
            Console.WriteLine($"     [CAR]    Next      Leader  Down     Time      Speed     Elapsed      Physical  Delta     Pit       Dog         Lap     Number");
            for (int x = 0; x < raceLaps.Count; x++)
            {
                var rl = raceLaps[x];
                Console.WriteLine($"{String.Format("{0,-2}", rl.Position)} - [{String.Format("{0,2}", rl.VehicleId)}]   {String.Format("{0,7}", rl.Delta < 0 ? rl.Delta.ToString("####") : rl.Delta.ToString("##.##0"))}   {String.Format("{0,7}", rl.DeltaLeader < 0 ? rl.DeltaLeader.ToString("####") : rl.DeltaLeader.ToString("##.##0"))}     {(rl.IsLeadLap ? "  " : String.Format("{0,-2}", rl.LeaderLap - rl.LapNumber))}    {String.Format("{0,8}", rl.LapTime.ToString("###.##0"))}  {String.Format("{0,8}", rl.LapSpeed.ToString("###.##0"))}   {String.Format("{0,8}", rl.TotalTime.ToString("######.##0"))}    {String.Format("{0, 8}", rl.DeltaPhysical.ToString("######.##0"))} {String.Format("{0, 8}", rl.DeltaTravelledLeader.ToString("######.##0"))}    {(rl.PitInLap && rl.PitOutLap ? "Pit In  " : rl.PitOutLap ? "Pit Out " : "-       ")}  {(rl.IsLuckyDog ? "Lucky Dog" : "-        ")}   {rl.LeaderLap}      {rl.LapNumber}");
            }

            Console.WriteLine();
        }

        #endregion
    }
}

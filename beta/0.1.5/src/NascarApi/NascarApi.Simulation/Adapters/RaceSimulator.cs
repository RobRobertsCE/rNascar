using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NascarApi.Mock.Internal;
using NascarApi.Mock.Models;
using NascarApi.Mock.Ports;

namespace NascarApi.Mock.Adapters
{
    class RaceSimulator : IRaceSimulator
    {
        #region fields

        private LapTimeService _lapTimeService;
        private VehicleLapService _vehicleLapService;
        private readonly RandomCautionService _cautionService;
        private readonly Random _pitRandom = new Random(DateTime.Now.Millisecond);
        private int _baseLapTime = 0;

        #endregion

        #region properties

        protected RaceStateService StateService { get; private set; }

        #endregion

        #region ctor

        public RaceSimulator()
        {
            StateService = new RaceStateService();
            _cautionService = new RandomCautionService();
        }

        #endregion

        #region public

        public async virtual Task<NascarEvent> SimulateRaceAsync(NascarEvent raceEvent)
        {
            _lapTimeService = new LapTimeService(raceEvent.Track);
            _baseLapTime = raceEvent.Track.BaseLapTime;
            _vehicleLapService = new VehicleLapService(raceEvent);
            StateService.Initialize();

            int cautionLapsRemaining = 0;
            int greenWhiteCheckeredLapCount = 2;
            int endOfStageCautionLapCount = 5;
            int pitsClosedBeforeStageEndLaps = 2;
            int nextStageEndLap = 0;
            int currentStageIndex = 0;
            int lapsRunUnderThisCaution = 0;
            bool pitsAreOpen = true;
            bool leadLapPitOnly = false;
            bool isFirstCautionLap = true;
            List<int> stageEndLaps = GetStageEndLaps(raceEvent);
            nextStageEndLap = stageEndLaps[currentStageIndex];

            var firstStage = raceEvent.Runs.OfType<NascarRaceRun>().Where(r => r.RunType == NascarRunType.RaceStage1).SingleOrDefault();
            var secondStage = raceEvent.Runs.OfType<NascarRaceRun>().Where(r => r.RunType == NascarRunType.RaceStage2).SingleOrDefault();
            var finalStage = raceEvent.Runs.OfType<NascarRaceRun>().Where(r => r.RunType == NascarRunType.FinalRaceStage).SingleOrDefault();

            NascarRaceRun run = firstStage;
            int advertisedRaceEndLap = finalStage.EndLap;
            int actualRaceEndLap = advertisedRaceEndLap;

            List<NascarRaceLap> raceLaps = _vehicleLapService.GetStartingLineup(raceEvent, firstStage);
            List<NascarRaceLap> laps = new List<NascarRaceLap>();

            StateService.GreenFlagOn();

            for (int lapNumber = 1; lapNumber <= actualRaceEndLap; lapNumber++)
            {
                //***** random caution generator *****//
                if (!StateService.IsCaution)
                {
                    var randomCautionResult = _cautionService.GetRandomCautionResult();
                    var isCaution = randomCautionResult.IsCaution;

                    if (isCaution)
                    {
                        var caution = new NascarCautionSegment() { StartLap = lapNumber };
                        raceEvent.Cautions.Add(caution);
                        isFirstCautionLap = true;
                        StateService.CautionOn();

                        if (StateService.IsWhiteFlag)
                            cautionLapsRemaining = 1;
                        else
                        {
                            cautionLapsRemaining = randomCautionResult.CautionLaps;
                            pitsAreOpen = false;
                        }
                    }
                }
                else
                {
                    isFirstCautionLap = false;
                    if (!pitsAreOpen && lapsRunUnderThisCaution > 0 && (lapNumber + pitsClosedBeforeStageEndLaps <= nextStageEndLap))
                    {
                        pitsAreOpen = true;
                        leadLapPitOnly = true;
                    }
                    else if (pitsAreOpen)
                    {
                        leadLapPitOnly = false;
                    }
                }
                //***** end of race *****//
                if (lapNumber == actualRaceEndLap - 1)
                {
                    StateService.WhiteFlagOn();
                }
                else if (lapNumber == actualRaceEndLap)
                {
                    StateService.CheckeredFlagOn();
                }
                //***** end of stage *****//
                if (run.RunType != NascarRunType.FinalRaceStage)
                {
                    if (lapNumber + pitsClosedBeforeStageEndLaps == nextStageEndLap)
                    {
                        // end of stage
                        pitsAreOpen = false;
                    }
                    else if (lapNumber == nextStageEndLap)
                    {
                        // end of stage
                        StateService.EndOfStageOn();
                        cautionLapsRemaining = endOfStageCautionLapCount;

                        var caution = new NascarCautionSegment() { StartLap = lapNumber };
                        raceEvent.Cautions.Add(caution);
                        isFirstCautionLap = true;

                        currentStageIndex++;
                        if (currentStageIndex == 1)
                        {
                            if (currentStageIndex < stageEndLaps.Count)
                            {
                                nextStageEndLap = stageEndLaps[currentStageIndex];
                                run = secondStage;
                            }
                            else
                                currentStageIndex++;
                        }

                        leadLapPitOnly = (pitsAreOpen && lapsRunUnderThisCaution <= 2);

                        pitsAreOpen = (lapsRunUnderThisCaution > 0);

                        if (currentStageIndex == 2)
                        {
                            run = finalStage;
                            nextStageEndLap = finalStage.EndLap;
                        }
                    }
                }
                //***** overdrive *****//
                if (StateService.IsCaution && !StateService.IsWhiteFlag && lapNumber + cautionLapsRemaining >= actualRaceEndLap)
                {
                    // end of race extended by caution
                    StateService.OverdriveOn();
                    actualRaceEndLap = (lapNumber + cautionLapsRemaining + greenWhiteCheckeredLapCount);
                }
                //***** end of caution *****//
                if (StateService.IsCaution && cautionLapsRemaining == 0)
                {
                    // end of caution, back to green
                    StateService.GreenFlagOn();
                    lapsRunUnderThisCaution = 0;
                    raceEvent.Cautions.LastOrDefault().EndLap = lapNumber;
                }

                // vehicle pit stops
                if (pitsAreOpen)
                    raceLaps = SetPitStops(raceLaps, raceEvent.Track.PitWindow, StateService.IsCaution, leadLapPitOnly);

                // vehicle lap times
                if (StateService.IsGreenFlag)
                    laps = _vehicleLapService.UpdateRaceLaps(raceLaps, VehicleLapState.GreenFlag);
                else if (StateService.IsCaution)
                {
                    if (isFirstCautionLap)
                        laps = _vehicleLapService.UpdateRaceLaps(raceLaps, VehicleLapState.CautionFlag);
                    else if (cautionLapsRemaining == 1)
                        laps = _vehicleLapService.UpdateRaceLaps(raceLaps, VehicleLapState.OneToGreenFlag);
                    else
                        laps = _vehicleLapService.UpdateRaceLaps(raceLaps, VehicleLapState.CautionFlag);
                }

                ((List<NascarRaceLap>)run.Laps).AddRange(laps.ToList());
                raceLaps.Clear();
                raceLaps.AddRange(laps);
                laps.Clear();

                if (StateService.IsCaution)
                {
                    cautionLapsRemaining--;
                    lapsRunUnderThisCaution++;
                }
                Console.WriteLine($"Lap {lapNumber} [{StateService.State.ToString()}] ");
            }
            return await Task.FromResult(raceEvent);
        }

        #endregion

        #region protected

        protected virtual List<int> GetStageEndLaps(NascarEvent raceEvent)
        {
            var stageRuns = raceEvent.Runs.OfType<NascarRaceRun>().Where(r => r.RunType != NascarRunType.FinalRaceStage);
            List<int> stageEndLaps = new List<int>();
            stageEndLaps.AddRange(stageRuns.Select(s => s.EndLap).ToList());

            return stageEndLaps;
        }

        protected virtual List<NascarRaceLap> SetPitStops(List<NascarRaceLap> thisLaps, int pitWindow, bool underCaution, bool leadLapOnly)
        {
            if (underCaution)
            {
                var leadLapCount = thisLaps.Count(l => l.IsLeadLap);

                for (int i = 0; i < thisLaps.Count; i++)
                {
                    NascarRaceLap thisLap = thisLaps[i];

                    if (leadLapOnly && thisLap.IsLeadLap)
                    {
                        if (thisLap.LapsSincePit > (pitWindow * .25))
                        {
                            thisLap.PitThisLap = true;
                        }
                        else if (i > (leadLapCount / 2))
                        {
                            // end of lead lap
                            thisLap.PitThisLap = true;
                        }
                    }
                    else if (!leadLapOnly && !thisLap.IsLeadLap)
                    {
                        if (thisLap.LapsSincePit > (pitWindow * .6))
                        {
                            thisLap.PitThisLap = true;
                        }
                    }
                    else if (i == leadLapCount - 1 && !thisLaps.Any(l => l.IsLuckyDog))
                    {
                        // lucky dog
                        // TODO: FIX LUCKY DOG
                        // TODO: FIX WAVE-AROUNDS
                        thisLap.IsLuckyDog = true;
                        thisLap.PitThisLap = true;
                    }
                }
            }
            else
            {
                var pitWindowRange = (int)(pitWindow * .25);

                foreach (NascarRaceLap thisLap in thisLaps.Where(l => l.LapsSincePit > (pitWindow - pitWindowRange)))
                {
                    if (thisLap.LapsSincePit > pitWindow)
                    {
                        thisLap.PitThisLap = true;
                    }
                    else
                    {
                        var margin = 1 - (thisLap.LapsSincePit / (double)pitWindow);
                        var threshold = margin * pitWindowRange;
                        var rawValue = _pitRandom.Next(pitWindowRange);
                        var value = ((double)rawValue / pitWindowRange) * 10;
                        if (value > threshold)
                        {
                            thisLap.PitThisLap = true;
                        }
                    }
                }
            }

            return thisLaps;
        }

        #endregion

    }
}

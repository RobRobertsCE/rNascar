using System;
using System.Collections.Generic;

namespace NascarApi.Mock.Models
{
    public class NascarEvent
    {
        #region properties

        public int EventId { get; set; }
        public NascarTrack Track { get; private set; }
        public NascarSeries Series { get; private set; }
        public IList<NascarVehicle> Vehicles { get; private set; }
        public IList<NascarRun> Runs { get; set; }

        public IList<QualifyingResult> QualifyingResults { get; set; }
        public IList<NascarCautionSegment> Cautions { get; set; }

        #endregion

        #region ctor

        public NascarEvent(NascarTrack track, NascarSeries series, IList<NascarVehicle> vehicles)
        {
            Track = track ?? throw new ArgumentNullException(nameof(track));
            Series = series ?? throw new ArgumentNullException(nameof(series));
            Vehicles = vehicles ?? throw new ArgumentNullException(nameof(vehicles));

            Runs = new List<NascarRun>();
            Cautions = new List<NascarCautionSegment>();
            QualifyingResults = new List<QualifyingResult>();

            ConfigureEvent();
        }

        #endregion

        #region protected

        protected virtual void ConfigureEvent()
        {
            Runs.Add(new NascarPracticeRun()
            {
                SeriesId = Series.SeriesId,
                Round = 1,
                RunType = NascarRunType.Practice1,
                RunId = Runs.Count + 1,
                StartLap = 1,
                EndLap = 999
            });
            Runs.Add(new NascarPracticeRun()
            {
                SeriesId = Series.SeriesId,
                Round = 2,
                RunType = NascarRunType.Practice2,
                RunId = Runs.Count + 1,
                StartLap = 1,
                EndLap = 999
            });
            Runs.Add(new NascarPracticeRun()
            {
                SeriesId = Series.SeriesId,
                Round = 3,
                RunType = NascarRunType.FinalPractice,
                RunId = Runs.Count + 1,
                StartLap = 1,
                EndLap = 999
            });

            Runs.Add(new NascarQualifyingRun()
            {
                SeriesId = Series.SeriesId,
                Round = 1,
                RunType = NascarRunType.QualifyingStage1,
                RunId = Runs.Count + 1,
                StartLap = 1,
                EndLap = 999
            });
            Runs.Add(new NascarQualifyingRun()
            {
                SeriesId = Series.SeriesId,
                Round = 2,
                RunType = NascarRunType.QualifyingStage2,
                RunId = Runs.Count + 1,
                StartLap = 1,
                EndLap = 999
            });
            Runs.Add(new NascarQualifyingRun()
            {
                SeriesId = Series.SeriesId,
                Round = 3,
                RunType = NascarRunType.FinalQualifyingStage,
                RunId = Runs.Count + 1,
                StartLap = 1,
                EndLap = 999
            });

            var totalRaceLaps = (int)(Track.RaceLengthBase * Series.RaceLapPercent);
            var stage1Length = (int)(totalRaceLaps * Series.RaceStage1Percent);
            var stage2Length = (int)(totalRaceLaps * Series.RaceStage2Percent);
            var finalStageLength = (int)(totalRaceLaps * Series.RaceFinalStagePercent);

            Runs.Add(new NascarRaceRun()
            {
                SeriesId = Series.SeriesId,
                RunType = NascarRunType.RaceStage1,
                RunId = Runs.Count + 1,
                StartLap = 1,
                EndLap = stage1Length
            });
            Runs.Add(new NascarRaceRun()
            {
                SeriesId = Series.SeriesId,
                RunType = NascarRunType.RaceStage2,
                RunId = Runs.Count + 1,
                StartLap = stage1Length + 1,
                EndLap = stage1Length + stage2Length
            });
            Runs.Add(new NascarRaceRun()
            {
                SeriesId = Series.SeriesId,
                RunType = NascarRunType.FinalRaceStage,
                RunId = Runs.Count + 1,
                StartLap = stage1Length + stage2Length + 1,
                EndLap = totalRaceLaps
            });
        }

        #endregion
    }
}

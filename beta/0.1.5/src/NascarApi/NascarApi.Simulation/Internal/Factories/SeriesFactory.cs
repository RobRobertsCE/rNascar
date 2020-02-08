using System.Collections.Generic;
using NascarApi.Mock.Models;

namespace NascarApi.Mock.Internal.Factories
{
    class SeriesFactory : Factory<NascarSeries, int>
    {
        public override IList<NascarSeries> GetList()
        {
            IList<NascarSeries> items = new List<NascarSeries>();

            items.Add(new NascarSeries()
            {
                SeriesId = 1,
                SeriesType = SeriesType.MonsterEnergyCup,
                Name = "Monster Energy NASCAR Cup Series",
                CarCount = 40,
                QualifyingRound1Count = 40,
                QualifyingRound2Count = 24,
                QualifyingFinalRoundCount = 10,
                RaceStage1Percent = .2,
                RaceStage2Percent = .2,
                RaceFinalStagePercent = .6,
                RaceLapPercent = 1.0
            });
            items.Add(new NascarSeries()
            {
                SeriesId = 2,
                SeriesType = SeriesType.Xfinity,
                Name = "Xfinity Series",
                CarCount = 40,
                QualifyingRound1Count = 40,
                QualifyingRound2Count = 24,
                QualifyingFinalRoundCount = 12,
                RaceStage1Percent = .25,
                RaceStage2Percent = .25,
                RaceFinalStagePercent = .5,
                RaceLapPercent = .6
            });
            items.Add(new NascarSeries()
            {
                SeriesId = 3,
                SeriesType = SeriesType.GanderOutdoorsTruck,
                Name = "Gander Outdoors Truck Series",
                CarCount = 32,
                QualifyingRound1Count = 32,
                QualifyingRound2Count = 24,
                QualifyingFinalRoundCount = 12,
                RaceStage1Percent = .2,
                RaceStage2Percent = .2,
                RaceFinalStagePercent = .6,
                RaceLapPercent = .5
            });
            items.Add(new NascarSeries()
            {
                SeriesId = 4,
                SeriesType = SeriesType.Other,
                Name = "Other",
                CarCount = 30,
                QualifyingRound1Count = null,
                QualifyingRound2Count = null,
                QualifyingFinalRoundCount = 0,
                RaceStage1Percent = null,
                RaceStage2Percent = null,
                RaceFinalStagePercent = 1.0,
                RaceLapPercent = 1.0
            });

            return items;
        }
    }
}

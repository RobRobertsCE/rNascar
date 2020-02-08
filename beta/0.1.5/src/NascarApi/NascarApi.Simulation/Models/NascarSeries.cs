using NascarApi.Mock.Adapters;

namespace NascarApi.Mock.Models
{
    public class NascarSeries : IKeyedItem<int>
    {
        public int SeriesId { get; set; }
        public SeriesType SeriesType { get; set; }
        public string Name { get; set; }
        public int CarCount { get; set; }
        public int? QualifyingRound1Count { get; set; }
        public int? QualifyingRound2Count { get; set; }
        public int QualifyingFinalRoundCount { get; set; }
        public double? RaceStage1Percent { get; set; }
        public double? RaceStage2Percent { get; set; }
        public double RaceFinalStagePercent { get; set; }
        public double RaceLapPercent { get; set; }
        int IKeyedItem<int>.Id { get => SeriesId; set => SeriesId = value; }
    }
}

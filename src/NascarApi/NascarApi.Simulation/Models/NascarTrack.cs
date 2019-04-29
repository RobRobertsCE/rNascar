using NascarApi.Simulation.Adapters;

namespace NascarApi.Simulation.Models
{
    public class NascarTrack : IKeyedItem<int>
    {
        public int TrackId { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public int BaseLapTime { get; set; }
        public int RaceLengthBase { get; set; }
        public int PitWindow { get; set; }
        public double Falloff { get; set; }
        int IKeyedItem<int>.Id { get => TrackId; set => TrackId = value; }
    }
}

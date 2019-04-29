using System.Collections.Generic;
using NascarApi.Simulation.Models;

namespace NascarApi.Simulation.Internal.Factories
{
    class TrackFactory : Factory<NascarTrack, int>
    {
        public override IList<NascarTrack> GetList()
        {
            IList<NascarTrack> items = new List<NascarTrack>();

            items.Add(new NascarTrack()
            {
                TrackId = 1,
                Name = "Charlotte",
                Length = 1.5,
                BaseLapTime = 28,
                PitWindow = 75,
                RaceLengthBase = 500,
                Falloff = .15
            });

            items.Add(new NascarTrack()
            {
                TrackId = 2,
                Name = "Bristol",
                Length = .5,
                BaseLapTime = 14,
                PitWindow = 120,
                RaceLengthBase = 500,
                Falloff = .3
            });

            items.Add(new NascarTrack()
            {
                TrackId = 3,
                Name = "Daytona",
                Length = 2.5,
                BaseLapTime = 44,
                PitWindow = 20,
                RaceLengthBase = 500,
                Falloff = .25
            });

            items.Add(new NascarTrack()
            {
                TrackId = 4,
                Name = "Darlington",
                Length = 1.366,
                BaseLapTime = 33,
                PitWindow = 50,
                RaceLengthBase = 500,
                Falloff = .99
            });

            return items;
        }
    }
}

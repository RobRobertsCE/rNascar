using System;

namespace NascarApi.Simulation.Internal
{
    [Flags()]
    public enum RaceState
    {
        PreRace = 0,
        GreenFlag = 1,
        Caution = 2,
        OneToGo = 4,
        EndOfStage = 8,
        WhiteFlag = 16,
        Checkered = 32,
        Overdrive = 64
    }
}

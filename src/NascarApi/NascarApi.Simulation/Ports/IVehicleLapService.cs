using System.Collections.Generic;
using NascarApi.Simulation.Internal;
using NascarApi.Simulation.Models;

namespace NascarApi.Simulation.Ports
{
    public interface IVehicleLapService
    {
        ILapTimeService LapTimeService { get; set; }

        List<NascarRaceLap> GetStartingLineup(NascarEvent raceEvent);
        List<NascarRaceLap> UpdateRaceLaps(List<NascarRaceLap> lastLaps, RaceState state);
    }
}
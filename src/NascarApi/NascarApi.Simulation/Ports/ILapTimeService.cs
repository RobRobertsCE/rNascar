using NascarApi.Simulation.Internal;
using NascarApi.Simulation.Models;

namespace NascarApi.Simulation.Ports
{
    public interface ILapTimeService
    {
        int DecimalPlaces { get; set; }
        int BaseLapTime { get; set; }

        LapTimeResult GetLapTime(int lapsOnTires, RaceState raceState, VehicleState vehicleStatus);
        LapTimeResult GetLapTime(int lapsOnTires);
        LapTimeResult GetLapTime();

        LapTimeResult GetCautionLapTime();
        LapTimeResult GetPitInLapTime();
        LapTimeResult GetPitOutLapTime();

        double GetLapSpeed(double lapTime);
    }
}
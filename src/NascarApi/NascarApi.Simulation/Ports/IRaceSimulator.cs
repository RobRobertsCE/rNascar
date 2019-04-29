using System.Threading.Tasks;
using NascarApi.Simulation.Models;

namespace NascarApi.Simulation.Ports
{
    public interface IRaceSimulator
    {
        Task<NascarEvent> SimulateRaceAsync(NascarEvent raceEvent);
    }
}
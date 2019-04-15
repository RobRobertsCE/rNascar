using System.Threading.Tasks;
using NascarApi.Mock.Models;

namespace NascarApi.Mock.Ports
{
    public interface IRaceSimulator
    {
        Task<NascarEvent> SimulateRaceAsync(NascarEvent raceEvent);
    }
}
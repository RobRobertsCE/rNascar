using System.Threading.Tasks;
using NascarApi.Simulation.Models;

namespace NascarApi.Simulation.Ports
{
    public interface IEventGenerator
    {
        Task<NascarEvent> GenerateEventAsync(int trackId, NascarSeries series);
        Task<NascarEvent> GenerateEventAsync(NascarTrack track, NascarSeries series);
    }
}

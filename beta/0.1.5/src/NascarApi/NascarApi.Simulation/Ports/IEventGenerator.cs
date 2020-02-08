using System.Threading.Tasks;
using NascarApi.Mock.Models;

namespace NascarApi.Mock.Ports
{
    public interface IEventGenerator
    {
        Task<NascarEvent> GenerateEventAsync(int trackId, NascarSeries series);
        Task<NascarEvent> GenerateEventAsync(NascarTrack track, NascarSeries series);
    }
}

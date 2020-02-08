using System.Collections.Generic;
using NascarApi.Client.Models;
using NascarApi.Client.Ports;

namespace NascarApi.Client.Adapters
{
    public class LapTimeContext : ILapTimeContext
    {
        public IList<LapTimeModel> LapTimeModels { get; set; }
        public IList<LapAverageModel> LapAverageModels { get; set; }
    }
}

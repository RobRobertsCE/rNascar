using System.Collections.Generic;
using NascarApi.Client.Models;

namespace NascarApi.Client.Ports
{
    public interface ILapTimeContext
    {
        IList<LapAverageModel> LapAverageModels { get; set; }
        IList<LapTimeModel> LapTimeModels { get; set; }
    }
}
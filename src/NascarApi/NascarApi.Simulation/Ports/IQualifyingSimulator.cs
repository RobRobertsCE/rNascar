using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NascarApi.Mock.Models;

namespace NascarApi.Mock.Ports
{
    public interface IQualifyingSimulator
    {
        Task<NascarEvent> SimulateQualifyingAsync(NascarEvent raceEvent);
    }
}

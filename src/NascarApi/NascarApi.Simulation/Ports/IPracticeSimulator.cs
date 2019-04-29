using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NascarApi.Simulation.Models;

namespace NascarApi.Simulation.Ports
{
    public interface IPracticeSimulator
    {
        Task<NascarEvent> SimulatePracticeAsync(NascarEvent raceEvent);
    }
}

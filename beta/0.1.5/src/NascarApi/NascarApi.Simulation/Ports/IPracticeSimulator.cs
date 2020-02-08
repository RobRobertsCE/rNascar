using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NascarApi.Mock.Models;

namespace NascarApi.Mock.Ports
{
    public interface IPracticeSimulator
    {
        Task<NascarEvent> SimulatePracticeAsync(NascarEvent raceEvent);
    }
}

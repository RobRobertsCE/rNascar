using System.Collections.Generic;

namespace NascarApi.Simulation.Models
{
    public class NascarRaceRun : NascarRun
    {
        public IList<NascarRaceLap> Laps { get; set; }

        public new IList<NascarRaceVehicle> Vehicles { get; set; }

        public NascarRaceRun()
            : base()
        {
            Laps = new List<NascarRaceLap>();
        }
    }
}

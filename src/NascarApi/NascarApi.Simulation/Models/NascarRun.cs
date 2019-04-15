using System.Collections.Generic;

namespace NascarApi.Mock.Models
{
    public class NascarRun
    {
        public int RunId { get; set; }
        public int SeriesId { get; set; }
        public int LapCount
        {
            get
            {
                return EndLap - StartLap + 1;
            }
        }

        public int StartLap { get; set; }

        public int EndLap { get; set; }
        public NascarRunType RunType { get; set; }
        public IList<NascarVehicle> Vehicles { get; set; }

        public NascarRun()
        {
            Vehicles = new List<NascarVehicle>();
        }
    }
}

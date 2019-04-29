using System.Collections.Generic;

namespace NascarApi.Simulation.Models
{
    class NascarQualifyingRun : NascarRun
    {
        public int Round { get; set; }
        public IList<QualifyingResult> Results { get; set; }
        public IList<NascarConsecutiveLaps> ConsecutiveLaps { get; set; }

        public NascarQualifyingRun()
            : base()
        {
            ConsecutiveLaps = new List<NascarConsecutiveLaps>();
            Results = new List<QualifyingResult>();
        }
    }
}
using System.Collections.Generic;

namespace NascarApi.Simulation.Models
{
    public class NascarPracticeRun : NascarRun
    {
        public int Round { get; set; }
        public IList<PracticeResult> Results { get; set; }
        public IList<NascarConsecutiveLaps> ConsecutiveLaps { get; set; }

        public NascarPracticeRun()
            : base()
        {
            ConsecutiveLaps = new List<NascarConsecutiveLaps>();
        }
    }
}

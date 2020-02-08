using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NascarApi.Models.LiveFeed
{
    public class PitStop
    {
        public int positions_gained_lossed { get; set; }
        public double pit_in_elapsed_time { get; set; }
        public int pit_in_lap_count { get; set; }
        public int pit_in_leader_lap { get; set; }
        public double pit_out_elapsed_time { get; set; }
    }
}

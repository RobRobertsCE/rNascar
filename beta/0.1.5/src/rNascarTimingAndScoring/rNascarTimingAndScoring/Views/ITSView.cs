using System.Collections.Generic;
using rNascarTimingAndScoring.Models;

namespace rNascarTimingAndScoring.Views
{
    public interface ITSView
    {
        TSConfiguration Configuration { get; set; }
        RunType RunType { get; }

        void UpdateDisplay(IList<TSDriverModel> models);
        void UpdateDisplay(IList<TSGridRowModel> models);
        void UpdateDisplay(IList<TSTenLapAverageGridRowModel> models);
    }
}

using System.Collections.Generic;
using System.Linq;

namespace rNascarTimingAndScoring.Models
{
    public class EventLapAverages
    {
        private IList<VehicleLapTimes> _vehicleLapTimes = new List<VehicleLapTimes>();

        public IEnumerable<NLapAverage> LastFiveLapAverages
        {
            get
            {
                List<NLapAverage> lapAverages = new List<NLapAverage>();
                lapAverages.AddRange(_vehicleLapTimes.
                    Select(v => v.LastFiveLapAverage).
                    Where(a => a.HasEnoughLaps).
                    OrderBy(n => n.AverageLapTime));
                return lapAverages;
            }
        }

        public IEnumerable<NLapAverage> LastTenLapAverages
        {
            get
            {
                List<NLapAverage> lapAverages = new List<NLapAverage>();
                lapAverages.AddRange(_vehicleLapTimes.
                    Select(v => v.LastTenLapAverage).
                    Where(a => a.HasEnoughLaps).
                    OrderBy(n => n.AverageLapTime));
                return lapAverages;
            }
        }

        public IEnumerable<NLapAverage> LastTwentyLapAverages
        {
            get
            {
                List<NLapAverage> lapAverages = new List<NLapAverage>();
                lapAverages.AddRange(_vehicleLapTimes.
                    Select(v => v.LastTwentyLapAverage).
                    Where(a => a.HasEnoughLaps).
                    OrderBy(n => n.AverageLapTime));
                return lapAverages;
            }
        }

        public IEnumerable<NLapAverage> BestFiveLapAverages
        {
            get
            {
                List<NLapAverage> lapAverages = new List<NLapAverage>();
                lapAverages.AddRange(_vehicleLapTimes.
                    Select(v => v.BestFiveLapAverage).
                    Where(a => a.HasEnoughLaps).
                    OrderBy(n => n.AverageLapTime));
                return lapAverages;
            }
        }

        public IEnumerable<NLapAverage> BestTenLapAverages
        {
            get
            {
                List<NLapAverage> lapAverages = new List<NLapAverage>();
                lapAverages.AddRange(_vehicleLapTimes.
                    Select(v => v.BestTenLapAverage).
                    Where(a => a.HasEnoughLaps).
                    OrderBy(n => n.AverageLapTime));
                return lapAverages;
            }
        }

        public IEnumerable<NLapAverage> BestTwentyLapAverages
        {
            get
            {
                List<NLapAverage> lapAverages = new List<NLapAverage>();
                lapAverages.AddRange(_vehicleLapTimes.
                    Select(v => v.BestTwentyLapAverage).
                    Where(a => a.HasEnoughLaps).
                    OrderBy(n => n.AverageLapTime));
                return lapAverages;
            }
        }

        public void AddLapTime(VehicleLapTime lapTime)
        {
            var vehicleLaps = _vehicleLapTimes.FirstOrDefault(v => v.CarNumber == lapTime.CarNumber);

            if (vehicleLaps == null)
            {
                vehicleLaps = new VehicleLapTimes(lapTime.CarNumber);
                _vehicleLapTimes.Add(vehicleLaps);
            }

            vehicleLaps.AddLapTime(lapTime);
        }

        public IEnumerable<VehicleLapTimes> GetBestLapAverages(int lapCount)
        {
            return _vehicleLapTimes.OrderByDescending(l => l.GetLastNLapAverages(lapCount));
        }
    }
}

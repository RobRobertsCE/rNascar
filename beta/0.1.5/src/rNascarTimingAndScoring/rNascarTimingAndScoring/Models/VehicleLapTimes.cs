using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rNascarTimingAndScoring.Models
{
    public class VehicleLapTimes
    {
        private IList<VehicleLapTime> _lapTimes = new List<VehicleLapTime>();

        public string CarNumber { get; set; }
        public string Driver { get; set; }

        public VehicleLapTimes(string carNumber, string driver)
        {
            CarNumber = carNumber;
            Driver = driver;
        }

        public NLapAverage LastFiveLapAverage
        {
            get
            {
                return GetLastNLapAverages(5);
            }
        }

        public NLapAverage LastTenLapAverage
        {
            get
            {
                return GetLastNLapAverages(10);
            }
        }

        public NLapAverage LastTwentyLapAverage
        {
            get
            {
                return GetLastNLapAverages(20);
            }
        }

        public NLapAverage BestFiveLapAverage
        {
            get
            {
                return GetBestNLapAverages(5);
            }
        }

        public NLapAverage BestTenLapAverage
        {
            get
            {
                return GetBestNLapAverages(10);
            }
        }

        public NLapAverage BestTwentyLapAverage
        {
            get
            {
                return GetBestNLapAverages(20);
            }
        }

        public void AddLapTime(VehicleLapTime lapTime)
        {
            if (!_lapTimes.Any(l => l.LapNumber == lapTime.LapNumber))
                _lapTimes.Add(lapTime);
        }

        public NLapAverage GetLastNLapAverages(int lapCount)
        {
            if (_lapTimes.Count < lapCount)
            {
                return new NLapAverage()
                {
                    CarNumber = CarNumber,
                    Driver = Driver,
                    StartLap = 0,
                    EndLap = 0,
                    AverageLapSpeed = 0.0,
                    AverageLapTime = 0.0,
                    HasEnoughLaps = false
                };
            }
            var orderedLaps = _lapTimes.OrderByDescending(l => l.LapNumber).Take(lapCount).ToList();

            return new NLapAverage()
            {
                CarNumber = CarNumber,
                Driver = Driver,
                StartLap = orderedLaps.FirstOrDefault().LapNumber,
                EndLap = orderedLaps.LastOrDefault().LapNumber,
                AverageLapSpeed = orderedLaps.Average(l => l.LapSpeed),
                AverageLapTime = orderedLaps.Average(l => l.LapTime)
            };
        }

        public NLapAverage GetBestNLapAverages(int lapCount)
        {
            if (_lapTimes.Count < lapCount)
            {
                return new NLapAverage()
                {
                    CarNumber = CarNumber,
                    Driver = Driver,
                    StartLap = 0,
                    EndLap = 0,
                    AverageLapSpeed = 0.0,
                    AverageLapTime = 0.0,
                    HasEnoughLaps = false
                };
            }

            IList<NLapAverage> averages = new List<NLapAverage>();

            var orderedLaps = _lapTimes.OrderBy(l => l.LapNumber).ToList();

            for (int i = 0; i < orderedLaps.Count - lapCount + 1; i++)
            {
                averages.Add(new NLapAverage()
                {
                    CarNumber = CarNumber,
                    Driver = Driver,
                    StartLap = orderedLaps[i].LapNumber,
                    EndLap = orderedLaps[i + lapCount - 1].LapNumber,
                    AverageLapSpeed = orderedLaps.Skip(i).Take(lapCount).Average(l => l.LapSpeed),
                    AverageLapTime = orderedLaps.Skip(i).Take(lapCount).Average(l => l.LapTime)
                });
            }

            return averages.OrderBy(a => a.AverageLapTime).FirstOrDefault();
        }
    }
}

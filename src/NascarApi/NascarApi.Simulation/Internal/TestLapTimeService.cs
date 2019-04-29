using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NascarApi.Simulation.Models;
using NascarApi.Simulation.Ports;

namespace NascarApi.Simulation.Internal
{
    public class TestLapTimeService : LapTimeService, ILapTimeService
    {

        #region fields

        private double _cautionTime;
        private double _greenFlagTime;
        private double _pitInTime;
        private double _pitOutTime;
        private double _pitStopTime;

        #endregion

        #region ctor

        public TestLapTimeService(
            double trackLength,
            double cautionTime,
            double greenFlagTime,
            double pitInTime,
            double pitOutTime,
            double pitStopTime)
            : base(new NascarTrack() { Length = trackLength, Falloff = 0 })
        {
            _cautionTime = cautionTime;
            _greenFlagTime = greenFlagTime;
            _pitInTime = pitInTime;
            _pitOutTime = pitOutTime;
            _pitStopTime = pitStopTime;
        }

        #endregion

        #region public

        public override LapTimeResult GetCautionLapTime()
        {
            return GetResultFromTime(_cautionTime);
        }

        public override LapTimeResult GetPitInLapTime()
        {
            return GetResultFromTime(_pitInTime);
        }

        public override LapTimeResult GetPitOutLapTime()
        {
            return GetResultFromTime(_pitStopTime + _pitOutTime);
        }

        public override LapTimeResult GetLapTime()
        {
            return GetResultFromTime(_greenFlagTime);
        }

        public override LapTimeResult GetLapTime(int lapsOnTires)
        {
            return GetResultFromTime(_greenFlagTime);
        }

        #endregion
    }
}

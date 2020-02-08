using System;
using NascarApi.Mock.Models;

namespace NascarApi.Mock.Internal
{
    class LapTimeService
    {
        #region consts

        private const int DefaultDecimalPlaces = 3;
        private const double DefaultLapTimeRangePercent = 1.07;
        private const double DefaultFalloffRange = 2;

        #endregion

        #region fields

        private readonly Random _random;
        private readonly int _lapTimeBase;
        private readonly int _lapTimeRange;
        private readonly double _trackLength;
        private readonly double _falloff;
        private readonly double _pitWindow;
        private readonly double _cautionLapSpeed = 80;
        private readonly int _pitStopTime = 60;
        private readonly int _pitStopRange = 10;
        private int _falloffSeconds = 5;

        #endregion

        #region properties

        public int DecimalPlaces { get; set; } = DefaultDecimalPlaces;

        #endregion

        #region ctor

        public LapTimeService(NascarTrack track)
        {
            if (track == null)
                throw new ArgumentNullException(nameof(track));

            if (track.Falloff < 0 || track.Falloff > 1)
                throw new ArgumentOutOfRangeException(nameof(track.Falloff), $"Value: {track.Falloff}");

            _lapTimeBase = track.BaseLapTime;
            _trackLength = track.Length;
            _falloff = track.Falloff;
            _pitWindow = track.PitWindow;

            _lapTimeRange = (int)(_lapTimeBase * DefaultLapTimeRangePercent);

            _random = new Random(DateTime.Now.Millisecond);
        }

        #endregion

        #region public

        public LapTimeResult GetCautionLapTime()
        {
            return new LapTimeResult()
            {
                LapTime = GetCautionLapTime(_cautionLapSpeed),
                LapSpeed = _cautionLapSpeed
            };
        }

        public LapTimeResult GetPitLapTime()
        {
            var lapTime = GeneratePitLapTime();

            return new LapTimeResult()
            {
                LapTime = lapTime,
                LapSpeed = GetLapSpeed(lapTime)
            };
        }

        public LapTimeResult GetLapTime()
        {
            var lapTime = GenerateLapTime();

            return new LapTimeResult()
            {
                LapTime = lapTime,
                LapSpeed = GetLapSpeed(lapTime)
            };
        }

        public LapTimeResult GetLapTime(int lapsOnTires)
        {
            var tireWear = (lapsOnTires / _pitWindow);
            var lapTime = GenerateLapTime(tireWear);

            return new LapTimeResult()
            {
                LapTime = lapTime,
                LapSpeed = GetLapSpeed(lapTime)
            };
        }

        public double GetLapSpeed(double lapTime)
        {
            return Math.Round((_trackLength / lapTime) * 3600, DecimalPlaces);
        }

        #endregion

        #region private

        private double GenerateLapTime()
        {
            return GenerateLapTime(0);
        }

        private double GeneratePitLapTime()
        {
            var pitLapTime = GenerateLapTime();
            var lapTime = pitLapTime + _pitStopTime;
            var randomizedPitTime = lapTime + _random.Next(_pitStopRange);

            return randomizedPitTime;
        }

        private double GenerateLapTime(double tireWear)
        {
            if (tireWear < 0 || tireWear > 1)
                throw new ArgumentOutOfRangeException(nameof(tireWear), $"Value: {tireWear}");

            var minTime = _lapTimeBase + (int)(_falloffSeconds * (_falloff * tireWear));
            var maxTime = _lapTimeRange + (int)(_falloffSeconds * (_falloff * tireWear));

            return _random.Next(minTime, maxTime) +
                Math.Round(_random.NextDouble(), DecimalPlaces) +
                Math.Round(_random.NextDouble(), DecimalPlaces) +
                Math.Round(_random.NextDouble(), DecimalPlaces);
        }

        private double GetCautionLapTime(double cautionSpeed)
        {
            return Math.Round((_trackLength / cautionSpeed) * 3600, DecimalPlaces);
        }

        #endregion
    }
}

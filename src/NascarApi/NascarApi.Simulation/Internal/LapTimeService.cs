using System;
using NascarApi.Simulation.Models;
using NascarApi.Simulation.Ports;

namespace NascarApi.Simulation.Internal
{
    public class LapTimeService : ILapTimeService
    {
        #region consts

        private const int DefaultDecimalPlaces = 3;
        private const double DefaultLapTimeRangePercent = 1.07;
        private const double DefaultFalloffRange = 2;
        private const double DefaultPitInTravelTime = 12.5;
        private const double DefaultPitOutTravelTime = 12.5;
        private const double DefaultPitStopTime = 15;

        #endregion

        #region fields

        private readonly Random _random;
        private readonly int _lapTimeRange;
        private readonly double _trackLength;
        private readonly double _falloff;
        private readonly double _pitWindow;
        private readonly double _cautionLapSpeed = 80;
        private readonly int _totalPitStopTime = 40;
        private readonly int _pitStopRange = 10;
        private readonly int _pitInOutRange = 5;
        private readonly double _pitInTravelTime = DefaultPitInTravelTime;
        private readonly double _pitOutTravelTime = DefaultPitOutTravelTime;
        private readonly double _pitStopTime = DefaultPitStopTime;
        private int _falloffSeconds = 5;

        #endregion

        #region properties

        public int DecimalPlaces { get; set; } = DefaultDecimalPlaces;
        public int BaseLapTime { get; set; }

        #endregion

        #region ctor

        protected LapTimeService()
        {

        }

        public LapTimeService(NascarTrack track)
        {
            if (track == null)
                throw new ArgumentNullException(nameof(track));

            if (track.Falloff < 0 || track.Falloff > 1)
                throw new ArgumentOutOfRangeException(nameof(track.Falloff), $"Value: {track.Falloff}");

            BaseLapTime = track.BaseLapTime;
            _trackLength = track.Length;
            _falloff = track.Falloff;
            _pitWindow = track.PitWindow;

            _lapTimeRange = (int)(BaseLapTime * DefaultLapTimeRangePercent);

            _random = new Random(DateTime.Now.Millisecond);
        }

        #endregion

        #region public

        public virtual LapTimeResult GetLapTime(int lapsOnTires, RaceState raceState, VehicleState vehicleStatus)
        {
            LapTimeResult result = null;

            if (vehicleStatus == VehicleState.OnTrack)
            {
                switch (raceState)
                {
                    case RaceState.PreRace:
                        {
                            result = new LapTimeResult();
                            break;
                        }
                    case RaceState.GreenFlag:
                    case RaceState.WhiteFlag:
                    case RaceState.Checkered:
                    case RaceState.Overdrive:
                        {
                            result = GetLapTime(lapsOnTires);
                            break;
                        }
                    case RaceState.EndOfStage:
                    case RaceState.Caution:
                    case RaceState.OneToGo:
                        {
                            result = GetCautionLapTime();
                            break;
                        }
                    default:
                        throw new ArgumentException($"Unknown race state: {raceState.ToString()}", nameof(raceState));
                }
            }
            else if (vehicleStatus == VehicleState.PitInLap)
            {
                result = GetPitInLapTime();
            }
            else if (vehicleStatus == VehicleState.PitOutLap)
            {
                result = GetPitOutLapTime();
            }
            else if (vehicleStatus == VehicleState.InPit || vehicleStatus == VehicleState.InGarage || vehicleStatus == VehicleState.Retired)
            {
                result = new LapTimeResult();
            }
            else
            {
                throw new ArgumentException($"Unknown vehicle status: {vehicleStatus.ToString()}", nameof(vehicleStatus));
            }

            return result;
        }

        public virtual LapTimeResult GetCautionLapTime()
        {
            return GetResultFromSpeed(_cautionLapSpeed);
        }

        public virtual LapTimeResult GetPitInLapTime()
        {
            var cautionLapTime = GetLapTime(_cautionLapSpeed);
            var pitInTime = GetPitInTravelTime();

            var totalLapTime = cautionLapTime + pitInTime;

            return GetResultFromTime(totalLapTime);
        }

        public virtual LapTimeResult GetPitOutLapTime()
        {
            var stopTime = GetPitStopTime();
            var pitOutTime = GetPitOutTravelTime();
            var cautionLapTime = GetLapTime(_cautionLapSpeed);

            var totalLapTime = stopTime + pitOutTime + cautionLapTime;

            return GetResultFromTime(totalLapTime);
        }

        public virtual LapTimeResult GetLapTime()
        {
            return GetResultFromTime(GenerateLapTime());
        }

        public virtual LapTimeResult GetLapTime(int lapsOnTires)
        {
            return GetResultFromTime(GenerateLapTime((lapsOnTires / _pitWindow)));
        }

        public virtual double GetLapSpeed(double lapTime)
        {
            return Math.Round((_trackLength / lapTime) * 3600, DecimalPlaces);
        }

        public virtual double GetLapTime(double lapSpeed)
        {
            return Math.Round((_trackLength / lapSpeed) * 3600, DecimalPlaces);
        }

        #endregion

        #region protected

        protected virtual double GenerateLapTime()
        {
            return GenerateLapTime(0);
        }

        protected virtual double GenerateLapTime(double tireWear)
        {
            if (tireWear < 0 || tireWear > 1)
                throw new ArgumentOutOfRangeException(nameof(tireWear), $"Value: {tireWear}");

            var minTime = BaseLapTime + (int)(_falloffSeconds * (_falloff * tireWear));
            var maxTime = _lapTimeRange + (int)(_falloffSeconds * (_falloff * tireWear));

            return _random.Next(minTime, maxTime) +
                Math.Round(_random.NextDouble(), DecimalPlaces) +
                Math.Round(_random.NextDouble(), DecimalPlaces) +
                Math.Round(_random.NextDouble(), DecimalPlaces);
        }

        protected virtual LapTimeResult GetResultFromTime(double lapTime)
        {
            return new LapTimeResult()
            {
                LapTime = lapTime,
                LapSpeed = GetLapSpeed(lapTime)
            };
        }

        protected virtual LapTimeResult GetResultFromSpeed(double lapSpeed)
        {
            return new LapTimeResult()
            {
                LapTime = GetLapTime(lapSpeed),
                LapSpeed = lapSpeed
            };
        }

        protected virtual double GetPitInTravelTime()
        {
            return _pitInTravelTime + _random.Next(_pitInOutRange);
        }

        protected virtual double GetPitOutTravelTime()
        {
            return _pitOutTravelTime + _random.Next(_pitInOutRange);
        }

        protected virtual double GetPitStopTime()
        {
            return _pitStopTime + _random.Next(_pitStopRange);
        }

        #endregion
    }
}

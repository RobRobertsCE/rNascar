using System;
using System.Collections.Generic;
using System.Linq;
using NascarApi.Simulation.Models;
using NascarApi.Simulation.Ports;

namespace NascarApi.Simulation.Internal
{
    public class VehicleLapService2 : VehicleLapService, IVehicleLapService
    {
        #region events

        public delegate RaceState GetRaceState();

        public event EventHandler<LapCompleteEventArgs> LapComplete;
        protected virtual void OnLapComplete(List<NascarRaceLap> vehicleLaps)
        {
            var handler = LapComplete;

            if (handler != null)
                handler.Invoke(this, new LapCompleteEventArgs() { Laps = vehicleLaps });
        }

        public event EventHandler<RaceStateChangedEventArgs> RaceStateChanged;
        protected virtual void OnRaceStateChanged(RaceState state)
        {
            var handler = RaceStateChanged;

            if (handler != null)
                handler.Invoke(this, new RaceStateChangedEventArgs() { RaceState = state });
        }

        #endregion

        #region fields

        private List<NascarRaceLap> _vehicles;
        private readonly List<VehicleEvent> _vehicleEvents = new List<VehicleEvent>();
        private readonly EventState _state = new EventState();
        private int _lapNumber;
        private int _actualRaceEndLap;

        #endregion

        #region properties

        //public ILapTimeService LapTimeService { get; set; }

        #endregion

        #region ctor

        public VehicleLapService2(ILapTimeService lapTimeService)
            : base(lapTimeService)
        {
            // LapTimeService = lapTimeService ?? throw new ArgumentNullException(nameof(lapTimeService));
        }

        #endregion

        #region public

        public override List<NascarRaceLap> UpdateRaceLaps(List<NascarRaceLap> vehicles, RaceState state)
        {
            if (state == RaceState.PreRace)
            {
                RegisterRaceVehicles(vehicles);
            }
            else
            {
                foreach (NascarRaceLap vehicle in vehicles)
                {
                    ProcessLap(vehicle, state);
                }
            }

            return vehicles;
        }

        #endregion

        #region protected

        protected virtual void RegisterRaceVehicles(List<NascarRaceLap> vehicles)
        {
            try
            {
                foreach (NascarRaceLap vehicle in vehicles)
                {
                    _state.RegisterVehicle(vehicle);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        protected virtual void ProcessLap(NascarRaceLap vehicle, RaceState state)
        {
            switch (state)
            {
                case RaceState.PreRace:
                    {
                        throw new ArgumentException($"Invalid state in LapService.ProcessLap: {state.ToString()}");
                    }
                case RaceState.GreenFlag:
                case RaceState.WhiteFlag:
                case RaceState.Checkered:
                case RaceState.Overdrive:
                    {
                        ProcessGreenFlagLap(vehicle);
                        break;
                    }
                case RaceState.EndOfStage:
                case RaceState.Caution:
                case RaceState.OneToGo:
                    {
                        ProcessCautionFlagLap(vehicle);
                        break;
                    }
                default:
                    {
                        throw new ArgumentException($"Unknown race state in LapService.ProcessLap: {state.ToString()}", nameof(state));
                    }
            }
        }

        protected virtual void ProcessGreenFlagLap(NascarRaceLap vehicle)
        {
            var vehicleStatus = _state.Vehicles[vehicle.VehicleId];

            // Update the status for this lap

            switch (vehicleStatus.VehicleState)
            {
                case VehicleState.OnTrack:
                    {
                        if (vehicle.PitInLap)
                            vehicleStatus.VehicleState = VehicleState.PitInLap;

                        vehicleStatus.LapNumber += 1;
                        break;
                    }
                case VehicleState.PitInLap:
                    {
                        vehicleStatus.VehicleState = VehicleState.PitOutLap;
                        vehicleStatus.LastPitStop = _lapNumber;
                        vehicleStatus.LapNumber += 1;
                        break;
                    }
                case VehicleState.PitOutLap:
                    {
                        vehicleStatus.VehicleState = VehicleState.OnTrack;
                        vehicleStatus.LapNumber += 1;
                        break;
                    }
                case VehicleState.InPit:
                case VehicleState.InGarage:
                case VehicleState.Retired:
                default:
                    break;
            }

            if (vehicleStatus.VehicleState != VehicleState.InPit &&
                vehicleStatus.VehicleState != VehicleState.InGarage &&
                vehicleStatus.VehicleState != VehicleState.Retired)
            {
                var lapTimeResult = LapTimeService.GetLapTime(vehicle.LapsSincePit, RaceState.GreenFlag, vehicleStatus.VehicleState);

                var newVehicleEvent = new VehicleEvent()
                {
                    VehicleId = vehicle.VehicleId,
                    Elapsed = vehicleStatus.Elapsed.Add(lapTimeResult.Elapsed),
                    LapNumber = vehicleStatus.LapNumber,
                    VehicleEventType =
                        vehicleStatus.VehicleState == VehicleState.PitInLap ?
                            VehicleEventType.EnterPit :
                        vehicleStatus.VehicleState == VehicleState.PitOutLap ?
                            VehicleEventType.ExitPit :
                            VehicleEventType.CompleteLap
                };

                vehicleStatus.Elapsed = newVehicleEvent.Elapsed;
                vehicleStatus.LapNumber = newVehicleEvent.LapNumber;

                // needed?
                _state.Vehicles[vehicle.VehicleId] = vehicleStatus;

                _vehicleEvents.Add(newVehicleEvent);
            }
        }

        protected virtual void ProcessCautionFlagLap(NascarRaceLap vehicle)
        {
            var vehicleStatus = _state.Vehicles[vehicle.VehicleId];

            // Update the status for this lap

            switch (vehicleStatus.VehicleState)
            {
                case VehicleState.OnTrack:
                    {
                        if (vehicle.PitInLap)
                            vehicleStatus.VehicleState = VehicleState.PitInLap;

                        vehicleStatus.LapNumber += 1;
                        break;
                    }
                case VehicleState.PitInLap:
                    {
                        vehicleStatus.VehicleState = VehicleState.PitOutLap;
                        vehicleStatus.LastPitStop = _lapNumber;
                        vehicleStatus.LapNumber += 1;
                        break;
                    }
                case VehicleState.PitOutLap:
                    {
                        vehicleStatus.VehicleState = VehicleState.OnTrack;
                        vehicleStatus.LapNumber += 1;
                        break;
                    }
                case VehicleState.InPit:
                case VehicleState.InGarage:
                case VehicleState.Retired:
                default:
                    break;
            }

            if (vehicleStatus.VehicleState != VehicleState.InPit &&
                vehicleStatus.VehicleState != VehicleState.InGarage &&
                vehicleStatus.VehicleState != VehicleState.Retired)
            {
                var lapTimeResult = LapTimeService.GetLapTime(vehicle.LapsSincePit, RaceState.Caution, vehicleStatus.VehicleState);

                var newVehicleEvent = new VehicleEvent()
                {
                    VehicleId = vehicle.VehicleId,
                    Elapsed = vehicleStatus.Elapsed.Add(lapTimeResult.Elapsed),
                    LapNumber = vehicleStatus.LapNumber,
                    VehicleEventType =
                        vehicleStatus.VehicleState == VehicleState.PitInLap ?
                            VehicleEventType.EnterPit :
                        vehicleStatus.VehicleState == VehicleState.PitOutLap ?
                            VehicleEventType.ExitPit :
                            VehicleEventType.CompleteLap
                };

                _vehicleEvents.Add(newVehicleEvent);
            }
        }

        #endregion

        #region classes

        private class EventState
        {
            public IDictionary<int, VehicleStatus> Vehicles { get; set; }

            public RaceState RaceState { get; set; }

            public EventState()
            {
                Vehicles = new Dictionary<int, VehicleStatus>();
            }

            public void RegisterVehicle(NascarRaceLap vehicle)
            {
                if (Vehicles.Keys.Contains(vehicle.VehicleId))
                {
                    throw new ArgumentException($"Already registered vehicle {vehicle.VehicleId}");
                }

                Vehicles.Add(vehicle.VehicleId, new VehicleStatus()
                {
                    VehicleState = VehicleState.OnTrack,
                    LapNumber = 0,
                    LapsDown = 0,
                    DeltaLeader = vehicle.DeltaLeader,
                    DeltaNext = vehicle.Delta
                });
            }
        }

        #endregion
    }

    public class VehicleStatus
    {
        public int LapNumber { get; set; }
        public TimeSpan Elapsed { get; set; }
        public int LapsDown { get; set; }
        public int? LastPitStop { get; set; }
        public double DeltaNext { get; set; }
        public double DeltaLeader { get; set; }
        public VehicleState VehicleState { get; set; }
    }

    public enum VehicleEventType
    {
        StartEvent,
        CompleteLap,
        EnterPit,
        ExitPit,
        RetireFromEvent
    }

    public class VehicleEvent
    {
        public int VehicleId { get; set; }
        public VehicleEventType VehicleEventType { get; set; }
        public int LapNumber { get; set; }
        public TimeSpan Elapsed { get; set; }
    }

    public class LapCompleteEventArgs : EventArgs
    {
        public List<NascarRaceLap> Laps { get; set; }
    }

    public class RaceStateChangedEventArgs : EventArgs
    {
        public RaceState RaceState { get; set; }
    }

    public enum VehicleState
    {
        OnTrack,
        PitInLap,
        InPit,
        PitOutLap,
        InGarage,
        Retired
    }

}

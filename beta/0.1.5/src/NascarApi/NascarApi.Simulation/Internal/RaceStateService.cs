using System;

namespace NascarApi.Mock.Internal
{
    internal class RaceStateService
    {
        #region events

        public event EventHandler<RaceState> RaceStateChanged;
        protected virtual void OnRaceStateChanged(RaceState state)
        {
            var handler = RaceStateChanged;

            if (handler != null)
                handler.Invoke(this, state);
        }

        #endregion

        #region properties

        private RaceState _state;
        public RaceState State
        {
            get
            {
                return _state;
            }
            private set
            {
                _state = value;

                OnRaceStateChanged(_state);
            }
        }

        public bool IsCaution
        {
            get
            {
                return _state.HasFlag(RaceState.Caution);
            }
        }

        public bool IsWhiteFlag
        {
            get
            {
                return _state.HasFlag(RaceState.WhiteFlag);
            }
        }

        public bool IsGreenFlag
        {
            get
            {
                return _state.HasFlag(RaceState.GreenFlag);
            }
        }

        public bool IsEndOfStage
        {
            get
            {
                return _state.HasFlag(RaceState.EndOfStage);
            }
        }

        public bool IsOverdrive
        {
            get
            {
                return _state.HasFlag(RaceState.Overdrive);
            }
        }

        #endregion

        #region ctor

        public RaceStateService()
        {
            Initialize();
        }

        #endregion

        #region public

        public RaceState Initialize()
        {
            _state = RaceState.PreRace;
            return _state;
        }
        public RaceState CautionOn()
        {
            _state = _state | RaceState.Caution;
            _state &= ~(RaceState.GreenFlag);
            return _state;
        }
        //public RaceState CautionOff()
        //{
        //    _state &= ~(RaceState.Caution | RaceState.EndOfStage);
        //    _state &= ~(RaceState.GreenFlag);
        //    return _state;
        //}
        public RaceState EndOfStageOn()
        {
            _state = _state | RaceState.EndOfStage | RaceState.Caution;
            _state &= ~(RaceState.GreenFlag);
            return _state;
        }
        public RaceState GreenFlagOn()
        {
            _state &= ~(RaceState.Caution | RaceState.EndOfStage | RaceState.PreRace);
            _state = _state | RaceState.GreenFlag;
            return _state;
        }
        public RaceState OverdriveOn()
        {
            _state = _state | RaceState.Overdrive;
            return _state;
        }
        public RaceState WhiteFlagOn()
        {
            _state = _state | RaceState.WhiteFlag;
            return _state;
        }
        public RaceState CheckeredFlagOn()
        {
            _state = _state | RaceState.Checkered;
            return _state;
        }

        #endregion
    }
}

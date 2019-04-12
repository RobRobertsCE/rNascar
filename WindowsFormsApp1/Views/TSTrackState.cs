using System.Drawing;
using System.Windows.Forms;
using rNascarTimingAndScoring.Models;

namespace rNascarTimingAndScoring.Views
{
    public partial class TSTrackState : UserControl
    {
        private TrackStates _trackState;
        public TrackStates TrackState
        {
            get
            {
                return _trackState;
            }
            set
            {
                _trackState = value;
                DisplayTrackState(_trackState);
            }
        }

        public string LapInfo
        {
            get
            {
                return tsOutlinedLabel1.Text;
            }
            set
            {
                tsOutlinedLabel1.Text = value;
            }
        }

        public TSTrackState()
        {
            InitializeComponent();

            toolTip1.SetToolTip(picTrackState, TrackState.ToString());
        }

        protected virtual void DisplayTrackState(TrackStates trackState)
        {
            switch (trackState)
            {
                case TrackStates.Green:
                    {
                        picTrackState.BackColor = Color.LimeGreen;
                        tsOutlinedLabel1.BackColor = Color.LimeGreen;
                        toolTip1.SetToolTip(picTrackState, "Green");
                        break;
                    }
                case TrackStates.Caution:
                    {
                        picTrackState.BackColor = Color.Yellow;
                        tsOutlinedLabel1.BackColor = Color.Yellow;
                        toolTip1.SetToolTip(picTrackState, "Caution");
                        break;
                    }
                case TrackStates.Red:
                    {
                        picTrackState.BackColor = Color.Red;
                        tsOutlinedLabel1.BackColor = Color.Red;
                        toolTip1.SetToolTip(picTrackState, "Red Flag");
                        break;
                    }
                case TrackStates.Checkered:
                    {
                        picTrackState.BackColor = Color.White;
                        tsOutlinedLabel1.BackColor = Color.White;
                        toolTip1.SetToolTip(picTrackState, "Checkered Flag");
                        break;
                    }
                case TrackStates.Warm:
                    {
                        picTrackState.BackColor = Color.Orange;
                        tsOutlinedLabel1.BackColor = Color.Orange;
                        toolTip1.SetToolTip(picTrackState, "Track Is Warm");
                        break;
                    }
                case TrackStates.NotActive:
                    {
                        picTrackState.BackColor = Color.DeepSkyBlue;
                        tsOutlinedLabel1.BackColor = Color.DeepSkyBlue;
                        toolTip1.SetToolTip(picTrackState, "Not Active");
                        break;
                    }
                default:
                    {
                        picTrackState.BackColor = Color.Black;
                        toolTip1.SetToolTip(picTrackState, "");
                        break;
                    }
            }
        }
    }
}

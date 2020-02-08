using System.Windows.Forms;
using rNascarTimingAndScoring.Models;

namespace rNascarTimingAndScoring.Views
{
    public partial class TSDriverFastestLap : UserControl
    {
        public string FastestLapTime
        {
            get
            {
                return lblFastestLapTime.Text;
            }
            set
            {
                lblFastestLapTime.Text = value;
            }
        }

        public string FastestLapNumber
        {
            get
            {
                return lblFastestLapNumber.Text;
            }
            set
            {
                lblFastestLapNumber.Text = value;
            }
        }

        private bool _isFastestLap = false;
        public bool IsFastestLap
        {
            get
            {
                return _isFastestLap;
            }
            set
            {
                _isFastestLap = value;
                UpdateForeColor();              
            }
        }

        private bool _isOffTrack = false;
        public bool IsOffTrack
        {

            get
            {
                return _isOffTrack;
            }
            set
            {
                _isOffTrack = value;
                UpdateForeColor();
            }
        }

        public TSDriverFastestLap()
        {
            InitializeComponent();
        }

        protected virtual void UpdateForeColor()
        {
            if (_isOffTrack)
            {
                lblFastestLapNumber.ForeColor = TSColorMap.OutOfEventColor;
                lblFastestLapTime.ForeColor = TSColorMap.OutOfEventColor;
            }
            else if (_isFastestLap)
            {
                lblFastestLapNumber.ForeColor = TSColorMap.NewFastestLapForeColor;
                lblFastestLapTime.ForeColor = TSColorMap.NewFastestLapForeColor;
            }
            else
            {
                lblFastestLapNumber.ForeColor = TSColorMap.FastestLapNumberForeColor;
                lblFastestLapTime.ForeColor = TSColorMap.FastestLapTimeForeColor;
            }
        }
    }
}

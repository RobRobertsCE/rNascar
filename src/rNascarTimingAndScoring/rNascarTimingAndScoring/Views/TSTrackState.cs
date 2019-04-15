using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using rNascarTimingAndScoring.Models;

namespace rNascarTimingAndScoring.Views
{
    public partial class TSTrackState : UserControl
    {
        public Color OutlineForeColor { get; set; }
        public float OutlineWidth { get; set; }

        private TrackState _trackState;
        public TrackState TrackState
        {
            get
            {
                return _trackState;
            }
            set
            {
                _trackState = value;
                DisplayTrackState(_trackState);
                this.Invalidate();
            }
        }

        private string _lapInfo = string.Empty;
        public string LapInfo
        {
            get
            {
                return _lapInfo;
            }
            set
            {
                _lapInfo = value;
                this.Invalidate();
            }
        }

        public TSTrackState()
        {
            InitializeComponent();

            toolTip1.SetToolTip(picTrackState, TrackState.ToString());

            OutlineForeColor = Color.Black;
            OutlineWidth = 2;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (string.IsNullOrEmpty(_lapInfo))
                return;

            SizeF size = e.Graphics.MeasureString(_lapInfo, Font);

            using (GraphicsPath gp = new GraphicsPath())
            {
                using (Pen outline = new Pen(OutlineForeColor, OutlineWidth) { LineJoin = LineJoin.Round })
                {
                    using (StringFormat sf = new StringFormat())
                    {
                        using (Brush foreBrush = new SolidBrush(ForeColor))
                        {
                            gp.AddString(
                                _lapInfo,
                                Font.FontFamily,
                                (int)Font.Style,
                                Font.Size,
                                ClientRectangle,
                                sf);

                            e.Graphics.TranslateTransform((ClientRectangle.Width / 2) - (size.Width / 2), (ClientRectangle.Height / 2) - (size.Height / 2));
                            e.Graphics.ScaleTransform(1.3f, 1.35f);
                            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                            e.Graphics.DrawPath(outline, gp);
                            e.Graphics.FillPath(foreBrush, gp);
                        }
                    }
                }
            }

        }

        protected virtual void DisplayTrackState(TrackState trackState)
        {
            switch (trackState)
            {
                case TrackState.Green:
                    {
                        picTrackState.Image = Properties.Resources.track_state_green;
                        toolTip1.SetToolTip(picTrackState, "Green");
                        break;
                    }
                case TrackState.Caution:
                    {
                        picTrackState.Image = Properties.Resources.track_state_yellow;
                        toolTip1.SetToolTip(picTrackState, "Caution");
                        break;
                    }
                case TrackState.Red:
                    {
                        picTrackState.Image = Properties.Resources.track_state_red;
                        toolTip1.SetToolTip(picTrackState, "Red Flag");
                        break;
                    }
                case TrackState.Checkered:
                    {
                        picTrackState.Image = Properties.Resources.track_state_checkers;
                        toolTip1.SetToolTip(picTrackState, "Checkered Flag");
                        break;
                    }
                case TrackState.Warm:
                    {
                        picTrackState.Image = Properties.Resources.track_state_warm;
                        toolTip1.SetToolTip(picTrackState, "Track Is Warm");
                        break;
                    }
                case TrackState.NotActive:
                    {
                        picTrackState.Image = Properties.Resources.track_state_cold;
                        toolTip1.SetToolTip(picTrackState, "Not Active");
                        break;
                    }
                default:
                    {
                        picTrackState.Image = Properties.Resources.track_state_cold;
                        toolTip1.SetToolTip(picTrackState, "");
                        break;
                    }
            }
        }

        private void picTrackState_Paint(object sender, PaintEventArgs e)
        {
            OnPaint(e);
        }
    }
}

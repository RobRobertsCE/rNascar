using System;
using System.ComponentModel;
using System.Windows.Forms;
using rNascarTimingAndScoring.Models;

namespace rNascarTimingAndScoring.Views
{
    public partial class TSLeaderboardDriver : UserControl
    {
        LeaderboardRowWidths _columnWidths = new LeaderboardRowWidths();
        public LeaderboardRowWidths ColumnWidths
        {
            get
            {
                return _columnWidths;
            }
            set
            {
                _columnWidths = value;
                SetColumnWidths(_columnWidths);
            }
        }

        public TSConfiguration Configuration { get; set; }

        private TSDriverModel _model = new TSDriverModel();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TSDriverModel Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                UpdateDisplay(_model);

            }
        }

        public TSLeaderboardDriver()
        {
            InitializeComponent();
        }

        private void TSLeaderboardRow_Load(object sender, EventArgs e)
        {
            SetColumnWidths(ColumnWidths);
        }

        protected virtual void SetColumnWidths(LeaderboardRowWidths columnWidths)
        {
            tableLayoutPanel1.ColumnStyles[(int)LeaderboardColumns.Position].Width = columnWidths.PositionWidth;
            tableLayoutPanel1.ColumnStyles[(int)LeaderboardColumns.CarNumber].Width = columnWidths.CarNumberWidth;
            tableLayoutPanel1.ColumnStyles[(int)LeaderboardColumns.Manufacturer].Width = columnWidths.ManufacturerWidth;
            tableLayoutPanel1.ColumnStyles[(int)LeaderboardColumns.Behind].Width = columnWidths.BehindWidth;
            tableLayoutPanel1.ColumnStyles[(int)LeaderboardColumns.LastLap].Width = columnWidths.LastLapWidth;
            tableLayoutPanel1.ColumnStyles[(int)LeaderboardColumns.FastestLap].Width = columnWidths.FastestLapWidth;
            tableLayoutPanel1.ColumnStyles[(int)LeaderboardColumns.LastPit].Width = columnWidths.LastPitWidth;
            tableLayoutPanel1.ColumnStyles[(int)LeaderboardColumns.StartPosition].Width = columnWidths.StartPositionWidth;
        }

        protected virtual void UpdateDisplay(TSDriverModel model)
        {
            if (model == null)
                return;

            this.BackColor = model.Position % 2 == 1 ?
               TSColorMap.AlternatingRowBackColor0 :
               TSColorMap.AlternatingRowBackColor1;

            this.tsDriverFastestLap1.BackColor = this.BackColor;

            lblPosition.Text = $"{model.Position}.";
            lblCar.Text = model.CarNumber.ToString();
            lblDriver.Text = model.Driver;
            lblBehind.Text = model.BehindLeader == 0 ? "- -" : model.BehindLeader < 0 ? $"{(model.BehindLeader * -1)} laps" : model.BehindLeader.ToString("0.00");
            lblLastLap.Text = model.LastLapTime.ToString("##.00");
            tsDriverFastestLap1.FastestLapTime = model.FastestLapTime.ToString("0.00");
            tsDriverFastestLap1.FastestLapNumber = model.FastestLapNumber.ToString();
            tsDriverFastestLap1.IsFastestLap = model.LastLapTime <= model.FastestLapTime;
            if (Configuration.RunType == RunType.Race)
            {
                lblLastPit.Text = model.LastPitLap.ToString();
                lblStart.Text = model.StartPosition.ToString();
            }
            else
            {
                lblLastPit.Text = String.Empty;
                lblStart.Text = String.Empty;
            }

            if (tsDriverFastestLap1.IsFastestLap)
            {
                lblLastLap.ForeColor = TSColorMap.NewFastestLapForeColor;
            }
            else
            {
                lblLastLap.ForeColor = TSColorMap.LastLapForeColor;
            }

            if (Configuration.RunType == RunType.Race)
            {
                if (model.StartPosition < model.Position)
                {
                    lblStart.ForeColor = TSColorMap.StartPositionLossForeColor;
                }
                else if (model.StartPosition > model.Position)
                {
                    lblStart.ForeColor = TSColorMap.StartPositionGainForeColor;
                }
                else
                {
                    lblStart.ForeColor = TSColorMap.StartPositionForeColor;
                }

                var lapsSinceLastPit = model.LapsComplete - model.LastPitLap;

                if (lapsSinceLastPit > Configuration.PitWindow)
                {
                    lblLastPit.ForeColor = TSColorMap.LastPitOverLimitForeColor;
                }
                else if (lapsSinceLastPit + Configuration.PitWindowWarning > Configuration.PitWindow)
                {
                    lblLastPit.ForeColor = TSColorMap.LastPitWarningForeColor;
                }
                else
                {
                    lblLastPit.ForeColor = TSColorMap.LastPitForeColor;
                }
            }
            else
            {
                lblStart.ForeColor = TSColorMap.StartPositionForeColor;
                lblLastPit.ForeColor = TSColorMap.LastPitForeColor;
            }

            if ((Configuration.BattleGap > 0) && model.BehindNext > 0 && model.BehindNext < Configuration.BattleGap)
            {
                lblBehind.ForeColor = TSColorMap.BehindWithinBattleGapForeColor;
                lblDriver.ForeColor = TSColorMap.DriverWithinBattleGapForeColor;
            }
            else
            {
                lblBehind.ForeColor = TSColorMap.BehindForeColor;
                lblDriver.ForeColor = TSColorMap.DriverForeColor;
            }

           

            switch (model.Manufacturer)
            {
                case "Tyt":
                    {
                        picManufacturer.Image = rNascarTimingAndScoring.Properties.Resources.toyota_logo;
                        break;
                    }
                case "Frd":
                    {
                        picManufacturer.Image = rNascarTimingAndScoring.Properties.Resources.ford_logo;
                        break;
                    }

                case "Chv":
                    {
                        picManufacturer.Image = rNascarTimingAndScoring.Properties.Resources.chevy_logo;
                        break;
                    }
            }
        }
    }
}

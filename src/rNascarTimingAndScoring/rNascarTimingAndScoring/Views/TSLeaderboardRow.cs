using System;
using System.ComponentModel;
using System.Windows.Forms;
using rNascarTimingAndScoring.Models;

namespace rNascarTimingAndScoring.Views
{
    public partial class TSLeaderboardRow : UserControl
    {
        LeaderboardRowWidths _columnWidths = new LeaderboardRowWidths();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        public TSLeaderboardRow()
        {
            InitializeComponent();
        }

        protected virtual void TSLeaderboardRow_Load(object sender, EventArgs e)
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
    }
}

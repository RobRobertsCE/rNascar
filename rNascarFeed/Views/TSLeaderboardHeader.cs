using System;
using rNascarTimingAndScoring.Models;

namespace rNascarTimingAndScoring.Views
{
    public partial class TSLeaderboardHeader : TSLeaderboardRow
    {
        public TSLeaderboardHeader()
        {
            InitializeComponent();
        }

        protected virtual void TSLeaderboardHeader_Load(object sender, EventArgs e)
        {
            SetColumnWidths(ColumnWidths);
        }

        protected override void SetColumnWidths(LeaderboardRowWidths columnWidths)
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

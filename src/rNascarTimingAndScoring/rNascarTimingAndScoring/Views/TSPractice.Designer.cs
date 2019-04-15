namespace rNascarTimingAndScoring.Views
{
    partial class TSPractice
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlLeaderboard = new System.Windows.Forms.Panel();
            this.tsLeaderboard1 = new rNascarTimingAndScoring.Views.TSLeaderboard();
            this.pnlFastLapsAndPoints = new System.Windows.Forms.Panel();
            this.tsFastestLaps1 = new rNascarTimingAndScoring.Views.TSFastestLaps();
            this.tsLapAveragesGrid1 = new rNascarTimingAndScoring.Views.TSLapAveragesGrid();
            this.pnlLeaderboard.SuspendLayout();
            this.pnlFastLapsAndPoints.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeaderboard
            // 
            this.pnlLeaderboard.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnlLeaderboard.Controls.Add(this.tsLeaderboard1);
            this.pnlLeaderboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeaderboard.Location = new System.Drawing.Point(0, 0);
            this.pnlLeaderboard.Name = "pnlLeaderboard";
            this.pnlLeaderboard.Size = new System.Drawing.Size(891, 781);
            this.pnlLeaderboard.TabIndex = 8;
            // 
            // tsLeaderboard1
            // 
            this.tsLeaderboard1.BackColor = System.Drawing.Color.Black;
            this.tsLeaderboard1.Configuration = null;
            this.tsLeaderboard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsLeaderboard1.Location = new System.Drawing.Point(0, 0);
            this.tsLeaderboard1.MaxRowCount = 20;
            this.tsLeaderboard1.Name = "tsLeaderboard1";
            this.tsLeaderboard1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.tsLeaderboard1.Size = new System.Drawing.Size(891, 781);
            this.tsLeaderboard1.TabIndex = 7;
            // 
            // pnlFastLapsAndPoints
            // 
            this.pnlFastLapsAndPoints.BackColor = System.Drawing.Color.Black;
            this.pnlFastLapsAndPoints.Controls.Add(this.tsLapAveragesGrid1);
            this.pnlFastLapsAndPoints.Controls.Add(this.tsFastestLaps1);
            this.pnlFastLapsAndPoints.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFastLapsAndPoints.Location = new System.Drawing.Point(891, 0);
            this.pnlFastLapsAndPoints.Margin = new System.Windows.Forms.Padding(1);
            this.pnlFastLapsAndPoints.Name = "pnlFastLapsAndPoints";
            this.pnlFastLapsAndPoints.Padding = new System.Windows.Forms.Padding(1);
            this.pnlFastLapsAndPoints.Size = new System.Drawing.Size(327, 781);
            this.pnlFastLapsAndPoints.TabIndex = 9;
            // 
            // tsFastestLaps1
            // 
            this.tsFastestLaps1.BackColor = System.Drawing.Color.Navy;
            this.tsFastestLaps1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tsFastestLaps1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsFastestLaps1.Location = new System.Drawing.Point(1, 1);
            this.tsFastestLaps1.Margin = new System.Windows.Forms.Padding(4);
            this.tsFastestLaps1.MaxRows = 15;
            this.tsFastestLaps1.Name = "tsFastestLaps1";
            this.tsFastestLaps1.Padding = new System.Windows.Forms.Padding(1);
            this.tsFastestLaps1.Size = new System.Drawing.Size(325, 427);
            this.tsFastestLaps1.TabIndex = 1;
            this.tsFastestLaps1.ValueColumnWidth = 80;
            // 
            // tsLapAveragesGrid1
            // 
            this.tsLapAveragesGrid1.BackColor = System.Drawing.Color.MidnightBlue;
            this.tsLapAveragesGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsLapAveragesGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsLapAveragesGrid1.Location = new System.Drawing.Point(1, 428);
            this.tsLapAveragesGrid1.Margin = new System.Windows.Forms.Padding(1);
            this.tsLapAveragesGrid1.MaxRows = null;
            this.tsLapAveragesGrid1.Name = "tsLapAveragesGrid1";
            this.tsLapAveragesGrid1.Padding = new System.Windows.Forms.Padding(1);
            this.tsLapAveragesGrid1.Size = new System.Drawing.Size(325, 352);
            this.tsLapAveragesGrid1.TabIndex = 2;
            this.tsLapAveragesGrid1.ValueColumnWidth = 92;
            // 
            // TSPractice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlLeaderboard);
            this.Controls.Add(this.pnlFastLapsAndPoints);
            this.Name = "TSPractice";
            this.Size = new System.Drawing.Size(1218, 781);
            this.pnlLeaderboard.ResumeLayout(false);
            this.pnlFastLapsAndPoints.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeaderboard;
        private TSLeaderboard tsLeaderboard1;
        private System.Windows.Forms.Panel pnlFastLapsAndPoints;
        private TSFastestLaps tsFastestLaps1;
        private TSLapAveragesGrid tsLapAveragesGrid1;
    }
}

namespace rNascarTimingAndScoring.Views
{
    partial class TSLeaderboardRow
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
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblCar = new System.Windows.Forms.Label();
            this.picManufacturer = new System.Windows.Forms.PictureBox();
            this.lblDriver = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblFastestLapTime = new System.Windows.Forms.Label();
            this.lblBehind = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblLastPit = new System.Windows.Forms.Label();
            this.lblLastLap = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picManufacturer)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPosition
            // 
            this.lblPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPosition.Location = new System.Drawing.Point(4, 0);
            this.lblPosition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(39, 23);
            this.lblPosition.TabIndex = 0;
            this.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCar
            // 
            this.lblCar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCar.Location = new System.Drawing.Point(51, 0);
            this.lblCar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCar.Name = "lblCar";
            this.lblCar.Size = new System.Drawing.Size(52, 23);
            this.lblCar.TabIndex = 1;
            this.lblCar.Text = "CAR";
            this.lblCar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picManufacturer
            // 
            this.picManufacturer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picManufacturer.Location = new System.Drawing.Point(107, 0);
            this.picManufacturer.Margin = new System.Windows.Forms.Padding(0);
            this.picManufacturer.Name = "picManufacturer";
            this.picManufacturer.Size = new System.Drawing.Size(107, 23);
            this.picManufacturer.TabIndex = 2;
            this.picManufacturer.TabStop = false;
            // 
            // lblDriver
            // 
            this.lblDriver.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDriver.Location = new System.Drawing.Point(218, 0);
            this.lblDriver.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDriver.Name = "lblDriver";
            this.lblDriver.Size = new System.Drawing.Size(353, 23);
            this.lblDriver.TabIndex = 3;
            this.lblDriver.Text = "DRIVER";
            this.lblDriver.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel1.Controls.Add(this.lblFastestLapTime, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPosition, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblCar, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.picManufacturer, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDriver, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblBehind, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblStart, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblLastPit, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblLastLap, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1136, 23);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // lblFastestLapTime
            // 
            this.lblFastestLapTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFastestLapTime.Location = new System.Drawing.Point(793, 0);
            this.lblFastestLapTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFastestLapTime.Name = "lblFastestLapTime";
            this.lblFastestLapTime.Size = new System.Drawing.Size(125, 23);
            this.lblFastestLapTime.TabIndex = 9;
            this.lblFastestLapTime.Text = "FASTEST LAP";
            this.lblFastestLapTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBehind
            // 
            this.lblBehind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBehind.Location = new System.Drawing.Point(579, 0);
            this.lblBehind.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBehind.Name = "lblBehind";
            this.lblBehind.Size = new System.Drawing.Size(99, 23);
            this.lblBehind.TabIndex = 4;
            this.lblBehind.Text = "BEHIND";
            this.lblBehind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStart
            // 
            this.lblStart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStart.Location = new System.Drawing.Point(1033, 0);
            this.lblStart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(99, 23);
            this.lblStart.TabIndex = 7;
            this.lblStart.Text = "START";
            this.lblStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLastPit
            // 
            this.lblLastPit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastPit.Location = new System.Drawing.Point(926, 0);
            this.lblLastPit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastPit.Name = "lblLastPit";
            this.lblLastPit.Size = new System.Drawing.Size(99, 23);
            this.lblLastPit.TabIndex = 6;
            this.lblLastPit.Text = "LAST PIT";
            this.lblLastPit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLastLap
            // 
            this.lblLastLap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastLap.Location = new System.Drawing.Point(686, 0);
            this.lblLastLap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastLap.Name = "lblLastLap";
            this.lblLastLap.Size = new System.Drawing.Size(99, 23);
            this.lblLastLap.TabIndex = 8;
            this.lblLastLap.Text = "LAST LAP";
            this.lblLastLap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TSLeaderboardRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "TSLeaderboardRow";
            this.Size = new System.Drawing.Size(1136, 23);
            this.Load += new System.EventHandler(this.TSLeaderboardRow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picManufacturer)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label lblPosition;
        public System.Windows.Forms.Label lblCar;
        public System.Windows.Forms.PictureBox picManufacturer;
        public System.Windows.Forms.Label lblDriver;
        public System.Windows.Forms.Label lblBehind;
        public System.Windows.Forms.Label lblLastPit;
        public System.Windows.Forms.Label lblStart;
        public System.Windows.Forms.Label lblLastLap;
        public System.Windows.Forms.Label lblFastestLapTime;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

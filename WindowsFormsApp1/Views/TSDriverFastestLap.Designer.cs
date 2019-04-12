namespace rNascarTimingAndScoring.Views
{
    partial class TSDriverFastestLap
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
            this.lblFastestLapTime = new System.Windows.Forms.Label();
            this.lblFastestLapNumber = new System.Windows.Forms.Label();
            this.lblSpacer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblFastestLapTime
            // 
            this.lblFastestLapTime.BackColor = System.Drawing.Color.Transparent;
            this.lblFastestLapTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFastestLapTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFastestLapTime.ForeColor = System.Drawing.Color.SkyBlue;
            this.lblFastestLapTime.Location = new System.Drawing.Point(0, 0);
            this.lblFastestLapTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblFastestLapTime.Name = "lblFastestLapTime";
            this.lblFastestLapTime.Size = new System.Drawing.Size(57, 26);
            this.lblFastestLapTime.TabIndex = 0;
            this.lblFastestLapTime.Text = "00.00";
            this.lblFastestLapTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFastestLapNumber
            // 
            this.lblFastestLapNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblFastestLapNumber.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblFastestLapNumber.ForeColor = System.Drawing.Color.Black;
            this.lblFastestLapNumber.Location = new System.Drawing.Point(58, 0);
            this.lblFastestLapNumber.Margin = new System.Windows.Forms.Padding(0);
            this.lblFastestLapNumber.Name = "lblFastestLapNumber";
            this.lblFastestLapNumber.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblFastestLapNumber.Size = new System.Drawing.Size(31, 26);
            this.lblFastestLapNumber.TabIndex = 1;
            this.lblFastestLapNumber.Text = "000";
            this.lblFastestLapNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSpacer
            // 
            this.lblSpacer.BackColor = System.Drawing.Color.DarkBlue;
            this.lblSpacer.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSpacer.Location = new System.Drawing.Point(57, 0);
            this.lblSpacer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpacer.Name = "lblSpacer";
            this.lblSpacer.Size = new System.Drawing.Size(1, 26);
            this.lblSpacer.TabIndex = 2;
            this.lblSpacer.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // TSDriverFastestLap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblFastestLapTime);
            this.Controls.Add(this.lblSpacer);
            this.Controls.Add(this.lblFastestLapNumber);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TSDriverFastestLap";
            this.Size = new System.Drawing.Size(89, 26);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFastestLapTime;
        private System.Windows.Forms.Label lblFastestLapNumber;
        private System.Windows.Forms.Label lblSpacer;
    }
}

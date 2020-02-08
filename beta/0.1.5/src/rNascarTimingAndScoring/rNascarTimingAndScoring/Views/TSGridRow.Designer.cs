namespace rNascarTimingAndScoring.Views
{
    partial class TSGridRow
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
            this.lblDriver = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblCarNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPosition
            // 
            this.lblPosition.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblPosition.Location = new System.Drawing.Point(1, 1);
            this.lblPosition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(33, 25);
            this.lblPosition.TabIndex = 0;
            this.lblPosition.Text = "1.";
            this.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDriver
            // 
            this.lblDriver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDriver.Location = new System.Drawing.Point(66, 1);
            this.lblDriver.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDriver.Name = "lblDriver";
            this.lblDriver.Size = new System.Drawing.Size(230, 25);
            this.lblDriver.TabIndex = 1;
            this.lblDriver.Text = "Driver Name Here";
            this.lblDriver.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValue
            // 
            this.lblValue.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblValue.Location = new System.Drawing.Point(296, 1);
            this.lblValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(120, 25);
            this.lblValue.TabIndex = 2;
            this.lblValue.Text = "Value";
            this.lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCarNumber
            // 
            this.lblCarNumber.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCarNumber.Location = new System.Drawing.Point(34, 1);
            this.lblCarNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCarNumber.Name = "lblCarNumber";
            this.lblCarNumber.Size = new System.Drawing.Size(32, 25);
            this.lblCarNumber.TabIndex = 3;
            this.lblCarNumber.Text = "82";
            this.lblCarNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TSGridRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.Controls.Add(this.lblDriver);
            this.Controls.Add(this.lblCarNumber);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblPosition);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TSGridRow";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(417, 27);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblDriver;
        private System.Windows.Forms.Label lblCarNumber;
        public System.Windows.Forms.Label lblValue;
    }
}

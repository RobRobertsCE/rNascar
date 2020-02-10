namespace rNascarTimingAndScoring.Views
{
    partial class TSLapAveragesGrid
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
            this.SuspendLayout();
            // 
            // LeftTitle
            // 
            this.LeftTitle.BackColor = System.Drawing.Color.SteelBlue;
            this.LeftTitle.Size = new System.Drawing.Size(65, 18);
            this.LeftTitle.Text = "10 LAP AVERAGE";
            // 
            // RightTitle
            // 
            this.RightTitle.BackColor = System.Drawing.Color.SteelBlue;
            this.RightTitle.Location = new System.Drawing.Point(65, 0);
            this.RightTitle.Size = new System.Drawing.Size(250, 18);
            this.RightTitle.Text = "TIME  - SPEED";
            // 
            // TSLapAveragesGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "TSLapAveragesGrid";
            this.Size = new System.Drawing.Size(317, 341);
            this.ValueColumnWidth = 250;
            this.ResumeLayout(false);

        }

        #endregion
    }
}

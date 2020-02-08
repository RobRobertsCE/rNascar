namespace rNascarTimingAndScoring.Views
{
    partial class TSTrackState
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
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.picTrackState = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picTrackState)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            // 
            // picTrackState
            // 
            this.picTrackState.BackColor = System.Drawing.Color.Black;
            this.picTrackState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picTrackState.Image = global::rNascarTimingAndScoring.Properties.Resources.track_state_checkers;
            this.picTrackState.Location = new System.Drawing.Point(0, 0);
            this.picTrackState.Margin = new System.Windows.Forms.Padding(0);
            this.picTrackState.Name = "picTrackState";
            this.picTrackState.Size = new System.Drawing.Size(987, 162);
            this.picTrackState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTrackState.TabIndex = 1;
            this.picTrackState.TabStop = false;
            this.picTrackState.Paint += new System.Windows.Forms.PaintEventHandler(this.picTrackState_Paint);
            // 
            // TSTrackState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(20F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.picTrackState);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TSTrackState";
            this.Size = new System.Drawing.Size(987, 162);
            ((System.ComponentModel.ISupportInitialize)(this.picTrackState)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picTrackState;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

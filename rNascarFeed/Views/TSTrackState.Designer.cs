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
            this.picTrackState = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tsOutlinedLabel1 = new rNascarTimingAndScoring.Views.TSOutlinedLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picTrackState)).BeginInit();
            this.SuspendLayout();
            // 
            // picTrackState
            // 
            this.picTrackState.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.picTrackState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picTrackState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picTrackState.Location = new System.Drawing.Point(2, 2);
            this.picTrackState.Name = "picTrackState";
            this.picTrackState.Size = new System.Drawing.Size(292, 53);
            this.picTrackState.TabIndex = 1;
            this.picTrackState.TabStop = false;
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            // 
            // tsOutlinedLabel1
            // 
            this.tsOutlinedLabel1.BackColor = System.Drawing.Color.Transparent;
            this.tsOutlinedLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsOutlinedLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsOutlinedLabel1.ForeColor = System.Drawing.Color.White;
            this.tsOutlinedLabel1.Location = new System.Drawing.Point(2, 2);
            this.tsOutlinedLabel1.Name = "tsOutlinedLabel1";
            this.tsOutlinedLabel1.OutlineForeColor = System.Drawing.Color.Black;
            this.tsOutlinedLabel1.OutlineWidth = 2F;
            this.tsOutlinedLabel1.Size = new System.Drawing.Size(292, 53);
            this.tsOutlinedLabel1.TabIndex = 2;
            this.tsOutlinedLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TSTrackState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.tsOutlinedLabel1);
            this.Controls.Add(this.picTrackState);
            this.Name = "TSTrackState";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(296, 57);
            ((System.ComponentModel.ISupportInitialize)(this.picTrackState)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picTrackState;
        private System.Windows.Forms.ToolTip toolTip1;
        private TSOutlinedLabel tsOutlinedLabel1;
    }
}

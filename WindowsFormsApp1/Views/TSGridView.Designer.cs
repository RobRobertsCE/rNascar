namespace rNascarTimingAndScoring.Views
{
    partial class TSGridView
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
            this.LeftTitle = new System.Windows.Forms.Label();
            this.RightTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlGridRows = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LeftTitle
            // 
            this.LeftTitle.BackColor = System.Drawing.Color.Blue;
            this.LeftTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftTitle.ForeColor = System.Drawing.Color.White;
            this.LeftTitle.Location = new System.Drawing.Point(0, 0);
            this.LeftTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LeftTitle.Name = "LeftTitle";
            this.LeftTitle.Size = new System.Drawing.Size(320, 18);
            this.LeftTitle.TabIndex = 0;
            this.LeftTitle.Text = "LAP LEADERS";
            this.LeftTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RightTitle
            // 
            this.RightTitle.BackColor = System.Drawing.Color.Blue;
            this.RightTitle.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightTitle.ForeColor = System.Drawing.Color.White;
            this.RightTitle.Location = new System.Drawing.Point(320, 0);
            this.RightTitle.Margin = new System.Windows.Forms.Padding(1);
            this.RightTitle.Name = "RightTitle";
            this.RightTitle.Padding = new System.Windows.Forms.Padding(1);
            this.RightTitle.Size = new System.Drawing.Size(154, 18);
            this.RightTitle.TabIndex = 1;
            this.RightTitle.Text = "LAPS (#x)";
            this.RightTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LeftTitle);
            this.panel1.Controls.Add(this.RightTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(474, 18);
            this.panel1.TabIndex = 3;
            // 
            // pnlGridRows
            // 
            this.pnlGridRows.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnlGridRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridRows.Location = new System.Drawing.Point(1, 19);
            this.pnlGridRows.Margin = new System.Windows.Forms.Padding(1);
            this.pnlGridRows.Name = "pnlGridRows";
            this.pnlGridRows.Padding = new System.Windows.Forms.Padding(1);
            this.pnlGridRows.Size = new System.Drawing.Size(474, 200);
            this.pnlGridRows.TabIndex = 4;
            // 
            // TSGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.pnlGridRows);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "TSGridView";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(476, 220);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label LeftTitle;
        public System.Windows.Forms.Label RightTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlGridRows;
    }
}

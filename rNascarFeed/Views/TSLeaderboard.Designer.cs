namespace rNascarTimingAndScoring.Views
{
    partial class TSLeaderboard
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tsLeaderboardGrid0 = new rNascarTimingAndScoring.Views.TSLeaderboardGrid();
            this.tsLeaderboardGrid1 = new rNascarTimingAndScoring.Views.TSLeaderboardGrid();
            this.tsLeaderboardHeader1 = new rNascarTimingAndScoring.Views.TSLeaderboardHeader();
            this.tsLeaderboardHeader0 = new rNascarTimingAndScoring.Views.TSLeaderboardHeader();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tsLeaderboardGrid0, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tsLeaderboardGrid1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tsLeaderboardHeader1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tsLeaderboardHeader0, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(772, 235);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tsLeaderboardGrid0
            // 
            this.tsLeaderboardGrid0.BackColor = System.Drawing.Color.MidnightBlue;
            this.tsLeaderboardGrid0.Configuration = null;
            this.tsLeaderboardGrid0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsLeaderboardGrid0.Location = new System.Drawing.Point(3, 23);
            this.tsLeaderboardGrid0.Margin = new System.Windows.Forms.Padding(1);
            this.tsLeaderboardGrid0.MaxRowCount = 20;
            this.tsLeaderboardGrid0.Name = "tsLeaderboardGrid0";
            this.tsLeaderboardGrid0.Padding = new System.Windows.Forms.Padding(1);
            this.tsLeaderboardGrid0.Size = new System.Drawing.Size(382, 210);
            this.tsLeaderboardGrid0.TabIndex = 4;
            // 
            // tsLeaderboardGrid1
            // 
            this.tsLeaderboardGrid1.BackColor = System.Drawing.Color.MidnightBlue;
            this.tsLeaderboardGrid1.Configuration = null;
            this.tsLeaderboardGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsLeaderboardGrid1.Location = new System.Drawing.Point(387, 23);
            this.tsLeaderboardGrid1.Margin = new System.Windows.Forms.Padding(1);
            this.tsLeaderboardGrid1.MaxRowCount = 20;
            this.tsLeaderboardGrid1.Name = "tsLeaderboardGrid1";
            this.tsLeaderboardGrid1.Padding = new System.Windows.Forms.Padding(1);
            this.tsLeaderboardGrid1.Size = new System.Drawing.Size(382, 210);
            this.tsLeaderboardGrid1.TabIndex = 1;
            // 
            // tsLeaderboardHeader1
            // 
            this.tsLeaderboardHeader1.BackColor = System.Drawing.Color.White;
            this.tsLeaderboardHeader1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsLeaderboardHeader1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsLeaderboardHeader1.Location = new System.Drawing.Point(3, 3);
            this.tsLeaderboardHeader1.Margin = new System.Windows.Forms.Padding(1);
            this.tsLeaderboardHeader1.Name = "tsLeaderboardHeader1";
            this.tsLeaderboardHeader1.Padding = new System.Windows.Forms.Padding(1);
            this.tsLeaderboardHeader1.Size = new System.Drawing.Size(382, 18);
            this.tsLeaderboardHeader1.TabIndex = 2;
            // 
            // tsLeaderboardHeader0
            // 
            this.tsLeaderboardHeader0.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsLeaderboardHeader0.BackColor = System.Drawing.Color.White;
            this.tsLeaderboardHeader0.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsLeaderboardHeader0.Location = new System.Drawing.Point(387, 3);
            this.tsLeaderboardHeader0.Margin = new System.Windows.Forms.Padding(1);
            this.tsLeaderboardHeader0.Name = "tsLeaderboardHeader0";
            this.tsLeaderboardHeader0.Padding = new System.Windows.Forms.Padding(1);
            this.tsLeaderboardHeader0.Size = new System.Drawing.Size(382, 18);
            this.tsLeaderboardHeader0.TabIndex = 3;
            // 
            // TSLeaderboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TSLeaderboard";
            this.Size = new System.Drawing.Size(772, 235);
            this.Load += new System.EventHandler(this.TSLeaderboard_Load);
            this.BackColorChanged += new System.EventHandler(this.TSLeaderboard_BackColorChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private TSLeaderboardGrid tsLeaderboardGrid1;
        private TSLeaderboardHeader tsLeaderboardHeader1;
        private TSLeaderboardGrid tsLeaderboardGrid0;
        private TSLeaderboardHeader tsLeaderboardHeader0;
    }
}

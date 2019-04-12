namespace rNascarTimingAndScoring
{
    partial class TSMainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pollFeedTimer = new System.Windows.Forms.Timer(this.components);
            this.ctxMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.autoRefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.getFeedDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pollFeedTimer
            // 
            this.pollFeedTimer.Interval = 5000;
            // 
            // ctxMain
            // 
            this.ctxMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoRefreshToolStripMenuItem,
            this.eventToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.getFeedDataToolStripMenuItem});
            this.ctxMain.Name = "ctxMain";
            this.ctxMain.Size = new System.Drawing.Size(148, 98);
            // 
            // autoRefreshToolStripMenuItem
            // 
            this.autoRefreshToolStripMenuItem.CheckOnClick = true;
            this.autoRefreshToolStripMenuItem.Name = "autoRefreshToolStripMenuItem";
            this.autoRefreshToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.autoRefreshToolStripMenuItem.Text = "Auto-Refresh";
            this.autoRefreshToolStripMenuItem.Click += new System.EventHandler(this.autoRefreshToolStripMenuItem_Click);
            // 
            // eventToolStripMenuItem
            // 
            this.eventToolStripMenuItem.Name = "eventToolStripMenuItem";
            this.eventToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.eventToolStripMenuItem.Text = "Event";
            this.eventToolStripMenuItem.Click += new System.EventHandler(this.eventToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // getFeedDataToolStripMenuItem
            // 
            this.getFeedDataToolStripMenuItem.Name = "getFeedDataToolStripMenuItem";
            this.getFeedDataToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.getFeedDataToolStripMenuItem.Text = "Get Feed Data";
            this.getFeedDataToolStripMenuItem.Click += new System.EventHandler(this.getFeedDataToolStripMenuItem_Click);
            // 
            // TSMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ContextMenuStrip = this.ctxMain;
            this.Name = "TSMainForm";
            this.Text = "TSMainForm";
            this.Load += new System.EventHandler(this.TSMainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TSMainForm_KeyDown);
            this.ctxMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer pollFeedTimer;
        private System.Windows.Forms.ContextMenuStrip ctxMain;
        private System.Windows.Forms.ToolStripMenuItem autoRefreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem getFeedDataToolStripMenuItem;
    }
}
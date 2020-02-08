namespace rNascarTS
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.logFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userSettingsFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.resetViewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.themeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDesignerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel0 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTrackName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblEvent = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSession = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTrackState = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnFeedReader = new System.Windows.Forms.ToolStripButton();
            this.btnUnsubscribe = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.GridTable = new System.Windows.Forms.TableLayoutPanel();
            this.ctxGridTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gridSizeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dragTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.MainStatusStrip.SuspendLayout();
            this.MainToolStrip.SuspendLayout();
            this.ctxGridTable.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1038, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Enabled = false;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarToolStripMenuItem,
            this.toolBarToolStripMenuItem,
            this.toolStripMenuItem2,
            this.logFileToolStripMenuItem,
            this.userSettingsFileToolStripMenuItem,
            this.toolStripMenuItem1,
            this.resetViewsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // statusBarToolStripMenuItem
            // 
            this.statusBarToolStripMenuItem.Checked = true;
            this.statusBarToolStripMenuItem.CheckOnClick = true;
            this.statusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.statusBarToolStripMenuItem.Name = "statusBarToolStripMenuItem";
            this.statusBarToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.statusBarToolStripMenuItem.Text = "&Status Bar";
            this.statusBarToolStripMenuItem.CheckedChanged += new System.EventHandler(this.statusBarToolStripMenuItem_CheckedChanged);
            // 
            // toolBarToolStripMenuItem
            // 
            this.toolBarToolStripMenuItem.Checked = true;
            this.toolBarToolStripMenuItem.CheckOnClick = true;
            this.toolBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolBarToolStripMenuItem.Name = "toolBarToolStripMenuItem";
            this.toolBarToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.toolBarToolStripMenuItem.Text = "&Tool Bar";
            this.toolBarToolStripMenuItem.CheckedChanged += new System.EventHandler(this.toolBarToolStripMenuItem_CheckedChanged);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(160, 6);
            // 
            // logFileToolStripMenuItem
            // 
            this.logFileToolStripMenuItem.Name = "logFileToolStripMenuItem";
            this.logFileToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.logFileToolStripMenuItem.Text = "&Log File";
            this.logFileToolStripMenuItem.Click += new System.EventHandler(this.logFileToolStripMenuItem_Click);
            // 
            // userSettingsFileToolStripMenuItem
            // 
            this.userSettingsFileToolStripMenuItem.Name = "userSettingsFileToolStripMenuItem";
            this.userSettingsFileToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.userSettingsFileToolStripMenuItem.Text = "&User Settings File";
            this.userSettingsFileToolStripMenuItem.Click += new System.EventHandler(this.userSettingsFileToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 6);
            // 
            // resetViewsToolStripMenuItem
            // 
            this.resetViewsToolStripMenuItem.Name = "resetViewsToolStripMenuItem";
            this.resetViewsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.resetViewsToolStripMenuItem.Text = "&Reset Views";
            this.resetViewsToolStripMenuItem.Click += new System.EventHandler(this.resetViewsToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridSizeToolStripMenuItem,
            this.toolStripMenuItem4,
            this.themeToolStripMenuItem,
            this.viewDesignerToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // gridSizeToolStripMenuItem
            // 
            this.gridSizeToolStripMenuItem.Name = "gridSizeToolStripMenuItem";
            this.gridSizeToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.gridSizeToolStripMenuItem.Text = "&Grid Size";
            this.gridSizeToolStripMenuItem.Click += new System.EventHandler(this.gridSizeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(157, 6);
            // 
            // themeToolStripMenuItem
            // 
            this.themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            this.themeToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.themeToolStripMenuItem.Text = "&Theme Designer";
            this.themeToolStripMenuItem.Click += new System.EventHandler(this.themeToolStripMenuItem_Click);
            // 
            // viewDesignerToolStripMenuItem
            // 
            this.viewDesignerToolStripMenuItem.Name = "viewDesignerToolStripMenuItem";
            this.viewDesignerToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.viewDesignerToolStripMenuItem.Text = "&View Designer";
            this.viewDesignerToolStripMenuItem.Click += new System.EventHandler(this.viewDesignerToolStripMenuItem_Click);
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel0,
            this.lblTrackName,
            this.toolStripStatusLabel3,
            this.lblEvent,
            this.toolStripStatusLabel1,
            this.lblSession,
            this.toolStripStatusLabel2,
            this.lblTrackState});
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 522);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(1038, 24);
            this.MainStatusStrip.TabIndex = 1;
            this.MainStatusStrip.Text = "statusStrip1";
            this.MainStatusStrip.VisibleChanged += new System.EventHandler(this.MainStatusStrip_VisibleChanged);
            // 
            // toolStripStatusLabel0
            // 
            this.toolStripStatusLabel0.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel0.Name = "toolStripStatusLabel0";
            this.toolStripStatusLabel0.Size = new System.Drawing.Size(42, 19);
            this.toolStripStatusLabel0.Text = "Track:";
            // 
            // lblTrackName
            // 
            this.lblTrackName.AutoSize = false;
            this.lblTrackName.AutoToolTip = true;
            this.lblTrackName.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblTrackName.Name = "lblTrackName";
            this.lblTrackName.Size = new System.Drawing.Size(200, 19);
            this.lblTrackName.Text = "-none-";
            this.lblTrackName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(39, 19);
            this.toolStripStatusLabel3.Text = "Event:";
            // 
            // lblEvent
            // 
            this.lblEvent.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(426, 19);
            this.lblEvent.Spring = true;
            this.lblEvent.Text = "-none-";
            this.lblEvent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(49, 19);
            this.toolStripStatusLabel1.Text = "Session:";
            // 
            // lblSession
            // 
            this.lblSession.AutoSize = false;
            this.lblSession.AutoToolTip = true;
            this.lblSession.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblSession.Name = "lblSession";
            this.lblSession.Size = new System.Drawing.Size(100, 19);
            this.lblSession.Text = "-none-";
            this.lblSession.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(67, 19);
            this.toolStripStatusLabel2.Text = "Track State:";
            // 
            // lblTrackState
            // 
            this.lblTrackState.AutoSize = false;
            this.lblTrackState.AutoToolTip = true;
            this.lblTrackState.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblTrackState.Name = "lblTrackState";
            this.lblTrackState.Size = new System.Drawing.Size(100, 19);
            this.lblTrackState.Text = "-none-";
            this.lblTrackState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainToolStrip
            // 
            this.MainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFeedReader,
            this.btnUnsubscribe,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton1});
            this.MainToolStrip.Location = new System.Drawing.Point(0, 24);
            this.MainToolStrip.Name = "MainToolStrip";
            this.MainToolStrip.Size = new System.Drawing.Size(1038, 25);
            this.MainToolStrip.TabIndex = 2;
            this.MainToolStrip.Text = "toolStrip1";
            this.MainToolStrip.VisibleChanged += new System.EventHandler(this.MainToolStrip_VisibleChanged);
            // 
            // btnFeedReader
            // 
            this.btnFeedReader.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFeedReader.Image = ((System.Drawing.Image)(resources.GetObject("btnFeedReader.Image")));
            this.btnFeedReader.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFeedReader.Name = "btnFeedReader";
            this.btnFeedReader.Size = new System.Drawing.Size(75, 22);
            this.btnFeedReader.Text = "Feed Reader";
            this.btnFeedReader.Click += new System.EventHandler(this.btnFeedReader_Click);
            // 
            // btnUnsubscribe
            // 
            this.btnUnsubscribe.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUnsubscribe.Image = ((System.Drawing.Image)(resources.GetObject("btnUnsubscribe.Image")));
            this.btnUnsubscribe.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnsubscribe.Name = "btnUnsubscribe";
            this.btnUnsubscribe.Size = new System.Drawing.Size(76, 22);
            this.btnUnsubscribe.Text = "Unsubscribe";
            this.btnUnsubscribe.Click += new System.EventHandler(this.btnUnsubscribe_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(149, 22);
            this.toolStripButton4.Text = "DataSourceList to Console";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(143, 22);
            this.toolStripButton5.Text = "Load Sample Model Data";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // GridTable
            // 
            this.GridTable.AllowDrop = true;
            this.GridTable.AutoSize = true;
            this.GridTable.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.GridTable.ColumnCount = 4;
            this.GridTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.GridTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.GridTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.GridTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.GridTable.ContextMenuStrip = this.ctxGridTable;
            this.GridTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridTable.Location = new System.Drawing.Point(0, 0);
            this.GridTable.Name = "GridTable";
            this.GridTable.RowCount = 5;
            this.GridTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.GridTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.GridTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.GridTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.GridTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GridTable.Size = new System.Drawing.Size(1038, 473);
            this.GridTable.TabIndex = 3;
            this.GridTable.DragDrop += new System.Windows.Forms.DragEventHandler(this.GridTable_DragDrop);
            this.GridTable.DragOver += new System.Windows.Forms.DragEventHandler(this.GridTable_DragOver);
            this.GridTable.Resize += new System.EventHandler(this.GridTable_Resize);
            // 
            // ctxGridTable
            // 
            this.ctxGridTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridSizeToolStripMenuItem1});
            this.ctxGridTable.Name = "ctxGridTable";
            this.ctxGridTable.Size = new System.Drawing.Size(120, 26);
            // 
            // gridSizeToolStripMenuItem1
            // 
            this.gridSizeToolStripMenuItem1.Name = "gridSizeToolStripMenuItem1";
            this.gridSizeToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.gridSizeToolStripMenuItem1.Text = "Grid Size";
            this.gridSizeToolStripMenuItem1.Click += new System.EventHandler(this.gridSizeToolStripMenuItem1_Click);
            // 
            // dragTimer
            // 
            this.dragTimer.Interval = 20;
            // 
            // pnlGrid
            // 
            this.pnlGrid.AutoScroll = true;
            this.pnlGrid.Controls.Add(this.GridTable);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 49);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1038, 473);
            this.pnlGrid.TabIndex = 4;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 546);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.MainToolStrip);
            this.Controls.Add(this.MainStatusStrip);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "r/Nascar Timing & Scoring";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            this.MainToolStrip.ResumeLayout(false);
            this.MainToolStrip.PerformLayout();
            this.ctxGridTable.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.ToolStrip MainToolStrip;
        internal System.Windows.Forms.TableLayoutPanel GridTable;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel0;
        private System.Windows.Forms.ToolStripStatusLabel lblTrackName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblSession;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblTrackState;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblEvent;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem logFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userSettingsFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themeToolStripMenuItem;
        private System.Windows.Forms.Timer dragTimer;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.ToolStripMenuItem gridSizeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctxGridTable;
        private System.Windows.Forms.ToolStripMenuItem gridSizeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewDesignerToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnFeedReader;
        private System.Windows.Forms.ToolStripButton btnUnsubscribe;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem resetViewsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}


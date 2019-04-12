namespace rNascarTimingAndScoring
{
    partial class TimingAndScoring
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimingAndScoring));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pollFeedTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLeaderboard = new System.Windows.Forms.Panel();
            this.pnlRaceInfo = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.lblSession = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.lblBattleGap = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.lblPitWindowTitle = new System.Windows.Forms.Label();
            this.lblPitWindow = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.lblGreenLaps = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.lblYellowLaps = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lblOnLeadLap = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.pnlFastLapsAndPoints = new System.Windows.Forms.Panel();
            this.ctxMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.autoRefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.getFeedDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.getLiveEventSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsLeaderboard1 = new rNascarTimingAndScoring.Views.TSLeaderboard();
            this.tsBiggestMoversGrid1 = new rNascarTimingAndScoring.Views.TSBiggestMoversGrid();
            this.tsLapLeaderGrid1 = new rNascarTimingAndScoring.Views.TSLapLeaderGrid();
            this.tsOffThePaceGrid1 = new rNascarTimingAndScoring.Views.TSOffThePaceGrid();
            this.tsPitPenaltiesGrid1 = new rNascarTimingAndScoring.Views.TSPitPenaltiesGrid();
            this.tsPoints1 = new rNascarTimingAndScoring.Views.TSPoints();
            this.tsFastestLaps1 = new rNascarTimingAndScoring.Views.TSFastestLaps();
            this.tsLeaders1 = new rNascarTimingAndScoring.Views.TSSingleFieldDisplay();
            this.tsCautions1 = new rNascarTimingAndScoring.Views.TSSingleFieldDisplay();
            this.tsTrackState = new rNascarTimingAndScoring.Views.TSTrackState();
            this.tsLeaderboardGrid1 = new rNascarTimingAndScoring.Views.TSLeaderboardGrid();
            this.tsLeaderboardGrid2 = new rNascarTimingAndScoring.Views.TSLeaderboardGrid();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlLeaderboard.SuspendLayout();
            this.pnlRaceInfo.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.pnlFastLapsAndPoints.SuspendLayout();
            this.ctxMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Black;
            this.pnlTop.Controls.Add(this.picLogo);
            this.pnlTop.Controls.Add(this.tsLeaders1);
            this.pnlTop.Controls.Add(this.tsCautions1);
            this.pnlTop.Controls.Add(this.tsTrackState);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1524, 79);
            this.pnlTop.TabIndex = 1;
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(3, 8);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(494, 67);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 8;
            this.picLogo.TabStop = false;
            // 
            // pollFeedTimer
            // 
            this.pollFeedTimer.Interval = 5000;
            this.pollFeedTimer.Tick += new System.EventHandler(this.pollFeed_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.tsBiggestMoversGrid1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tsLapLeaderGrid1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tsOffThePaceGrid1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tsPitPenaltiesGrid1, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 334);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1197, 241);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // pnlLeaderboard
            // 
            this.pnlLeaderboard.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnlLeaderboard.Controls.Add(this.tsLeaderboard1);
            this.pnlLeaderboard.Controls.Add(this.pnlRaceInfo);
            this.pnlLeaderboard.Controls.Add(this.tableLayoutPanel1);
            this.pnlLeaderboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeaderboard.Location = new System.Drawing.Point(0, 79);
            this.pnlLeaderboard.Name = "pnlLeaderboard";
            this.pnlLeaderboard.Size = new System.Drawing.Size(1197, 575);
            this.pnlLeaderboard.TabIndex = 7;
            // 
            // pnlRaceInfo
            // 
            this.pnlRaceInfo.BackColor = System.Drawing.Color.Black;
            this.pnlRaceInfo.Controls.Add(this.panel12);
            this.pnlRaceInfo.Controls.Add(this.panel14);
            this.pnlRaceInfo.Controls.Add(this.panel13);
            this.pnlRaceInfo.Controls.Add(this.panel11);
            this.pnlRaceInfo.Controls.Add(this.panel10);
            this.pnlRaceInfo.Controls.Add(this.panel9);
            this.pnlRaceInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlRaceInfo.Location = new System.Drawing.Point(0, 302);
            this.pnlRaceInfo.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRaceInfo.Name = "pnlRaceInfo";
            this.pnlRaceInfo.Padding = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.pnlRaceInfo.Size = new System.Drawing.Size(1197, 32);
            this.pnlRaceInfo.TabIndex = 0;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel12.Controls.Add(this.label23);
            this.panel12.Controls.Add(this.lblSession);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(508, 1);
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(1);
            this.panel12.Size = new System.Drawing.Size(288, 29);
            this.panel12.TabIndex = 4;
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.MidnightBlue;
            this.label23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(1, 1);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(149, 27);
            this.label23.TabIndex = 0;
            this.label23.Text = "SESSION";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSession
            // 
            this.lblSession.BackColor = System.Drawing.Color.Black;
            this.lblSession.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSession.ForeColor = System.Drawing.Color.White;
            this.lblSession.Location = new System.Drawing.Point(150, 1);
            this.lblSession.Name = "lblSession";
            this.lblSession.Size = new System.Drawing.Size(137, 27);
            this.lblSession.TabIndex = 1;
            this.lblSession.Text = "--:--:--";
            this.lblSession.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.label26);
            this.panel14.Controls.Add(this.lblBattleGap);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel14.Location = new System.Drawing.Point(796, 1);
            this.panel14.Name = "panel14";
            this.panel14.Padding = new System.Windows.Forms.Padding(1);
            this.panel14.Size = new System.Drawing.Size(200, 29);
            this.panel14.TabIndex = 6;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.MidnightBlue;
            this.label26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(1, 1);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(147, 27);
            this.label26.TabIndex = 0;
            this.label26.Text = "BATTLE GAP";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBattleGap
            // 
            this.lblBattleGap.BackColor = System.Drawing.Color.Black;
            this.lblBattleGap.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblBattleGap.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBattleGap.ForeColor = System.Drawing.Color.White;
            this.lblBattleGap.Location = new System.Drawing.Point(148, 1);
            this.lblBattleGap.Name = "lblBattleGap";
            this.lblBattleGap.Size = new System.Drawing.Size(51, 27);
            this.lblBattleGap.TabIndex = 1;
            this.lblBattleGap.Text = "-.-";
            this.lblBattleGap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.lblPitWindowTitle);
            this.panel13.Controls.Add(this.lblPitWindow);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel13.Location = new System.Drawing.Point(996, 1);
            this.panel13.Name = "panel13";
            this.panel13.Padding = new System.Windows.Forms.Padding(1);
            this.panel13.Size = new System.Drawing.Size(200, 29);
            this.panel13.TabIndex = 5;
            // 
            // lblPitWindowTitle
            // 
            this.lblPitWindowTitle.BackColor = System.Drawing.Color.MidnightBlue;
            this.lblPitWindowTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPitWindowTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPitWindowTitle.ForeColor = System.Drawing.Color.White;
            this.lblPitWindowTitle.Location = new System.Drawing.Point(1, 1);
            this.lblPitWindowTitle.Name = "lblPitWindowTitle";
            this.lblPitWindowTitle.Size = new System.Drawing.Size(147, 27);
            this.lblPitWindowTitle.TabIndex = 0;
            this.lblPitWindowTitle.Text = "PIT WINDOW";
            this.lblPitWindowTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPitWindow
            // 
            this.lblPitWindow.BackColor = System.Drawing.Color.Black;
            this.lblPitWindow.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPitWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPitWindow.ForeColor = System.Drawing.Color.White;
            this.lblPitWindow.Location = new System.Drawing.Point(148, 1);
            this.lblPitWindow.Name = "lblPitWindow";
            this.lblPitWindow.Size = new System.Drawing.Size(51, 27);
            this.lblPitWindow.TabIndex = 1;
            this.lblPitWindow.Text = "--";
            this.lblPitWindow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.lblGreenLaps);
            this.panel11.Controls.Add(this.label25);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(335, 1);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(1);
            this.panel11.Size = new System.Drawing.Size(173, 29);
            this.panel11.TabIndex = 3;
            // 
            // lblGreenLaps
            // 
            this.lblGreenLaps.BackColor = System.Drawing.Color.Black;
            this.lblGreenLaps.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblGreenLaps.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGreenLaps.ForeColor = System.Drawing.Color.White;
            this.lblGreenLaps.Location = new System.Drawing.Point(121, 1);
            this.lblGreenLaps.Name = "lblGreenLaps";
            this.lblGreenLaps.Size = new System.Drawing.Size(51, 27);
            this.lblGreenLaps.TabIndex = 1;
            this.lblGreenLaps.Text = "-";
            this.lblGreenLaps.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.LimeGreen;
            this.label25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(1, 1);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(171, 27);
            this.label25.TabIndex = 0;
            this.label25.Text = "GREEN LAPS";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.lblYellowLaps);
            this.panel10.Controls.Add(this.label24);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(162, 1);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(1);
            this.panel10.Size = new System.Drawing.Size(173, 29);
            this.panel10.TabIndex = 2;
            // 
            // lblYellowLaps
            // 
            this.lblYellowLaps.BackColor = System.Drawing.Color.Black;
            this.lblYellowLaps.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblYellowLaps.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYellowLaps.ForeColor = System.Drawing.Color.White;
            this.lblYellowLaps.Location = new System.Drawing.Point(121, 1);
            this.lblYellowLaps.Name = "lblYellowLaps";
            this.lblYellowLaps.Size = new System.Drawing.Size(51, 27);
            this.lblYellowLaps.TabIndex = 1;
            this.lblYellowLaps.Text = "-";
            this.lblYellowLaps.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.Gold;
            this.label24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(1, 1);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(171, 27);
            this.label24.TabIndex = 0;
            this.label24.Text = "YELLOW LAPS";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.lblOnLeadLap);
            this.panel9.Controls.Add(this.label18);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(1, 1);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(1);
            this.panel9.Size = new System.Drawing.Size(161, 29);
            this.panel9.TabIndex = 1;
            // 
            // lblOnLeadLap
            // 
            this.lblOnLeadLap.BackColor = System.Drawing.Color.Black;
            this.lblOnLeadLap.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblOnLeadLap.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOnLeadLap.ForeColor = System.Drawing.Color.White;
            this.lblOnLeadLap.Location = new System.Drawing.Point(127, 1);
            this.lblOnLeadLap.Name = "lblOnLeadLap";
            this.lblOnLeadLap.Size = new System.Drawing.Size(33, 27);
            this.lblOnLeadLap.TabIndex = 1;
            this.lblOnLeadLap.Text = "-";
            this.lblOnLeadLap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.MidnightBlue;
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(1, 1);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(159, 27);
            this.label18.TabIndex = 0;
            this.label18.Text = "ON LEAD LAP";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlFastLapsAndPoints
            // 
            this.pnlFastLapsAndPoints.BackColor = System.Drawing.Color.Black;
            this.pnlFastLapsAndPoints.Controls.Add(this.tsPoints1);
            this.pnlFastLapsAndPoints.Controls.Add(this.tsFastestLaps1);
            this.pnlFastLapsAndPoints.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFastLapsAndPoints.Location = new System.Drawing.Point(1197, 79);
            this.pnlFastLapsAndPoints.Margin = new System.Windows.Forms.Padding(1);
            this.pnlFastLapsAndPoints.Name = "pnlFastLapsAndPoints";
            this.pnlFastLapsAndPoints.Padding = new System.Windows.Forms.Padding(1);
            this.pnlFastLapsAndPoints.Size = new System.Drawing.Size(327, 575);
            this.pnlFastLapsAndPoints.TabIndex = 8;
            // 
            // ctxMain
            // 
            this.ctxMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoRefreshToolStripMenuItem,
            this.eventToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.getFeedDataToolStripMenuItem,
            this.toolStripMenuItem2,
            this.getLiveEventSettingsToolStripMenuItem});
            this.ctxMain.Name = "ctxMain";
            this.ctxMain.Size = new System.Drawing.Size(194, 148);
            // 
            // autoRefreshToolStripMenuItem
            // 
            this.autoRefreshToolStripMenuItem.Checked = true;
            this.autoRefreshToolStripMenuItem.CheckOnClick = true;
            this.autoRefreshToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoRefreshToolStripMenuItem.Name = "autoRefreshToolStripMenuItem";
            this.autoRefreshToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.autoRefreshToolStripMenuItem.Text = "Auto-Refresh";
            this.autoRefreshToolStripMenuItem.Click += new System.EventHandler(this.autoRefreshToolStripMenuItem_Click);
            // 
            // eventToolStripMenuItem
            // 
            this.eventToolStripMenuItem.Name = "eventToolStripMenuItem";
            this.eventToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.eventToolStripMenuItem.Text = "Event";
            this.eventToolStripMenuItem.Click += new System.EventHandler(this.eventToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(190, 6);
            // 
            // getFeedDataToolStripMenuItem
            // 
            this.getFeedDataToolStripMenuItem.Name = "getFeedDataToolStripMenuItem";
            this.getFeedDataToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.getFeedDataToolStripMenuItem.Text = "Get Feed Data";
            this.getFeedDataToolStripMenuItem.Click += new System.EventHandler(this.getFeedDataToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(190, 6);
            // 
            // getLiveEventSettingsToolStripMenuItem
            // 
            this.getLiveEventSettingsToolStripMenuItem.Name = "getLiveEventSettingsToolStripMenuItem";
            this.getLiveEventSettingsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.getLiveEventSettingsToolStripMenuItem.Text = "Get Live Event Settings";
            this.getLiveEventSettingsToolStripMenuItem.Click += new System.EventHandler(this.getLiveEventSettingsToolStripMenuItem_Click);
            // 
            // tsLeaderboard1
            // 
            this.tsLeaderboard1.BackColor = System.Drawing.Color.Black;
            this.tsLeaderboard1.Configuration = null;
            this.tsLeaderboard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsLeaderboard1.Location = new System.Drawing.Point(0, 0);
            this.tsLeaderboard1.MaxRowCount = 20;
            this.tsLeaderboard1.Name = "tsLeaderboard1";
            this.tsLeaderboard1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.tsLeaderboard1.Size = new System.Drawing.Size(1197, 302);
            this.tsLeaderboard1.TabIndex = 7;
            // 
            // tsBiggestMoversGrid1
            // 
            this.tsBiggestMoversGrid1.BackColor = System.Drawing.Color.Black;
            this.tsBiggestMoversGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsBiggestMoversGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsBiggestMoversGrid1.Location = new System.Drawing.Point(1, 1);
            this.tsBiggestMoversGrid1.Margin = new System.Windows.Forms.Padding(1);
            this.tsBiggestMoversGrid1.MaxRows = 8;
            this.tsBiggestMoversGrid1.Name = "tsBiggestMoversGrid1";
            this.tsBiggestMoversGrid1.Padding = new System.Windows.Forms.Padding(1);
            this.tsBiggestMoversGrid1.Size = new System.Drawing.Size(297, 239);
            this.tsBiggestMoversGrid1.TabIndex = 3;
            this.tsBiggestMoversGrid1.ValueColumnWidth = 50;
            // 
            // tsLapLeaderGrid1
            // 
            this.tsLapLeaderGrid1.BackColor = System.Drawing.Color.Black;
            this.tsLapLeaderGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsLapLeaderGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsLapLeaderGrid1.Location = new System.Drawing.Point(599, 1);
            this.tsLapLeaderGrid1.Margin = new System.Windows.Forms.Padding(1);
            this.tsLapLeaderGrid1.MaxRows = 8;
            this.tsLapLeaderGrid1.Name = "tsLapLeaderGrid1";
            this.tsLapLeaderGrid1.Padding = new System.Windows.Forms.Padding(1);
            this.tsLapLeaderGrid1.Size = new System.Drawing.Size(297, 239);
            this.tsLapLeaderGrid1.TabIndex = 4;
            this.tsLapLeaderGrid1.ValueColumnWidth = 120;
            // 
            // tsOffThePaceGrid1
            // 
            this.tsOffThePaceGrid1.BackColor = System.Drawing.Color.Black;
            this.tsOffThePaceGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsOffThePaceGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsOffThePaceGrid1.Location = new System.Drawing.Point(300, 1);
            this.tsOffThePaceGrid1.Margin = new System.Windows.Forms.Padding(1);
            this.tsOffThePaceGrid1.MaxRows = 8;
            this.tsOffThePaceGrid1.Name = "tsOffThePaceGrid1";
            this.tsOffThePaceGrid1.Padding = new System.Windows.Forms.Padding(1);
            this.tsOffThePaceGrid1.Size = new System.Drawing.Size(297, 239);
            this.tsOffThePaceGrid1.TabIndex = 5;
            this.tsOffThePaceGrid1.ValueColumnWidth = 50;
            // 
            // tsPitPenaltiesGrid1
            // 
            this.tsPitPenaltiesGrid1.BackColor = System.Drawing.Color.Black;
            this.tsPitPenaltiesGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsPitPenaltiesGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsPitPenaltiesGrid1.Location = new System.Drawing.Point(898, 1);
            this.tsPitPenaltiesGrid1.Margin = new System.Windows.Forms.Padding(1);
            this.tsPitPenaltiesGrid1.MaxRows = 8;
            this.tsPitPenaltiesGrid1.Name = "tsPitPenaltiesGrid1";
            this.tsPitPenaltiesGrid1.Padding = new System.Windows.Forms.Padding(1);
            this.tsPitPenaltiesGrid1.Size = new System.Drawing.Size(298, 239);
            this.tsPitPenaltiesGrid1.TabIndex = 6;
            this.tsPitPenaltiesGrid1.ValueColumnWidth = 120;
            // 
            // tsPoints1
            // 
            this.tsPoints1.BackColor = System.Drawing.Color.Navy;
            this.tsPoints1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsPoints1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsPoints1.Location = new System.Drawing.Point(1, 428);
            this.tsPoints1.Margin = new System.Windows.Forms.Padding(4);
            this.tsPoints1.MaxRows = 18;
            this.tsPoints1.Name = "tsPoints1";
            this.tsPoints1.Padding = new System.Windows.Forms.Padding(1, 2, 1, 1);
            this.tsPoints1.Size = new System.Drawing.Size(325, 146);
            this.tsPoints1.TabIndex = 0;
            this.tsPoints1.ValueColumnWidth = 80;
            // 
            // tsFastestLaps1
            // 
            this.tsFastestLaps1.BackColor = System.Drawing.Color.Navy;
            this.tsFastestLaps1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tsFastestLaps1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsFastestLaps1.Location = new System.Drawing.Point(1, 1);
            this.tsFastestLaps1.Margin = new System.Windows.Forms.Padding(4);
            this.tsFastestLaps1.MaxRows = 15;
            this.tsFastestLaps1.Name = "tsFastestLaps1";
            this.tsFastestLaps1.Padding = new System.Windows.Forms.Padding(1);
            this.tsFastestLaps1.Size = new System.Drawing.Size(325, 427);
            this.tsFastestLaps1.TabIndex = 1;
            this.tsFastestLaps1.ValueColumnWidth = 80;
            // 
            // tsLeaders1
            // 
            this.tsLeaders1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tsLeaders1.BackColor = System.Drawing.Color.Black;
            this.tsLeaders1.DetailBackColor = System.Drawing.Color.MediumBlue;
            this.tsLeaders1.DetailCaption = "CHANGES";
            this.tsLeaders1.DetailForeColor = System.Drawing.Color.White;
            this.tsLeaders1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsLeaders1.Header = "LEADERS";
            this.tsLeaders1.Location = new System.Drawing.Point(1070, 8);
            this.tsLeaders1.Margin = new System.Windows.Forms.Padding(4);
            this.tsLeaders1.Name = "tsLeaders1";
            this.tsLeaders1.Size = new System.Drawing.Size(233, 67);
            this.tsLeaders1.TabIndex = 7;
            // 
            // tsCautions1
            // 
            this.tsCautions1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tsCautions1.BackColor = System.Drawing.Color.Black;
            this.tsCautions1.DetailBackColor = System.Drawing.Color.Yellow;
            this.tsCautions1.DetailCaption = "LAPS";
            this.tsCautions1.DetailForeColor = System.Drawing.Color.Black;
            this.tsCautions1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsCautions1.Header = "CAUTIONS";
            this.tsCautions1.Location = new System.Drawing.Point(1311, 8);
            this.tsCautions1.Margin = new System.Windows.Forms.Padding(4);
            this.tsCautions1.Name = "tsCautions1";
            this.tsCautions1.Size = new System.Drawing.Size(200, 67);
            this.tsCautions1.TabIndex = 6;
            // 
            // tsTrackState
            // 
            this.tsTrackState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsTrackState.BackColor = System.Drawing.Color.SteelBlue;
            this.tsTrackState.LapInfo = "";
            this.tsTrackState.Location = new System.Drawing.Point(508, 8);
            this.tsTrackState.Name = "tsTrackState";
            this.tsTrackState.Padding = new System.Windows.Forms.Padding(1);
            this.tsTrackState.Size = new System.Drawing.Size(554, 67);
            this.tsTrackState.TabIndex = 3;
            this.tsTrackState.TrackState = rNascarTimingAndScoring.Models.TrackStates.NotActive;
            // 
            // tsLeaderboardGrid1
            // 
            this.tsLeaderboardGrid1.BackColor = System.Drawing.Color.DarkBlue;
            this.tsLeaderboardGrid1.Configuration = null;
            this.tsLeaderboardGrid1.Location = new System.Drawing.Point(0, 0);
            this.tsLeaderboardGrid1.MaxRowCount = 20;
            this.tsLeaderboardGrid1.Name = "tsLeaderboardGrid1";
            this.tsLeaderboardGrid1.Size = new System.Drawing.Size(795, 399);
            this.tsLeaderboardGrid1.TabIndex = 0;
            // 
            // tsLeaderboardGrid2
            // 
            this.tsLeaderboardGrid2.BackColor = System.Drawing.Color.DarkBlue;
            this.tsLeaderboardGrid2.Configuration = null;
            this.tsLeaderboardGrid2.Location = new System.Drawing.Point(0, 0);
            this.tsLeaderboardGrid2.MaxRowCount = 20;
            this.tsLeaderboardGrid2.Name = "tsLeaderboardGrid2";
            this.tsLeaderboardGrid2.Size = new System.Drawing.Size(795, 399);
            this.tsLeaderboardGrid2.TabIndex = 0;
            // 
            // TimingAndScoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(1524, 654);
            this.ContextMenuStrip = this.ctxMain;
            this.Controls.Add(this.pnlLeaderboard);
            this.Controls.Add(this.pnlFastLapsAndPoints);
            this.Controls.Add(this.pnlTop);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "TimingAndScoring";
            this.Text = "r/NASCAR Timing and Scoring";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TimingAndScoring_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TimingAndScoring_KeyDown);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlLeaderboard.ResumeLayout(false);
            this.pnlRaceInfo.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.pnlFastLapsAndPoints.ResumeLayout(false);
            this.ctxMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Timer pollFeedTimer;
        private Views.TSTrackState tsTrackState;
        private Views.TSBiggestMoversGrid tsBiggestMoversGrid1;
        private Views.TSLapLeaderGrid tsLapLeaderGrid1;
        private Views.TSOffThePaceGrid tsOffThePaceGrid1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Views.TSPitPenaltiesGrid tsPitPenaltiesGrid1;
        private System.Windows.Forms.Panel pnlLeaderboard;
        private System.Windows.Forms.Panel pnlRaceInfo;
        private System.Windows.Forms.Panel pnlFastLapsAndPoints;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label lblSession;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Label lblBattleGap;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label lblPitWindow;
        private System.Windows.Forms.Label lblPitWindowTitle;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label lblGreenLaps;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label lblYellowLaps;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblOnLeadLap;
        private Views.TSFastestLaps tsFastestLaps1;
        private Views.TSPoints tsPoints1;
        private Views.TSSingleFieldDisplay tsLeaders1;
        private Views.TSSingleFieldDisplay tsCautions1;
        private System.Windows.Forms.PictureBox picLogo;
        private Views.TSLeaderboardGrid tsLeaderboardGrid1;
        private Views.TSLeaderboardGrid tsLeaderboardGrid2;
        private Views.TSLeaderboard tsLeaderboard1;
        private System.Windows.Forms.ContextMenuStrip ctxMain;
        private System.Windows.Forms.ToolStripMenuItem autoRefreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem getFeedDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem getLiveEventSettingsToolStripMenuItem;
    }
}
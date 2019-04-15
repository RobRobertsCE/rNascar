namespace rNascarTS.Controls
{
    partial class UserControlBase
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.ctxUserControlBase = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.resizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.tipDescription = new System.Windows.Forms.ToolTip(this.components);
            this.editViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxUserControlBase.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHeader.ContextMenuStrip = this.ctxUserControlBase;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(270, 20);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Header";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeader.FontChanged += new System.EventHandler(this.lblHeader_FontChanged);
            this.lblHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            // 
            // ctxUserControlBase
            // 
            this.ctxUserControlBase.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resizeToolStripMenuItem,
            this.toolStripMenuItem1,
            this.setThemeToolStripMenuItem,
            this.editThemeToolStripMenuItem,
            this.editViewToolStripMenuItem,
            this.toolStripMenuItem2,
            this.closeToolStripMenuItem});
            this.ctxUserControlBase.Name = "ctxUserControlBase";
            this.ctxUserControlBase.Size = new System.Drawing.Size(181, 148);
            this.ctxUserControlBase.Opening += new System.ComponentModel.CancelEventHandler(this.ctxUserControlBase_Opening);
            // 
            // resizeToolStripMenuItem
            // 
            this.resizeToolStripMenuItem.Name = "resizeToolStripMenuItem";
            this.resizeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resizeToolStripMenuItem.Text = "&Resize";
            this.resizeToolStripMenuItem.Click += new System.EventHandler(this.resizeToolStripMenuItem_Click);
            // 
            // setThemeToolStripMenuItem
            // 
            this.setThemeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultToolStripMenuItem});
            this.setThemeToolStripMenuItem.Name = "setThemeToolStripMenuItem";
            this.setThemeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.setThemeToolStripMenuItem.Text = "&Set Theme";
            // 
            // defaultToolStripMenuItem
            // 
            this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            this.defaultToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.defaultToolStripMenuItem.Text = "Default";
            this.defaultToolStripMenuItem.Click += new System.EventHandler(this.selectThemeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // pnlDetail
            // 
            this.pnlDetail.BackColor = System.Drawing.Color.Black;
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetail.Location = new System.Drawing.Point(0, 22);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(272, 193);
            this.pnlDetail.TabIndex = 1;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(272, 22);
            this.pnlHeader.TabIndex = 2;
            this.pnlHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            // 
            // editViewToolStripMenuItem
            // 
            this.editViewToolStripMenuItem.Name = "editViewToolStripMenuItem";
            this.editViewToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editViewToolStripMenuItem.Text = "Edit &View";
            this.editViewToolStripMenuItem.Click += new System.EventHandler(this.editViewToolStripMenuItem_Click);
            // 
            // editThemeToolStripMenuItem
            // 
            this.editThemeToolStripMenuItem.Name = "editThemeToolStripMenuItem";
            this.editThemeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editThemeToolStripMenuItem.Text = "Edit &Theme";
            this.editThemeToolStripMenuItem.Click += new System.EventHandler(this.editThemeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // UserControlBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.ctxUserControlBase;
            this.Controls.Add(this.pnlDetail);
            this.Controls.Add(this.pnlHeader);
            this.DoubleBuffered = true;
            this.Name = "UserControlBase";
            this.Size = new System.Drawing.Size(272, 215);
            this.Load += new System.EventHandler(this.UserControlBase_Load);
            this.ctxUserControlBase.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.ContextMenuStrip ctxUserControlBase;
        private System.Windows.Forms.ToolStripMenuItem resizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.ToolStripMenuItem setThemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultToolStripMenuItem;
        private System.Windows.Forms.ToolTip tipDescription;
        private System.Windows.Forms.ToolStripMenuItem editThemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    }
}

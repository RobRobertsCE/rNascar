namespace rNascarTimingAndScoring.Dialogs
{
    partial class ConfigurationDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numPitWindowWarning = new System.Windows.Forms.NumericUpDown();
            this.numPitWindow = new System.Windows.Forms.NumericUpDown();
            this.numBattleGap = new System.Windows.Forms.NumericUpDown();
            this.numPollInterval = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.picBackground1 = new System.Windows.Forms.PictureBox();
            this.picBackground2 = new System.Windows.Forms.PictureBox();
            this.btnBackground1 = new System.Windows.Forms.Button();
            this.btnBackground2 = new System.Windows.Forms.Button();
            this.btnDefaults = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPitWindowWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPitWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBattleGap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPollInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Battle Gap";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(139, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pit Window";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(139, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Pit Window Warning";
            // 
            // numPitWindowWarning
            // 
            this.numPitWindowWarning.Location = new System.Drawing.Point(142, 80);
            this.numPitWindowWarning.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numPitWindowWarning.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numPitWindowWarning.Name = "numPitWindowWarning";
            this.numPitWindowWarning.Size = new System.Drawing.Size(71, 22);
            this.numPitWindowWarning.TabIndex = 3;
            this.numPitWindowWarning.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numPitWindow
            // 
            this.numPitWindow.Location = new System.Drawing.Point(142, 28);
            this.numPitWindow.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numPitWindow.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numPitWindow.Name = "numPitWindow";
            this.numPitWindow.Size = new System.Drawing.Size(71, 22);
            this.numPitWindow.TabIndex = 4;
            this.numPitWindow.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // numBattleGap
            // 
            this.numBattleGap.DecimalPlaces = 1;
            this.numBattleGap.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numBattleGap.Location = new System.Drawing.Point(15, 28);
            this.numBattleGap.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            65536});
            this.numBattleGap.Name = "numBattleGap";
            this.numBattleGap.Size = new System.Drawing.Size(71, 22);
            this.numBattleGap.TabIndex = 5;
            this.numBattleGap.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // numPollInterval
            // 
            this.numPollInterval.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numPollInterval.Location = new System.Drawing.Point(15, 80);
            this.numPollInterval.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numPollInterval.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numPollInterval.Name = "numPollInterval";
            this.numPollInterval.Size = new System.Drawing.Size(71, 22);
            this.numPollInterval.TabIndex = 7;
            this.numPollInterval.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Poll Interval";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(15, 117);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 31);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(315, 117);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 31);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(292, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Background 2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(292, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Background 1";
            // 
            // picBackground1
            // 
            this.picBackground1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBackground1.Location = new System.Drawing.Point(295, 28);
            this.picBackground1.Name = "picBackground1";
            this.picBackground1.Size = new System.Drawing.Size(83, 20);
            this.picBackground1.TabIndex = 12;
            this.picBackground1.TabStop = false;
            // 
            // picBackground2
            // 
            this.picBackground2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBackground2.Location = new System.Drawing.Point(295, 80);
            this.picBackground2.Name = "picBackground2";
            this.picBackground2.Size = new System.Drawing.Size(83, 20);
            this.picBackground2.TabIndex = 13;
            this.picBackground2.TabStop = false;
            // 
            // btnBackground1
            // 
            this.btnBackground1.Location = new System.Drawing.Point(384, 27);
            this.btnBackground1.Name = "btnBackground1";
            this.btnBackground1.Size = new System.Drawing.Size(37, 23);
            this.btnBackground1.TabIndex = 14;
            this.btnBackground1.Text = "Set";
            this.btnBackground1.UseVisualStyleBackColor = true;
            this.btnBackground1.Click += new System.EventHandler(this.btnBackground1_Click);
            // 
            // btnBackground2
            // 
            this.btnBackground2.Location = new System.Drawing.Point(384, 77);
            this.btnBackground2.Name = "btnBackground2";
            this.btnBackground2.Size = new System.Drawing.Size(37, 23);
            this.btnBackground2.TabIndex = 15;
            this.btnBackground2.Text = "Set";
            this.btnBackground2.UseVisualStyleBackColor = true;
            this.btnBackground2.Click += new System.EventHandler(this.btnBackground2_Click);
            // 
            // btnDefaults
            // 
            this.btnDefaults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDefaults.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDefaults.ForeColor = System.Drawing.Color.Black;
            this.btnDefaults.Location = new System.Drawing.Point(126, 117);
            this.btnDefaults.Name = "btnDefaults";
            this.btnDefaults.Size = new System.Drawing.Size(105, 31);
            this.btnDefaults.TabIndex = 16;
            this.btnDefaults.Text = "Defaults";
            this.btnDefaults.UseVisualStyleBackColor = true;
            this.btnDefaults.Click += new System.EventHandler(this.btnDefaults_Click);
            // 
            // ConfigurationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(432, 160);
            this.Controls.Add(this.btnDefaults);
            this.Controls.Add(this.btnBackground2);
            this.Controls.Add(this.btnBackground1);
            this.Controls.Add(this.picBackground2);
            this.Controls.Add(this.picBackground1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numPollInterval);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numBattleGap);
            this.Controls.Add(this.numPitWindow);
            this.Controls.Add(this.numPitWindowWarning);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConfigurationDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numPitWindowWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPitWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBattleGap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPollInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numPitWindowWarning;
        private System.Windows.Forms.NumericUpDown numPitWindow;
        private System.Windows.Forms.NumericUpDown numBattleGap;
        private System.Windows.Forms.NumericUpDown numPollInterval;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox picBackground1;
        private System.Windows.Forms.PictureBox picBackground2;
        private System.Windows.Forms.Button btnBackground1;
        private System.Windows.Forms.Button btnBackground2;
        private System.Windows.Forms.Button btnDefaults;
    }
}
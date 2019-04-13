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
            ((System.ComponentModel.ISupportInitialize)(this.numPitWindowWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPitWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBattleGap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPollInterval)).BeginInit();
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
            this.btnSave.Location = new System.Drawing.Point(15, 118);
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
            this.btnCancel.Location = new System.Drawing.Point(172, 118);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 31);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ConfigurationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(289, 161);
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
    }
}
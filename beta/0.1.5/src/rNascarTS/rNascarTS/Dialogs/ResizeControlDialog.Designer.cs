namespace rNascarTS.Dialogs
{
    partial class ResizeControlDialog
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
            this.numRowSpan = new System.Windows.Forms.NumericUpDown();
            this.numColSpan = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numRowSpan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColSpan)).BeginInit();
            this.SuspendLayout();
            // 
            // numRowSpan
            // 
            this.numRowSpan.Location = new System.Drawing.Point(15, 27);
            this.numRowSpan.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numRowSpan.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRowSpan.Name = "numRowSpan";
            this.numRowSpan.Size = new System.Drawing.Size(65, 20);
            this.numRowSpan.TabIndex = 0;
            this.numRowSpan.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRowSpan.ValueChanged += new System.EventHandler(this.Span_ValueChanged);
            // 
            // numColSpan
            // 
            this.numColSpan.Location = new System.Drawing.Point(118, 27);
            this.numColSpan.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numColSpan.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numColSpan.Name = "numColSpan";
            this.numColSpan.Size = new System.Drawing.Size(65, 20);
            this.numColSpan.TabIndex = 1;
            this.numColSpan.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numColSpan.ValueChanged += new System.EventHandler(this.Span_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rows";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Columns";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(118, 67);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(15, 67);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ResizeControlDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 104);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numColSpan);
            this.Controls.Add(this.numRowSpan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ResizeControlDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set Size";
            this.Load += new System.EventHandler(this.ResizeControlDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numRowSpan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColSpan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numRowSpan;
        private System.Windows.Forms.NumericUpDown numColSpan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}
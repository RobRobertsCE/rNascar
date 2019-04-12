namespace rNascarTimingAndScoring
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.txtRaw = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.tsLapLeaderGrid1 = new rNascarTimingAndScoring.Views.TSLapLeaderGrid();
            this.button9 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Live Feed";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Raw";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(174, 12);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(595, 20);
            this.txtUrl.TabIndex = 2;
            this.txtUrl.Text = "https://www.nascar.com/cacher/2019/1/4780/entryList.json";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 170);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1117, 174);
            this.dataGridView1.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 41);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 37);
            this.button3.TabIndex = 4;
            this.button3.Text = "Lap Average";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(93, 41);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 37);
            this.button4.TabIndex = 5;
            this.button4.Text = "Settings";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 84);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 37);
            this.button5.TabIndex = 6;
            this.button5.Text = "Entry List";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // txtRaw
            // 
            this.txtRaw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRaw.Location = new System.Drawing.Point(12, 350);
            this.txtRaw.Multiline = true;
            this.txtRaw.Name = "txtRaw";
            this.txtRaw.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRaw.Size = new System.Drawing.Size(1117, 247);
            this.txtRaw.TabIndex = 8;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(12, 127);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 37);
            this.button7.TabIndex = 9;
            this.button7.Text = "Race Results";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(114, 97);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 10;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(543, 55);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 11;
            this.button8.Text = "button8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // tsLapLeaderGrid1
            // 
            this.tsLapLeaderGrid1.BackColor = System.Drawing.Color.MidnightBlue;
            this.tsLapLeaderGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsLapLeaderGrid1.Location = new System.Drawing.Point(655, 41);
            this.tsLapLeaderGrid1.Margin = new System.Windows.Forms.Padding(1);
            this.tsLapLeaderGrid1.MaxRows = 5;
            this.tsLapLeaderGrid1.Name = "tsLapLeaderGrid1";
            this.tsLapLeaderGrid1.Padding = new System.Windows.Forms.Padding(1);
            this.tsLapLeaderGrid1.Size = new System.Drawing.Size(476, 220);
            this.tsLapLeaderGrid1.TabIndex = 12;
            this.tsLapLeaderGrid1.ValueColumnWidth = 120;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(543, 91);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 13;
            this.button9.Text = "button9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 609);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.tsLapLeaderGrid1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.txtRaw);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox txtRaw;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button8;
        private Views.TSLapLeaderGrid tsLapLeaderGrid1;
        private System.Windows.Forms.Button button9;
    }
}


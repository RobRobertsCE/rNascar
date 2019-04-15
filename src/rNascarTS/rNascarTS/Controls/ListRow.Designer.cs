namespace rNascarTS.Controls
{
    partial class ListRow
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
            this.SuspendLayout();
            // 
            // ListRow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Name = "ListRow";
            this.Size = new System.Drawing.Size(388, 42);
            this.BackColorChanged += new System.EventHandler(this.ListRow_BackColorChanged);
            this.FontChanged += new System.EventHandler(this.ListRow_FontChanged);
            this.ForeColorChanged += new System.EventHandler(this.ListRow_ForeColorChanged);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

﻿using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using rNascarTimingAndScoring.Models;

namespace rNascarTimingAndScoring.Views
{
    public partial class TSLeadersDisplay : UserControl
    {
        private string _details;

        private SingleFieldModel _model;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SingleFieldModel Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                UpdateDisplay(_model);
            }
        }

        public TSLeadersDisplay()
        {
            InitializeComponent();
        }

        private void TSSingleFieldDisplay_Load(object sender, System.EventArgs e)
        {
        }

        protected virtual void UpdateDisplay(SingleFieldModel model)
        {
            var detailLabel = model.SubCount == 1 ? "CHANGE" : "CHANGES";
            _details = $"{model.Count}  ({model.SubCount} {detailLabel})";
            this.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (string.IsNullOrEmpty(_details))
                return;

            using (Font myFont = new Font(pictureBox1.Parent.Font.FontFamily, 12, FontStyle.Bold))
            {
                SizeF size = e.Graphics.MeasureString(_details, myFont);

                var x = (pictureBox1.Width / 2) - (size.Width / 2);
                var y = (pictureBox1.Height / 2) - (size.Height / 2);

                using (Brush foreBrush = new SolidBrush(ForeColor))
                {
                    e.Graphics.DrawString(_details, myFont, foreBrush, new PointF(x, y));
                }
            }
        }
    }
}

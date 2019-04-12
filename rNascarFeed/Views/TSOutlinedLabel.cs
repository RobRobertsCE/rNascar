using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace rNascarTimingAndScoring.Views
{
    public class TSOutlinedLabel : Label
    {
        public TSOutlinedLabel()
        {
            OutlineForeColor = Color.Black;
            OutlineWidth = 2;
        }

        public Color OutlineForeColor { get; set; }
        public float OutlineWidth { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(BackColor), ClientRectangle);

            if (string.IsNullOrEmpty(Text))
                return;

            SizeF size = e.Graphics.MeasureString(Text, Font);

            using (GraphicsPath gp = new GraphicsPath())
            {
                using (Pen outline = new Pen(OutlineForeColor, OutlineWidth) { LineJoin = LineJoin.Round })
                {
                    using (StringFormat sf = new StringFormat())
                    {
                        using (Brush foreBrush = new SolidBrush(ForeColor))
                        {
                            gp.AddString(
                                Text,
                                Font.FontFamily,
                                (int)Font.Style,
                                Font.Size,
                                ClientRectangle,
                                sf);

                            e.Graphics.TranslateTransform((ClientRectangle.Width / 2) - (size.Width / 2), (ClientRectangle.Height / 2) - (size.Height / 2));
                            e.Graphics.ScaleTransform(1.3f, 1.35f);
                            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                            e.Graphics.DrawPath(outline, gp);
                            e.Graphics.FillPath(foreBrush, gp);


                        }
                    }
                }
            }

        }
    }
}

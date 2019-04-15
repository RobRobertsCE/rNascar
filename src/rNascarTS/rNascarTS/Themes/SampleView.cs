using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using rNascarTS.Models;

namespace rNascarTS.Themes
{

    public partial class SampleView : UserControl
    {
        #region events

        public event EventHandler<Control> ControlSelected;
        protected virtual void OnControlSelected(Control control)
        {
            var handler = ControlSelected;

            if (handler != null)
            {
                handler.Invoke(this, control);
            }
        }

        #endregion

        #region properties

        public virtual ViewType ViewType { get; }

        public Theme Theme { get; set; }

        #endregion

        #region ctor

        public SampleView()
        {
            InitializeComponent();
        }
        #endregion

        #region public

        public virtual void ApplyTheme(Theme theme)
        {
            this.BackColor = theme.ViewBackColor;
        }

        public virtual void UpdateTheme(Theme theme)
        {
            theme.ViewBackColor = this.BackColor;
        }

        public virtual IList<ThemeSection> GetThemeSections()
        {
            var themeSections = new List<ThemeSection>();

            themeSections.Add(new ThemeSection()
            {
                Name = "Main Body",
                Controls = new List<Control>() { this }
            });

            foreach (Control sectionControl in themeSections.SelectMany(s => s.Controls))
            {
                sectionControl.DoubleClick += SectionControl_DoubleClick;
            }

            return themeSections;
        }

        #endregion

        #region protected

        protected virtual void SectionControl_DoubleClick(object sender, EventArgs e)
        {
            OnControlSelected((Control)sender);
        }

        protected virtual void SectionControl_FontChanged(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            Control parent = (Control)label.Parent;
            string textToMeasure = String.IsNullOrEmpty(label.Text) ? "SampleText" : label.Text;

            Image image = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(image);
            SizeF labelTextSize = graphics.MeasureString(textToMeasure, label.Font);
            parent.Height = (int)labelTextSize.Height + parent.Padding.Top + parent.Padding.Bottom + 2;
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using rNascarTS.Models;

namespace rNascarTS.Themes
{
    public partial class SampleGridView : SampleView
    {
        #region properties

        public override ViewType ViewType => ViewType.List;

        #endregion

        #region ctor

        public SampleGridView()
            : base()
        {
            InitializeComponent();
        }

        #endregion

        #region public

        public override void ApplyTheme(Theme theme)
        {
            base.ApplyTheme(theme);

            pnlRow1.ForeColor = theme.PrimaryForeColor;
            pnlRow1.BackColor = theme.PrimaryBackColor;
            pnlRow1.Font = theme.GridFont;

            pnlRow3.ForeColor = theme.PrimaryForeColor;
            pnlRow3.BackColor = theme.PrimaryBackColor;
            pnlRow3.Font = theme.GridFont;

            lblRow1Text.ForeColor = theme.PrimaryForeColor;
            lblRow1Text.BackColor = theme.PrimaryBackColor;
            lblRow1Text.Font = theme.GridFont;

            lblRow3Text.ForeColor = theme.PrimaryForeColor;
            lblRow3Text.BackColor = theme.PrimaryBackColor;
            lblRow3Text.Font = theme.GridFont;

            pnlRow2.ForeColor = theme.SecondaryForeColor;
            pnlRow2.BackColor = theme.SecondaryBackColor;
            pnlRow2.Font = theme.GridFont;

            pnlRow4.ForeColor = theme.SecondaryForeColor;
            pnlRow4.BackColor = theme.SecondaryBackColor;
            pnlRow4.Font = theme.GridFont;

            lblRow2Text.ForeColor = theme.SecondaryForeColor;
            lblRow2Text.BackColor = theme.SecondaryBackColor;
            lblRow2Text.Font = theme.GridFont;

            lblRow4Text.ForeColor = theme.SecondaryForeColor;
            lblRow4Text.BackColor = theme.SecondaryBackColor;
            lblRow4Text.Font = theme.GridFont;

            pnlColumnHeader.ForeColor = theme.GridColumnHeaderForeColor;
            pnlColumnHeader.BackColor = theme.GridColumnHeaderBackColor;
            pnlColumnHeader.Font = theme.GridColumnHeaderFont;

            lblColumnHeader.ForeColor = theme.GridColumnHeaderForeColor;
            lblColumnHeader.BackColor = theme.GridColumnHeaderBackColor;
            lblColumnHeader.Font = theme.GridColumnHeaderFont;

            lblHeader.ForeColor = theme.HeaderForeColor;
            lblHeader.BackColor = theme.HeaderBackColor;
            lblHeader.Font = theme.HeaderFont;

            #region protected
            #endregion
        }

        public override void UpdateTheme(Theme theme)
        {
            base.UpdateTheme(theme);

            theme.PrimaryForeColor = pnlRow1.ForeColor;
            theme.PrimaryBackColor = pnlRow1.BackColor;

            theme.SecondaryForeColor = pnlRow2.ForeColor;
            theme.SecondaryBackColor = pnlRow2.BackColor;
            theme.GridFont = pnlRow1.Font;

            theme.GridColumnHeaderForeColor = pnlColumnHeader.ForeColor;
            theme.GridColumnHeaderBackColor = pnlColumnHeader.BackColor;
            theme.GridColumnHeaderFont = pnlColumnHeader.Font;

            theme.HeaderForeColor = lblHeader.ForeColor;
            theme.HeaderBackColor = lblHeader.BackColor;
            theme.HeaderFont = lblHeader.Font;
        }

        public override IList<ThemeSection> GetThemeSections()
        {
            var themeSections = base.GetThemeSections();

            var localThemeSections = new List<ThemeSection>();

            localThemeSections.Add(new ThemeSection()
            {
                Name = lblHeader.Text,
                Controls = new List<Control>() { lblHeader }
            });

            localThemeSections.Add(new ThemeSection()
            {
                Name = lblColumnHeader.Text,
                Controls = new List<Control>() { pnlColumnHeader, lblColumnHeader }
            });

            localThemeSections.Add(new ThemeSection()
            {
                Name = lblRow1Text.Text,
                Controls = new List<Control>() { pnlRow1, pnlRow3, lblRow1Text, lblRow3Text }
            });

            localThemeSections.Add(new ThemeSection()
            {
                Name = lblRow2Text.Text,
                Controls = new List<Control>() { pnlRow2, pnlRow4, lblRow2Text, lblRow4Text }
            });

            foreach (Control sectionControl in localThemeSections.SelectMany(s => s.Controls))
            {
                sectionControl.DoubleClick += SectionControl_DoubleClick;
            }

            ((List<ThemeSection>)themeSections).AddRange(localThemeSections);

            return themeSections;
        }

        private void SectionControl_FontChanged(object sender, EventArgs e)
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

        #region protected

        #endregion
    }
}

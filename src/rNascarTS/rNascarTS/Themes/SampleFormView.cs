using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using rNascarTS.Models;

namespace rNascarTS.Themes
{
    public partial class SampleFormView : SampleView
    {
        #region properties

        public override ViewType ViewType => ViewType.Application;

        #endregion

        #region ctor

        public SampleFormView()
            : base()
        {
            InitializeComponent();
        }

        #endregion

        #region public

        public override void ApplyTheme(Theme theme)
        {
            pnlBody.ForeColor = theme.PrimaryForeColor;
            pnlBody.BackColor = theme.PrimaryBackColor;
            pnlBody.Font = theme.ViewFont;

            statusStrip1.ForeColor = theme.ViewForeColor;
            statusStrip1.BackColor = theme.ViewBackColor;
            statusStrip1.Font = theme.ViewFont;

            toolStrip1.ForeColor = theme.ViewForeColor;
            toolStrip1.BackColor = theme.ViewBackColor;
            toolStrip1.Font = theme.ViewFont;

            menuStrip1.ForeColor = theme.ViewForeColor;
            menuStrip1.BackColor = theme.ViewBackColor;
            menuStrip1.Font = theme.ViewFont;

            button1.ForeColor = theme.ViewForeColor;
            button1.BackColor = theme.ViewBackColor;
            button1.Font = theme.ViewFont;

            panel1.ForeColor = theme.SecondaryForeColor;
            panel1.BackColor = theme.SecondaryBackColor;
        }

        public override void UpdateTheme(Theme theme)
        {
            theme.ViewForeColor = pnlBody.ForeColor;
            theme.ViewBackColor = pnlBody.BackColor;
            theme.ViewFont = pnlBody.Font;

            theme.PrimaryForeColor = statusStrip1.ForeColor;
            theme.PrimaryBackColor = statusStrip1.BackColor;
            theme.ViewFont = statusStrip1.Font;

            theme.PrimaryForeColor = button1.ForeColor;
            theme.PrimaryBackColor = button1.BackColor;
            theme.GridFont = button1.Font;

            theme.SecondaryForeColor = panel1.ForeColor;
            theme.SecondaryBackColor = panel1.BackColor;
        }

        public override IList<ThemeSection> GetThemeSections()
        {
            var themeSections = new List<ThemeSection>();

            themeSections.Add(new ThemeSection()
            {
                Name = "Form",
                Controls = new List<Control>() { statusStrip1, toolStrip1, menuStrip1 }
            });

            themeSections.Add(new ThemeSection()
            {
                Name = "Body",
                Controls = new List<Control>() { pnlBody }
            });

            themeSections.Add(new ThemeSection()
            {
                Name = "Buttons",
                Controls = new List<Control>() { button1 }
            });

            themeSections.Add(new ThemeSection()
            {
                Name = "Form Panels",
                Controls = new List<Control>() { panel1 }
            });

            foreach (Control sectionControl in themeSections.SelectMany(s => s.Controls))
            {
                sectionControl.DoubleClick += SectionControl_DoubleClick;
            }

            return themeSections;
        }

        #endregion

        #region protected

        #endregion
    }
}

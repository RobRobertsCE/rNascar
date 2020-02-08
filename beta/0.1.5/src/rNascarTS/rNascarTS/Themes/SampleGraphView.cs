using System.Collections.Generic;
using rNascarTS.Models;

namespace rNascarTS.Themes
{
    public partial class SampleGraphView : SampleView
    {
        #region properties

        public override ViewType ViewType => ViewType.Graph;

        #endregion

        #region ctor

        public SampleGraphView()
            : base()
        {
            InitializeComponent();
        }

        #endregion

        #region public

        public override void ApplyTheme(Theme theme)
        {
            base.ApplyTheme(theme);
        }

        public override void UpdateTheme(Theme theme)
        {
            base.UpdateTheme(theme);
        }

        public override IList<ThemeSection> GetThemeSections()
        {
            var _controlSamples = base.GetThemeSections();

            return _controlSamples;
        }

        #endregion
    }
}

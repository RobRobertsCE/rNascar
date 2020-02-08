using rNascarTS.Themes;

namespace rNascarTS.Controls
{
    public partial class ListHeader : ListRow
    {
        private const int ListHeaderIndex = -1;

        public ListHeader()
           : base(ListHeaderIndex)
        {
            InitializeComponent();
        }

        public override void ApplyTheme(Theme theme)
        {
            BackColor = theme.GridColumnHeaderBackColor;
            ForeColor = theme.GridColumnHeaderForeColor;

            Font = theme.GridColumnHeaderFont;

            Invalidate();
        }
    }
}

using System.Collections.Generic;
using System.Windows.Forms;

namespace rNascarTS.Themes
{
    public class ThemeSection
    {
        public string Name { get; set; }
        public IList<Control> Controls { get; set; } = new List<Control>();
    }
}

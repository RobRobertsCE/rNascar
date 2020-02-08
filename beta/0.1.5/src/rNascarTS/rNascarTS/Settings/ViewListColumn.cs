using System.Drawing;
using rNascarTS.Models;

namespace rNascarTS.Settings
{
    public class ViewListColumn
    {
        public int Index { get; set; }
        public string Caption { get; set; }
        public string DataFeed { get; set; }
        public string DataMember { get; set; }
        public string DataFullPath { get; set; }
        public int? Width { get; set; }
        public ContentAlignment Alignment { get; set; } = ContentAlignment.MiddleLeft;
        public string Format { get; set; }
        public SortType SortType { get; set; }
    }
}

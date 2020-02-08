using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace rNascarTS.Settings
{
    public class ViewListSettings
    {
        public int? MaxRows { get; set; }
        public int? RowHeight { get; set; }
        public string DataSource { get; set; }
        public IEnumerable<string> DataFeeds
        {
            get
            {
                return Columns.Select(c => c.DataFeed).Distinct();
            }
        }
        public bool ShowColumnCaptions { get; set; } = true;
        public bool ShowHeader { get; set; } = true;
        public int? FillColumnIndex
        {
            get
            {
                var fillColumn = Columns.FirstOrDefault(c => c.Width == null);
                return fillColumn != null ? fillColumn.Index : (int?)null;
            }
        }

        public IList<ViewListColumn> Columns { get; set; } = new List<ViewListColumn>();

        [JsonIgnore()]
        public IList<ViewListColumn> OrderedColumns
        {
            get
            {
                return Columns.OrderBy(c => c.Index).ToList();
            }
        }
    }
}

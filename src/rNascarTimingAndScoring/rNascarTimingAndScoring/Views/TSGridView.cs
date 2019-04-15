using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using rNascarTimingAndScoring.Models;

namespace rNascarTimingAndScoring.Views
{
    public partial class TSGridView : UserControl
    {
        private IDictionary<int, TSGridRow> _rows = new Dictionary<int, TSGridRow>();

        public virtual int ValueColumnWidth
        {
            get
            {
                return RightTitle.Width;
            }
            set
            {
                RightTitle.Width = value;
            }
        }

        private IList<TSGridRowModel> _models;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IList<TSGridRowModel> Models
        {
            get
            {
                if (_models == null)
                    _models = new List<TSGridRowModel>();

                return _models;
            }
            set
            {
                _models = value;
                DisplayModels(_models);
            }
        }

        public int? MaxRows { get; set; }

        public TSGridView()
        {
            InitializeComponent();

            UpdateTheme();

            RightTitle.Width = ValueColumnWidth;
        }

        public void UpdateTheme()
        {
            BackColor = TSColorMap.AlternateBackColor;
            pnlGridRows.BackColor = TSColorMap.PrimaryBackColor;
        }

        protected virtual void DisplayModels(IList<TSGridRowModel> models)
        {
            var maxRows = !MaxRows.HasValue ? models.Count :
                MaxRows.HasValue && models.Count > MaxRows.Value ?
                MaxRows.Value :
                models.Count;

            for (int i = 0; i < maxRows; i++)
            {
                if (!_rows.ContainsKey(i))
                {
                    var newRow = new TSGridRow()
                    {
                        Model = new TSGridRowModel() { Index = i },
                        Dock = DockStyle.Top,
                        ValueColumnWidth = ValueColumnWidth
                    };
                    _rows.Add(i, newRow);
                    pnlGridRows.Controls.Add(newRow);
                    newRow.BringToFront();
                }

                var row = _rows[i];

                row.Model = models[i];
            }
        }
    }
}

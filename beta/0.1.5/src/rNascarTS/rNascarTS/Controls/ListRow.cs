using System.Linq;
using System.Windows.Forms;
using rNascarTS.Themes;

namespace rNascarTS.Controls
{
    public partial class ListRow : UserControl
    {
        public virtual int Index { get; set; }

        public ListRow(int index = -1)
            : this()
        {
            Index = index;
        }

        protected ListRow()
        {
            InitializeComponent();

            Dock = DockStyle.Top;
        }

        //public void AddColumns(IList<ViewListColumn> columns)
        //{
        //    foreach (ViewListColumn column in columns.OrderBy(c => c.Index))
        //    {
        //        AddColumn(column);
        //    }
        //    for (int i = Controls.Count - 1; i >= 0; i--)
        //    {
        //        if (i == 0)
        //        {
        //            Controls[i].Dock = DockStyle.Fill;
        //        }
        //        else
        //        {
        //            Controls[i].Dock = DockStyle.Right;
        //            Controls[i].BringToFront();
        //        }
        //    }
        //}

        //public virtual void AddColumn(ViewListColumn column)
        //{
        //    var columnHeader = new Label()
        //    {
        //        Text = "-",
        //        TextAlign = column.Alignment,
        //        AutoSize = false,
        //        Dock = DockStyle.Right,
        //        BackColor = Color.FromKnownColor(KnownColor.Control),
        //        BorderStyle = BorderStyle.FixedSingle,
        //        Tag = column
        //    };

        //    Controls.Add(columnHeader);

        //    if (column.Width.HasValue)
        //        columnHeader.Size = new Size(column.Width.Value, columnHeader.Height);

        //    columnHeader.BringToFront();
        //}

        public virtual void ApplyTheme(Theme theme)
        {
            if (Index % 2 == 0)
            {
                BackColor = theme.PrimaryBackColor;
                ForeColor = theme.PrimaryForeColor;
            }
            else
            {
                BackColor = theme.SecondaryBackColor;
                ForeColor = theme.SecondaryForeColor;
            }

            Font = theme.GridFont;

            Invalidate();
        }

        public virtual void ClearColumns()
        {
            foreach (Label label in this.Controls.OfType<Label>())
            {
                label.Text = string.Empty;
            }
        }

        public virtual ListRow DeepCopy()
        {
            ListRow newRow = new ListRow()
            {
                BackColor = this.BackColor,
                ForeColor = this.ForeColor,
                Font = this.Font,
                BorderStyle = this.BorderStyle,
                Dock = this.Dock,
                Width = this.Width,
                Height = this.Height,
                Tag = this.Tag,
            };

            foreach (Label label in this.Controls.OfType<Label>())
            {
                Label newLabel = new Label()
                {
                    Text = label.Text,
                    TextAlign = label.TextAlign,
                    AutoSize = label.AutoSize,
                    Dock = label.Dock,
                    BackColor = label.BackColor,
                    ForeColor = label.ForeColor,
                    Font = label.Font,
                    BorderStyle = label.BorderStyle,
                    Width = label.Width,
                    Height = label.Height,
                    Tag = label.Tag,
                };

                newRow.Controls.Add(newLabel);
            }

            return newRow;
        }

        public override string ToString()
        {
            return $"Index={Index}";
        }

        private void ListRow_BackColorChanged(object sender, System.EventArgs e)
        {
            foreach (Label control in Controls.OfType<Label>())
            {
                control.BackColor = this.BackColor;
            }
        }

        private void ListRow_FontChanged(object sender, System.EventArgs e)
        {
            foreach (Label control in Controls.OfType<Label>())
            {
                control.Font = this.Font;
            }
        }

        private void ListRow_ForeColorChanged(object sender, System.EventArgs e)
        {
            foreach (Label control in Controls.OfType<Label>())
            {
                control.ForeColor = this.ForeColor;
            }
        }
    }
}

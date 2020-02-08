using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using rNascarTS.Settings;

namespace rNascarTS.Services
{
    internal class ColumnBuilderService
    {
        public static void BuildGridColumns(
            ViewListSettings listSettings,
            Control.ControlCollection headerControls,
            Control.ControlCollection rowControls)
        {
            ClearControlCollection(headerControls);
            ClearControlCollection(rowControls);

            foreach (ViewListColumn column in listSettings.OrderedColumns)
            {
                if (headerControls != null)
                {
                    var columnHeaderLabel = BuildColumnLabel(column, true);
                    headerControls.Add(columnHeaderLabel);
                }

                if (rowControls != null)
                {
                    var columnRowLabel = BuildColumnLabel(column);
                    rowControls.Add(columnRowLabel);
                }
            }

            if (headerControls != null)
                AlignControls(headerControls, listSettings.FillColumnIndex);

            if (rowControls != null)
                AlignControls(rowControls, listSettings.FillColumnIndex);
        }

        public static void AlignControls(Control.ControlCollection controls, int? fillColumnIndex)
        {
            if (fillColumnIndex.HasValue)
            {
                for (int i = 0; i < fillColumnIndex.Value; i++)
                {
                    controls[i].Dock = DockStyle.Left;
                }

                for (int i = fillColumnIndex.Value + 1; i < controls.Count; i++)
                {
                    controls[i].Dock = DockStyle.Right;
                }

                controls[fillColumnIndex.Value].Dock = DockStyle.Fill;
                controls[fillColumnIndex.Value].BringToFront();
            }
            else
            {
                for (int i = controls.Count - 1; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        controls[i].Dock = DockStyle.Left;
                    }
                    else
                    {
                        controls[i].Dock = DockStyle.Right;
                    }

                    controls[0].Dock = DockStyle.Fill;
                    controls[0].BringToFront();
                }
            }
        }

        public static Label BuildColumnLabel(ViewListColumn column, bool isHeader = false)
        {
            var columnLabel = new Label()
            {
                Text = isHeader ? column.Caption : string.Empty,
                TextAlign = column.Alignment,
                AutoSize = false,
                BackColor = Color.FromKnownColor(KnownColor.Control),
                BorderStyle = BorderStyle.FixedSingle,
                Tag = column
            };

            if (column.Width.HasValue)
                columnLabel.Size = new Size(column.Width.Value, columnLabel.Height);

            return columnLabel;
        }

        private static void ClearControlCollection(Control.ControlCollection controls)
        {
            if (controls == null)
                return;

            for (int i = controls.Count - 1; i >= 0; i--)
            {
                var control = controls[i];
                controls.RemoveAt(i);
                control.Dispose();
            }
        }
    }
}

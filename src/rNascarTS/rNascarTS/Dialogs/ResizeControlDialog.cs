using System;
using System.Drawing;
using System.Windows.Forms;

namespace rNascarTS.Dialogs
{
    public partial class ResizeControlDialog : Form
    {
        public event EventHandler<Point> SpanSettingsChanged;
        protected virtual void OnSpanSettingsChanged()
        {
            var handler = SpanSettingsChanged;

            if (handler != null)
            {
                handler.Invoke(Target, new Point(RowSpan, ColumnSpan));
            }
        }

        private int _originalRowSpan;
        private int _originalColumnSpan;
        private bool _loading = true;

        public int RowSpan { get; set; }
        public int ColumnSpan { get; set; }
        public Control Target { get; set; }

        public ResizeControlDialog()
        {
            InitializeComponent();
        }

        public ResizeControlDialog(Control target, int rowSpan, int columnSpan)
            : this()
        {
            Target = target;
            RowSpan = rowSpan;
            ColumnSpan = columnSpan;
        }

        private void ResizeControlDialog_Load(object sender, EventArgs e)
        {
            _originalRowSpan = RowSpan;
            _originalColumnSpan = ColumnSpan;

            numRowSpan.Value = RowSpan;
            numColSpan.Value = ColumnSpan;

            _loading = false;
        }

        private void Span_ValueChanged(object sender, EventArgs e)
        {
            if (_loading)
                return;

            RowSpan = (int)numRowSpan.Value;
            ColumnSpan = (int)numColSpan.Value;

            OnSpanSettingsChanged();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            RowSpan = _originalRowSpan;
            ColumnSpan = _originalColumnSpan;

            OnSpanSettingsChanged();

            DialogResult = DialogResult.Cancel;
        }
    }
}

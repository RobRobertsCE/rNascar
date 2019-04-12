using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using rNascarTimingAndScoring.Models;

namespace rNascarTimingAndScoring.Views
{
    public partial class TSSingleFieldDisplay : UserControl
    {
        private SingleFieldModel _model;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SingleFieldModel Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                UpdateDisplay(_model);
            }
        }

        Color _detailBackColor = Color.Blue;
        public Color DetailBackColor
        {
            get
            {
                return _detailBackColor;
            }
            set
            {
                _detailBackColor = value;
                lblCount.BackColor = _detailBackColor;
                lblDetail.BackColor = _detailBackColor;
            }
        }

        Color _detailForeColor = Color.Black;
        public Color DetailForeColor
        {
            get
            {
                return _detailForeColor;
            }
            set
            {
                _detailForeColor = value;
                lblCount.ForeColor = _detailForeColor;
                lblDetail.ForeColor = _detailForeColor;
            }
        }

        string _detailCaption = "Details";
        public string DetailCaption
        {
            get
            {
                return _detailCaption;
            }
            set
            {
                _detailCaption = value;
                lblDetail.Text = FormatDetail(0);
            }
        }

        string _header = "Header";
        public string Header
        {
            get
            {
                return _header;
            }
            set
            {
                _header = value;
                lblHeader.Text = _header;
            }
        }

        public TSSingleFieldDisplay()
        {
            InitializeComponent();
        }

        protected virtual void UpdateDisplay(SingleFieldModel model)
        {
            lblCount.Text = _model.Count.ToString();
            lblDetail.Text = FormatDetail(_model.SubCount);
        }

        private void TSSingleFieldDisplay_Load(object sender, System.EventArgs e)
        {
            lblHeader.Text = Header;
        }

        private string FormatDetail(int value)
        {
            return $"({value} {DetailCaption})"; ;
        }
    }
}

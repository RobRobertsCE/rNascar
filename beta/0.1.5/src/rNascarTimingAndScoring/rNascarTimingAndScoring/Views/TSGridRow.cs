using System;
using System.ComponentModel;
using System.Windows.Forms;
using rNascarTimingAndScoring.Models;

namespace rNascarTimingAndScoring.Views
{
    public partial class TSGridRow : UserControl
    {
        private TSGridRowModel _model;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TSGridRowModel Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                DisplayModel(_model);
            }
        }

        public int ValueColumnWidth
        {
            get
            {
                return lblValue.Width;
            }
            set
            {
                lblValue.Width = value;
            }
        }

        public TSGridRow()
        {
            InitializeComponent();
        }

        protected virtual void DisplayModel(TSGridRowModel model)
        {
            this.BackColor = model.Index % 2 == 1 ?
              TSColorMap.AlternatingRowBackColor1 :
              TSColorMap.AlternatingRowBackColor0;

            DisplayPosition(model.Index);
            DisplayCarNumber(model.CarNumber);
            DisplayDriver(model.Driver);
            DisplayValue(model.Value);
        }
        protected virtual void DisplayPosition(int index)
        {
            string positionString = index >= 0 ? (index + 1).ToString() : String.Empty;
            lblPosition.Text = $"{positionString}.";
        }
        protected virtual void DisplayCarNumber(string carNumber)
        {
            lblCarNumber.Text = carNumber;
        }
        protected virtual void DisplayDriver(string driver)
        {
            lblDriver.Text = driver;
        }
        protected virtual void DisplayValue(string value)
        {
            lblValue.Text = value;
        }
    }
}

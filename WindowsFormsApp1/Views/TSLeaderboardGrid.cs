using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using rNascarTimingAndScoring.Models;

namespace rNascarTimingAndScoring.Views
{
    public partial class TSLeaderboardGrid : UserControl
    {
        private IDictionary<int, TSLeaderboardDriver> _driverViews = new Dictionary<int, TSLeaderboardDriver>();

        private IEnumerable<TSDriverModel> _models = new List<TSDriverModel>();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IEnumerable<TSDriverModel> Models
        {
            get
            {
                return _models;
            }
            set
            {
                _models = value;
                UpdateDisplay(_models);
            }
        }

        public TSConfiguration Configuration { get; set; }

        public int MaxRowCount { get; set; } = 20;

        public TSLeaderboardGrid()
        {
            InitializeComponent();

            BackColor = TSColorMap.PrimaryBackColor;
        }

        protected virtual void ExceptionHandler(Exception ex)
        {
            Console.WriteLine(ex);
            MessageBox.Show(ex.Message);
        }

        protected virtual void UpdateDisplay(IEnumerable<TSDriverModel> models)
        {
            this.SuspendLayout();

            try
            {
                var driverModels = models.ToList();

                for (int i = 0; i < driverModels.Count; i++)
                {
                    if (!_driverViews.ContainsKey(i))
                    {
                        var newDriverView = new TSLeaderboardDriver()
                        {
                            Margin = new Padding(0),
                            Dock = DockStyle.Top,
                            BorderStyle = BorderStyle.FixedSingle,
                            Configuration = this.Configuration 
                        };

                        Controls.Add(newDriverView);

                        newDriverView.BringToFront();

                        _driverViews.Add(i, newDriverView);
                    }

                    var driverView = _driverViews[i];

                    driverView.Model = driverModels[i];
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
            finally
            {
                this.ResumeLayout(true);
            }
        }
    }
}

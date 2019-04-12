using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using rNascarTimingAndScoring.Models;

namespace rNascarTimingAndScoring.Views
{
    public partial class TSLeaderboard : UserControl
    {
        public int MaxRowCount { get; set; } = 20;

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

        private TSConfiguration _configuration;
        public TSConfiguration Configuration
        {
            get
            {
                return _configuration;
            }
            set
            {
                _configuration = value;
                tsLeaderboardGrid0.Configuration = this.Configuration;
                tsLeaderboardGrid1.Configuration = this.Configuration;
            }
        }

        public TSLeaderboard(TSConfiguration configuration)
            :this()
        {
            Configuration = configuration;
        }

        public TSLeaderboard()
        {
            InitializeComponent();

            tsLeaderboardGrid0.MaxRowCount = this.MaxRowCount;
            tsLeaderboardGrid0.BackColor = TSColorMap.PrimaryBackColor;
            tsLeaderboardGrid1.MaxRowCount = this.MaxRowCount;
            tsLeaderboardGrid1.BackColor = TSColorMap.PrimaryBackColor;
        }

        protected virtual void UpdateDisplay(IEnumerable<TSDriverModel> models)
        {
            tsLeaderboardGrid0.Models = models.Where(m => m.Position <= MaxRowCount);
            tsLeaderboardGrid1.Models = models.Where(m => m.Position > MaxRowCount);
        }

        private void TSLeaderboard_Load(object sender, System.EventArgs e)
        {
            tsLeaderboardGrid0.Configuration = this.Configuration;
            tsLeaderboardGrid1.Configuration = this.Configuration;
        }
    }
}

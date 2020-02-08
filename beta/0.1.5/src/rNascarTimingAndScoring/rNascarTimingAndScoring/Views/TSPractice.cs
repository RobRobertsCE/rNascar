using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using rNascarTimingAndScoring.Models;

namespace rNascarTimingAndScoring.Views
{
    public partial class TSPractice : TSSessionBase, ITSView
    {
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
                tsLeaderboard1.Configuration = this.Configuration;
            }
        }

        public RunType RunType { get { return RunType.Practice; } }

        public TSPractice(TSConfiguration configuration)
         : this()
        {
            Configuration = configuration;
        }

        public TSPractice()
        {
            InitializeComponent();

            tsLeaderboard1.Configuration = this.Configuration;
        }

        public void UpdateDisplay(IList<TSDriverModel> models)
        {
            tsLeaderboard1.Models = models;
        }
        public void UpdateDisplay(IList<TSGridRowModel> models)
        {
            tsFastestLaps1.Models = models;
        }
        public void UpdateDisplay(IList<TSTenLapAverageGridRowModel> models)
        {
            tsLapAveragesGrid1.Models = models.OfType<TSGridRowModel>().ToList();
        }
    }
}

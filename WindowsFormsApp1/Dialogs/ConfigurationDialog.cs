using System;
using System.Windows.Forms;
using rNascarTimingAndScoring.Models;

namespace rNascarTimingAndScoring.Dialogs
{
    public partial class ConfigurationDialog : Form
    {
        private TSConfiguration _configuration;
        public TSConfiguration Configuration
        {
            get
            {
                if (_configuration == null)
                    _configuration = new TSConfiguration();

                return _configuration;
            }
            set
            {
                _configuration = value;
                DisplayConfiguration(_configuration);
            }
        }

        public ConfigurationDialog()
        {
            InitializeComponent();
        }

        protected virtual void ExceptionHandler(Exception ex)
        {
            Console.WriteLine(ex);
            MessageBox.Show(ex.Message);
        }

        protected virtual void DisplayConfiguration(TSConfiguration configuration)
        {
            try
            {
                numBattleGap.Value = (decimal)configuration.BattleGap;
                numPitWindow.Value = configuration.PitWindow;
                numPitWindowWarning.Value = configuration.PitWindowWarning;
                numPollInterval.Value = configuration.PollInterval;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration.BattleGap = (double)numBattleGap.Value;
                Configuration.PitWindow = (int)numPitWindow.Value;
                Configuration.PitWindowWarning = (int)numPitWindowWarning.Value;
                Configuration.PollInterval = (int)numPollInterval.Value;

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
    }
}

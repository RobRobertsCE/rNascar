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
                numPitWindow.Value = configuration.PitWindow.HasValue ? configuration.PitWindow.Value : (decimal)0.0;
                numPitWindowWarning.Value = configuration.PitWindowWarning;
                numPollInterval.Value = configuration.PollInterval < TSConfiguration.DefaultPollInterval ?
                    TSConfiguration.DefaultPollInterval :
                    configuration.PollInterval;

                picBackground1.BackColor = TSColorMap.PrimaryBackColor;
                picBackground2.BackColor = TSColorMap.AlternateBackColor;
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
                Configuration.PitWindow = numPitWindow.Value > 0 ? (int?)numPitWindow.Value : null;
                Configuration.PitWindowWarning = (int)numPitWindowWarning.Value;
                Configuration.PollInterval = (int)numPollInterval.Value;

                TSColorMap.PrimaryBackColor = picBackground1.BackColor;
                TSColorMap.AlternateBackColor = picBackground2.BackColor;
                TSColorMap.AlternatingRowBackColor1 = picBackground1.BackColor;
                TSColorMap.AlternatingRowBackColor0 = picBackground2.BackColor;

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnBackground1_Click(object sender, EventArgs e)
        {
            try
            {
                var colorPickerDialog = new ColorDialog()
                {
                    Color = picBackground1.BackColor,
                    AllowFullOpen = true
                };

                if (colorPickerDialog.ShowDialog(this) == DialogResult.OK)
                {
                    picBackground1.BackColor = colorPickerDialog.Color;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnBackground2_Click(object sender, EventArgs e)
        {
            try
            {
                var colorPickerDialog = new ColorDialog()
                {
                    Color = picBackground2.BackColor,
                    AllowFullOpen = true
                };

                if (colorPickerDialog.ShowDialog(this) == DialogResult.OK)
                {
                    picBackground2.BackColor = colorPickerDialog.Color;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnDefaults_Click(object sender, EventArgs e)
        {
            try
            {
                numBattleGap.Value = (decimal)TSConfiguration.DefaultBattleGap;
                numPitWindow.Value = 0;
                numPitWindowWarning.Value = TSConfiguration.DefaultPitWindowWarning;
                numPollInterval.Value = TSConfiguration.DefaultPollInterval;

                picBackground1.BackColor = TSColorMap.DefaultPrimaryBackColor;
                picBackground2.BackColor = TSColorMap.DefaultAlternateBackColor;

                DisplayConfiguration(Configuration);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;
using rNascarTimingAndScoring.Models;

namespace rNascarTimingAndScoring.Dialogs
{
    public partial class ConfigurationDialog : Form
    {
        private Color _backColor0;
        private Color _backColor1;

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

            _backColor0 = TSColorMap.PrimaryBackColor;
            _backColor1 = TSColorMap.AlternateBackColor;
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
                numPollInterval.Value = configuration.PollInterval < TSConfiguration.DefaultPollInterval ?
                    TSConfiguration.DefaultPollInterval :
                    configuration.PollInterval;

                picBackground1.BackColor = _backColor0;
                picBackground2.BackColor = _backColor1;
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

                TSColorMap.PrimaryBackColor = _backColor0;
                TSColorMap.AlternateBackColor = _backColor1;
                TSColorMap.AlternatingRowBackColor1 = _backColor0;
                TSColorMap.AlternatingRowBackColor0 = _backColor1;

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
                    Color = _backColor0,
                    AllowFullOpen = true
                };

                if (colorPickerDialog.ShowDialog(this) == DialogResult.OK)
                {
                    _backColor0 = colorPickerDialog.Color;
                    picBackground1.BackColor = _backColor0;
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
                    Color = _backColor1,
                    AllowFullOpen = true
                };

                if (colorPickerDialog.ShowDialog(this) == DialogResult.OK)
                {
                    _backColor1 = colorPickerDialog.Color;
                    picBackground2.BackColor = _backColor1;
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
                Configuration.BattleGap = 0.2;
                Configuration.PitWindow = 100;
                Configuration.PitWindowWarning = 5;
                Configuration.PollInterval = 5;
                _backColor0 = TSColorMap.DefaultPrimaryBackColor;
                _backColor1 = TSColorMap.DefaultAlternateBackColor;

                DisplayConfiguration(Configuration);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using log4net;
using log4net.Core;
using rNascarTimingAndScoring.Logging;
using rNascarTimingAndScoring.Models;

namespace rNascarTimingAndScoring.Dialogs
{
    public partial class ConfigurationDialog : Form
    {
        #region fields

        private IList<FavoriteDriver> _added = new List<FavoriteDriver>();
        private IList<FavoriteDriver> _removed = new List<FavoriteDriver>();

        #endregion

        #region properties

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

        public IList<FavoriteDriver> Favorites { get; set; }

        public IList<FavoriteDriver> AllDrivers { get; set; }

        public ILog Log { get; set; }

        #endregion

        #region ctor

        public ConfigurationDialog(ILog log)
            : this()
        {

            this.Log = log;
        }

        public ConfigurationDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region protected

        protected virtual void ExceptionHandler(string message, Exception ex)
        {
            if (Log != null)
                Log.Error(message, ex);
#if DEBUG
            Console.WriteLine(ex);
#endif
            MessageBox.Show($"{message}: {ex.Message}");
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

                chkVerboseLogging.Checked = Configuration.UseVerboseLogging;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error displaying configuration", ex);
            }
        }

        #endregion

        #region private

        private void ConfigurationDialog_Load(object sender, EventArgs e)
        {
            foreach (var driver in AllDrivers)
            {
                chkFavorites.Items.Add(driver, Favorites.Any(f => f.Driver == driver.Driver));
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration.UseVerboseLogging = chkVerboseLogging.Checked;
                Configuration.BattleGap = (double)numBattleGap.Value;
                Configuration.PitWindow = numPitWindow.Value > 0 ? (int?)numPitWindow.Value : null;
                Configuration.PitWindowWarning = (int)numPitWindowWarning.Value;
                Configuration.PollInterval = (int)numPollInterval.Value;

                TSColorMap.PrimaryBackColor = picBackground1.BackColor;
                TSColorMap.AlternateBackColor = picBackground2.BackColor;
                TSColorMap.AlternatingRowBackColor1 = picBackground1.BackColor;
                TSColorMap.AlternatingRowBackColor0 = picBackground2.BackColor;

                foreach (var addedFavorite in _added)
                {
                    if (!Favorites.Any(f => f.Driver == addedFavorite.Driver))
                    {
                        Favorites.Add(addedFavorite);
                    }
                }

                foreach (var removedFavorite in _removed)
                {
                    var favoriteToRemove = Favorites.FirstOrDefault(f => f.Driver == removedFavorite.Driver);

                    if (favoriteToRemove != null)
                    {
                        Favorites.Remove(favoriteToRemove);
                    }
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error saving configuration", ex);
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
                ExceptionHandler("Error setting background color", ex);
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
                ExceptionHandler("Error setting background color", ex);
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
                ExceptionHandler("Error setting configuration defaults", ex);
            }
        }

        private void chkFavorites_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var item = (FavoriteDriver)chkFavorites.Items[e.Index];

            if (e.NewValue == CheckState.Checked)
            {
                if (!_added.Contains(item))
                    _added.Add(item);

                if (_removed.Contains(item))
                    _removed.Remove(item);
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                if (!_removed.Contains(item))
                    _removed.Add(item);

                if (_added.Contains(item))
                    _added.Remove(item);
            }
        }

        #endregion
    }
}

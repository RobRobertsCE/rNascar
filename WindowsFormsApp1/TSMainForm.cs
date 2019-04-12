using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using NascarFeed.Models;
using NascarFeed.Ports;
using rNascarTimingAndScoring.Dialogs;
using rNascarTimingAndScoring.Models;
using rNascarTimingAndScoring.Views;

namespace rNascarTimingAndScoring
{
    public partial class TSMainForm : Form
    {
        #region fields

        private bool _isFullscreen = false;
        private IApiClient _apiClient;
        private ITSView _currentView;

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
                ConfigurationUpdated(_configuration);
            }
        }

        public EventSettings EventSettings { get; set; }

        #endregion

        #region ctor

        public TSMainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region protected

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        protected virtual void ExceptionHandler(Exception ex)
        {
            Console.WriteLine(ex);
            MessageBox.Show(ex.Message);
        }

        protected virtual void ConfigurationUpdated(TSConfiguration configuration)
        {
            pollFeedTimer.Interval = _configuration.PollInterval;
        }

        protected virtual void UpdateDisplay(int runType)
        {
            if (_currentView != null && (int)_currentView.RunType == runType)
                return;

            if (_currentView != null)
            {
                var currentView = (UserControl)Controls.OfType<ITSView>().FirstOrDefault();
                if (currentView != null)
                {
                    Controls.Remove(currentView);
                    ((UserControl)currentView).Dispose();
                }
            }

            switch ((RunType)runType)
            {
                case RunType.Practice:
                    {
                        _currentView = new TSPractice(this.Configuration)
                        {
                            Dock = DockStyle.Fill
                        };
                        Controls.Add((UserControl)_currentView);
                        break;
                    }
                case RunType.Qualifying:
                    {
                        _currentView = new TSPractice()
                        {
                            Configuration = this.Configuration,
                            Dock = DockStyle.Fill
                        };
                        Controls.Add((UserControl)_currentView);
                        break;
                    }
                case RunType.Race:
                    {
                        _currentView = new TSPractice()
                        {
                            Configuration = this.Configuration,
                            Dock = DockStyle.Fill
                        };
                        Controls.Add((UserControl)_currentView);
                        break;
                    }
            }
        }

        protected virtual void ReadFeedData()
        {
            try
            {
                if (_apiClient == null)
                    return;

                var feedData = _apiClient.GetLiveFeed(); //_apiClient.GetLiveFeed(EventSettings);

                UpdateDisplay(feedData.run_type);

                if (feedData.vehicles.Count == 0)
                {
                    MessageBox.Show("No data available for the selected event");
                    return;
                }

                this.SuspendLayout();

                var models = FormatLeaderboardData(feedData);
                DisplayLeaderboardData(models);

                var tenLapAverageData = _apiClient.GetLapAverages(EventSettings);

                var tenLapAverages = FormatTenLapAverages(tenLapAverageData);
                DisplayTenLapAverages(tenLapAverages);

                var fastestLapData = FormatFastestLapData(feedData);
                DisplayFastestLapData(fastestLapData);
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

        protected virtual void SetFullscreenState(bool setFullscreenOn)
        {
            if (setFullscreenOn)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }

            _isFullscreen = setFullscreenOn;
        }

        #endregion

        #region private

        // event handlers
        private void autoRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                pollFeedTimer.Enabled = autoRefreshToolStripMenuItem.Checked;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void eventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var dialog = new EventSettingsDialog()
                {
                    EventSettings = this.EventSettings
                };

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    EventSettings = dialog.EventSettings;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var dialog = new ConfigurationDialog()
                {
                    Configuration = _configuration
                };

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    Configuration = dialog.Configuration;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void getFeedDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ReadFeedData();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void TSMainForm_Load(object sender, EventArgs e)
        {
            _apiClient = ServiceProvider.Instance.GetRequiredService<IApiClient>();

            if (EventSettings == null || EventSettings.eventId == 0)
                EventSettings = new EventSettings()
                {
                    season = 2019,
                    seriesId = 1,
                    sessionId = 1,
                    activityId = 1,
                    eventId = 4781
                };

            pollFeedTimer.Enabled = false;
        }

        private void TSMainForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F11)
                    SetFullscreenState(!_isFullscreen);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }


        private IList<TSGridRowModel> FormatTenLapAverages(NascarFeed.Models.LapAverage.RootObject feedData)
        {
            var models = new List<TSGridRowModel>();

            foreach (var average in feedData.TenLapAverage.OrderBy(a => a.pos))
            {
                var model = new TSTenLapAverageGridRowModel()
                {
                    Index = Int32.Parse(average.pos),
                    CarNumber = average.carNumber,
                    Driver = average.dName,
                    TenLapAverage = average.lapSpeedAverage
                };

                model.Value = $"{average.lapSpeedAverage} ({average.fromLap}-{average.toLap})";

                models.Add(model);
            }

            var sortedModels = models.OrderByDescending(m => ((TSLapLeaderGridRowModel)m).TotalLapsLed).ToList();

            for (int i = 0; i < models.Count; i++)
            {
                sortedModels[i].Index = i;
            }

            return sortedModels;
        }
        private void DisplayTenLapAverages(IList<TSGridRowModel> models)
        {
            _currentView.UpdateDisplay(models);
        }

        private IList<TSDriverModel> FormatLeaderboardData(NascarFeed.Models.LiveFeed.RootObject feedData)
        {
            double previousDelta = 0.0;

            var models = new List<TSDriverModel>();

            foreach (var vehicle in feedData.vehicles)
            {
                try
                {

                    var model = new TSDriverModel()
                    {
                        Position = vehicle.running_position,
                        CarNumber = Int32.Parse(vehicle.vehicle_number),
                        Driver = vehicle.driver.full_name,
                        BehindLeader = vehicle.delta,
                        Manufacturer = vehicle.vehicle_manufacturer,
                        StartPosition = vehicle.starting_position,
                        LastLapTime = vehicle.last_lap_time,
                        FastestLapTime = vehicle.best_lap_time,
                        FastestLapNumber = vehicle.best_lap,
                        LastPitLap = vehicle.pit_stops.Count > 0 ? vehicle.pit_stops.LastOrDefault().pit_in_leader_lap : 0,
                        LapsComplete = vehicle.laps_completed,
                        BehindNext = vehicle.delta < 0 ?
                            previousDelta < 0 ?
                                vehicle.delta - previousDelta :
                                vehicle.delta :
                            vehicle.delta - previousDelta
                    };

                    models.Add(model);

                    previousDelta = vehicle.delta;

                }
                catch (Exception ex)
                {
                    ExceptionHandler(ex);
                }
            }

            return models;
        }
        private void DisplayLeaderboardData(IList<TSDriverModel> models)
        {
            _currentView.UpdateDisplay(models);
        }

        private IList<TSGridRowModel> FormatFastestLapData(NascarFeed.Models.LiveFeed.RootObject feedData)
        {
            var models = new List<TSGridRowModel>();

            var vehicleGains = feedData.vehicles.
                Select(v => new
                {
                    CarNumber = v.vehicle_number,
                    Driver = v.driver.full_name,
                    FastestLap = v.best_lap_speed
                });

            int index = 0;

            foreach (var vehicle in vehicleGains.OrderByDescending(v => v.FastestLap))
            {
                var model = new TSGridRowModel()
                {
                    Index = index,
                    CarNumber = vehicle.CarNumber,
                    Driver = vehicle.Driver,
                    Value = vehicle.FastestLap.ToString("###.##")
                };

                models.Add(model);

                index++;
            }

            return models;
        }
        private void DisplayFastestLapData(IList<TSGridRowModel> models)
        {
            _currentView.UpdateDisplay(models);
        }



        #endregion
    }
}

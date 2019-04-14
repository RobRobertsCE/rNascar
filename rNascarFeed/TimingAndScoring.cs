using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using NascarFeed.Models;
using NascarFeed.Ports;
using rNascarTimingAndScoring.Dialogs;
using rNascarTimingAndScoring.Helpers;
using rNascarTimingAndScoring.Models;

namespace rNascarTimingAndScoring
{
    public partial class TimingAndScoring : Form
    {
        #region fields

        private IApiClient _apiClient;
        private bool _isFullscreen = false;

        #endregion

        #region properties

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
                ConfigurationUpdated(_configuration);
            }
        }

        private EventSettings _eventSettings;
        public EventSettings EventSettings
        {
            get
            {
                return _eventSettings;
            }
            set
            {
                _eventSettings = value;
                EventSettingsUpdated(_eventSettings);
            }
        }

        #endregion

        #region ctor

        public TimingAndScoring()
        {
            InitializeComponent();

            Configuration = new TSConfiguration();

            tsLeaderboard1.Configuration = this.Configuration;
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

        protected virtual void ReadFeedData()
        {
            try
            {
                if (_apiClient == null)
                    return;

                var feedData = _apiClient.GetLiveFeed(EventSettings);

#if DEBUG
                //FeedWriter.LogFeedData(EventSettings, feedData.lap_number, feedData.ToString());
#endif
                if (feedData.vehicles.Count == 0)
                {
                    MessageBox.Show("No data available for the selected event");
                    return;
                }

                Configuration.RunType = (RunType)feedData.run_type;

                this.SuspendLayout();

                DisplayTrackState(feedData);

                DisplayRaceState(feedData);

                tsLeaderboard1.Models = FormatLeaderboardData(feedData);

                tsLapLeaderGrid1.Models = FormatLapLeaders(feedData);

                if (Configuration.RunType == RunType.Race)
                {
                    tsBiggestMoversGrid1.Models = FormatBiggestMoversData(feedData);

                    tsOffThePaceGrid1.Models = FormatOffThePaceData(feedData);
                }

                DisplayLeadersStatus(feedData);

                var liveFlagData = _apiClient.GetLiveFlagData();
                DisplayCautionsStatus(liveFlagData, feedData);

                tsFastestLaps1.Models = FormatFastestLapData(feedData);

                var pointsFeedData = _apiClient.GetLivePoints(EventSettings);
                tsPoints1.Models = FormatPointsData(pointsFeedData);
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

        protected virtual IList<TSDriverModel> FormatLeaderboardData(NascarFeed.Models.LiveFeed.RootObject feedData)
        {
            double previousDelta = 0.0;

            var models = new List<TSDriverModel>();

            var fastestThisLap = new List<TSDriverModel>();

            double fastestLapTimeThisLap = 999999;

            foreach (var vehicle in feedData.vehicles)
            {
                var model = new TSDriverModel()
                {
                    Position = vehicle.running_position,
                    CarNumber = vehicle.vehicle_number,
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
                        vehicle.delta - previousDelta,
                    IsOnTrack = vehicle.is_on_track,
                    VehicleStatus = (VehicleStatus)vehicle.status
                };

                models.Add(model);

                previousDelta = vehicle.delta;

                if (model.VehicleStatus == VehicleStatus.OnTrack)
                {
                    if (model.LastLapTime == fastestLapTimeThisLap)
                    {
                        fastestThisLap.Add(model);
                    }
                    else if (model.LastLapTime < fastestLapTimeThisLap)
                    {
                        fastestThisLap.Clear();
                        fastestThisLap.Add(model);
                        fastestLapTimeThisLap = model.LastLapTime;
                    }
                }
            }

            foreach (var model in fastestThisLap)
            {
                model.FastestThisLap = true;
            }

            return models;
        }

        protected virtual IList<TSGridRowModel> FormatLapLeaders(NascarFeed.Models.LiveFeed.RootObject feedData)
        {
            var models = new List<TSGridRowModel>();

            foreach (var vehicle in feedData.vehicles.Where(v => v.laps_led.Count > 0))
            {
                var model = new TSLapLeaderGridRowModel()
                {
                    CarNumber = vehicle.vehicle_number,
                    Driver = vehicle.driver.full_name,
                    TotalLapsLed = vehicle.laps_led.Sum(l => l.end_lap - l.start_lap),
                    TotalTimesLed = vehicle.laps_led.Count
                };

                model.Value = $"{model.TotalLapsLed} laps ({model.TotalTimesLed}x)";

                models.Add(model);
            }

            var sortedModels = models.OrderByDescending(m => ((TSLapLeaderGridRowModel)m).TotalLapsLed).ToList();

            for (int i = 0; i < models.Count; i++)
            {
                sortedModels[i].Index = i;
            }

            return sortedModels;
        }

        protected virtual IList<TSGridRowModel> FormatTenLapAverages(NascarFeed.Models.LapAverage.RootObject feedData)
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

        protected virtual IList<TSGridRowModel> FormatBiggestMoversData(NascarFeed.Models.LiveFeed.RootObject feedData)
        {
            var models = new List<TSGridRowModel>();

            var vehicleGains = feedData.vehicles.Select(v => new
            {
                CarNumber = v.vehicle_number,
                Driver = v.driver.full_name,
                Gain = v.position_differential_last_10_percent
            });

            int index = 0;

            foreach (var vehicle in vehicleGains.OrderByDescending(v => v.Gain).Take(8))
            {
                var model = new TSGridRowModel()
                {
                    Index = index,
                    CarNumber = vehicle.CarNumber,
                    Driver = vehicle.Driver,
                    Value = vehicle.Gain.ToString()
                };

                models.Add(model);

                index++;
            }

            return models;
        }

        protected virtual IList<TSGridRowModel> FormatOffThePaceData(NascarFeed.Models.LiveFeed.RootObject feedData)
        {
            var models = new List<TSGridRowModel>();

            var vehicleGains = feedData.vehicles.
                Where(v => v.status == 1). // Status 1=running, 2=off track, 3=out of event?
                Select(v => new
                {
                    CarNumber = v.vehicle_number,
                    Driver = v.driver.full_name,
                    Gain = v.position_differential_last_10_percent
                });

            int index = 0;

            foreach (var vehicle in vehicleGains.OrderBy(v => v.Gain).Take(8))
            {
                var model = new TSGridRowModel()
                {
                    Index = index,
                    CarNumber = vehicle.CarNumber,
                    Driver = vehicle.Driver,
                    Value = vehicle.Gain.ToString()
                };

                models.Add(model);

                index++;
            }

            return models;
        }

        protected virtual IList<TSGridRowModel> FormatFastestLapData(NascarFeed.Models.LiveFeed.RootObject feedData)
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

        protected virtual IList<TSGridRowModel> FormatPointsData(IList<NascarFeed.Models.LivePoints.RootObject> feedData)
        {
            var models = new List<TSGridRowModel>();

            int index = 0;

            foreach (var driverPoints in feedData.OrderByDescending(v => v.points))
            {
                var model = new TSGridRowModel()
                {
                    Index = index,
                    CarNumber = driverPoints.car_number,
                    Driver = $"{driverPoints.first_name} {driverPoints.last_name}",
                    Value = driverPoints.points.ToString()
                };

                models.Add(model);

                index++;
            }

            return models;
        }

        protected virtual void DisplayTrackState(NascarFeed.Models.LiveFeed.RootObject feed)
        {
            tsTrackState.TrackState = (TrackStates)feed.flag_state;
        }

        protected virtual void DisplayRaceState(NascarFeed.Models.LiveFeed.RootObject feed)
        {
            Text = FormatTitle(feed);
            tsTrackState.LapInfo = FormatLapInfo(feed);
            lblOnLeadLap.Text = feed.vehicles.Count(v => v.delta >= 0).ToString();
            lblYellowLaps.Text = feed.number_of_caution_laps.ToString();
            lblGreenLaps.Text = (feed.lap_number - feed.number_of_caution_laps).ToString();

            var sessionTimeSpan = new TimeSpan(0, 0, feed.elapsed_time);
            lblSession.Text = sessionTimeSpan.ToString();
        }

        protected virtual string FormatTitle(NascarFeed.Models.LiveFeed.RootObject feed)
        {
            string titleTemplate = "r/NASCAR Timing and Scoring {0}";
            string titleDetail = string.Empty;

            switch ((RunType)feed.run_type)
            {
                case RunType.Practice:
                    {
                        titleDetail = feed.run_name;
                        break;
                    }
                case RunType.Qualifying:
                    {
                        titleDetail = feed.run_name;
                        break;
                    }
                case RunType.Race:
                    {
                        titleDetail = $"{feed.run_name} - Stage {feed.stage.stage_num }";
                        break;
                    }
            }

            return string.Format(titleTemplate, titleDetail);
        }

        protected virtual string FormatLapInfo(NascarFeed.Models.LiveFeed.RootObject feed)
        {
            switch ((RunType)feed.run_type)
            {
                case RunType.Practice:
                    {
                        return feed.run_name;
                    }
                case RunType.Qualifying:
                    {
                        return feed.run_name;
                    }
                case RunType.Race:
                    {
                        switch (feed.stage.stage_num)
                        {
                            case 1:
                                {
                                    return $"STAGE {feed.stage.stage_num} - {feed.lap_number} OF {feed.stage.laps_in_stage} ({feed.lap_number} OF {feed.laps_in_race})";
                                }
                            case 2:
                                {
                                    int stageStartLap = feed.stage.finish_at_lap - feed.stage.laps_in_stage;
                                    return $"STAGE {feed.stage.stage_num} - {feed.lap_number - stageStartLap} OF {feed.stage.laps_in_stage} ({feed.lap_number} OF {feed.laps_in_race})";
                                }
                            case 3:
                                {
                                    return $"{feed.lap_number} OF {feed.laps_in_race}";
                                }
                            default:
                                {
                                    return $"{feed.lap_number} OF {feed.laps_in_race}";
                                }
                        }
                    }
            }

            return feed.run_name;
        }

        protected virtual void ConfigurationUpdated(TSConfiguration configuration)
        {
            lblBattleGap.Text = Configuration.BattleGap.ToString();
            lblPitWindow.Text = Configuration.PitWindow.ToString();

            pollFeedTimer.Interval = _configuration.PollInterval * 1000;
        }

        protected virtual void EventSettingsUpdated(EventSettings eventSettings)
        {
            if (eventSettings.activityId != (int)RunType.Race)
                Configuration.BattleGap = 0.0;
        }

        protected virtual void DisplayLeadersStatus(NascarFeed.Models.LiveFeed.RootObject feed)
        {
            tsLeaders1.Model = new SingleFieldModel() { Count = feed.number_of_leaders + 1, SubCount = feed.number_of_lead_changes };
        }

        protected virtual void DisplayCautionsStatus(
            IList<NascarFeed.Models.LiveFlagData.RootObject> liveFlagData,
            NascarFeed.Models.LiveFeed.RootObject feed)
        {
            var cautions = liveFlagData.Where(f => f.elapsed_time >= 0 && f.flag_state == 2);
            var cautionCount = cautions.Select(c => c.lap_number).Distinct().Count();
            tsCautionLapsDisplay1.Model = new SingleFieldModel() { Count = cautionCount, SubCount = feed.number_of_caution_laps };
        }

        protected virtual void SetFullscreenState(bool fullscreen)
        {
            if (fullscreen)
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

            _isFullscreen = fullscreen;
        }

        protected virtual bool GetLiveEventSettings()
        {
            var liveEventSettings = _apiClient.GetLiveEventSettings();

            if (liveEventSettings == null || liveEventSettings.eventId == -1)
            {
                MessageBox.Show(this, "No Live Event Right Now");
                return false;
            }

            Configuration.PitWindow = PitWindowCalculator.CalculatePitWindow(liveEventSettings.trackLength);

            EventSettings = liveEventSettings;

            ConfigurationUpdated(Configuration);

            return true;
        }

        #endregion

        #region private

        private void TimingAndScoring_Load(object sender, EventArgs e)
        {
            _apiClient = ServiceProvider.Instance.GetRequiredService<IApiClient>();

            if (!GetLiveEventSettings())
            {
                EventSettings = new EventSettings()
                {
                    season = 2019,
                    seriesId = 1,
                    sessionId = 3,
                    activityId = 3,
                    eventId = 4780
                };
            }
            else
            {
                pollFeedTimer.Enabled = true;
            }
        }

        private void pollFeed_Tick(object sender, EventArgs e)
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

        private void TimingAndScoring_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
                SetFullscreenState(!_isFullscreen);
        }

        private void autoRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pollFeedTimer.Enabled = autoRefreshToolStripMenuItem.Checked;
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

        private void getLiveEventSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GetLiveEventSettings();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        #endregion
    }
}

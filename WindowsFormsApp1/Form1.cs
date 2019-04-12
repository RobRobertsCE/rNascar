using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using NascarFeed.Models;
using NascarFeed.Ports;
using rNascarTimingAndScoring.Dialogs;
using rNascarTimingAndScoring.ViewModels;

namespace rNascarTimingAndScoring
{
    public partial class Form1 : Form
    {
        private EventSettings _eventSettings;
        public EventSettings EventSettings
        {
            get
            {
                if (_eventSettings == null)
                    _eventSettings = new EventSettings();

                return _eventSettings;
            }
            set
            {
                _eventSettings = value;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var api = ServiceProvider.Instance.GetRequiredService<IApiClient>();

                var feed = api.GetLiveFeed(EventSettings);

                dataGridView1.DataSource = feed.vehicles;

                txtRaw.Text = "Showing vehicles only from live feed";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var api = ServiceProvider.Instance.GetRequiredService<IApiClient>();

            var feed = api.GetRawJson(txtUrl.Text);

            txtRaw.Text = feed;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var api = ServiceProvider.Instance.GetRequiredService<IApiClient>();

                var feed = api.GetLapAverages(EventSettings);

                dataGridView1.DataSource = feed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var dialog = new EventSettingsDialog() { EventSettings = this.EventSettings };

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    this.EventSettings = dialog.EventSettings;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                var api = ServiceProvider.Instance.GetRequiredService<IApiClient>();

                var feed = api.GetEntryList(EventSettings);

                dataGridView1.DataSource = feed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                var api = ServiceProvider.Instance.GetRequiredService<IApiClient>();

                var feed = api.GetRaceResults(EventSettings);

                dataGridView1.DataSource = feed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                var timingAndScoring = new TimingAndScoring()
                {
                    EventSettings = this.EventSettings
                };

                timingAndScoring.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        IRaceViewModel viewModel;
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (EventSettings == null || EventSettings.eventId == 0)
                    EventSettings = new EventSettings()
                    {
                        season = 2019,
                        seriesId = 1,
                        sessionId = 3,
                        activityId = 3,
                        eventId = 4780
                    };

                viewModel = ServiceProvider.Instance.GetRequiredService<IRaceViewModel>();
                viewModel.EventSettings = EventSettings;

                tsLapLeaderGrid1.Models = viewModel.LapLeaderModels;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                viewModel.UpdateFeedData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

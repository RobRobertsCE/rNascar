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
using NascarApi.Mock.Internal;
using NascarApi.Mock.Models;
using NascarApi.Mock.Ports;

namespace NascarApi.Mock.TestApp
{
    public partial class Form1 : Form
    {
        private IEventGenerator _eventGenerator;
        private IRaceSimulator _rSimulator;
        private IQualifyingSimulator _qSimulator;
        private IPracticeSimulator _pSimulator;
        private NascarEvent _nascarEvent;

        public Form1()
        {
            InitializeComponent();

            _eventGenerator = ServiceProvider.Instance.GetRequiredService<IEventGenerator>();
            _pSimulator = ServiceProvider.Instance.GetRequiredService<IPracticeSimulator>();
            _qSimulator = ServiceProvider.Instance.GetRequiredService<IQualifyingSimulator>();
            _rSimulator = ServiceProvider.Instance.GetRequiredService<IRaceSimulator>();
        }

        private void ExceptionHandler(Exception ex)
        {
            Console.WriteLine(ex);
            MessageBox.Show(ex.Message);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var trackRepo = ServiceProvider.Instance.GetRequiredService<ITrackRepository>();
                NascarTrack track = await trackRepo.GetAsync(4);

                var seriesRepo = ServiceProvider.Instance.GetRequiredService<ISeriesRepository>();
                NascarSeries series = await seriesRepo.GetAsync(1);

                _nascarEvent = await _eventGenerator.GenerateEventAsync(track, series);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (_nascarEvent == null)
                {
                    var trackRepo = ServiceProvider.Instance.GetRequiredService<ITrackRepository>();
                    NascarTrack track = await trackRepo.GetAsync(4);

                    var seriesRepo = ServiceProvider.Instance.GetRequiredService<ISeriesRepository>();
                    NascarSeries series = await seriesRepo.GetAsync(1);

                    _nascarEvent = await _eventGenerator.GenerateEventAsync(track, series);
                }

                _nascarEvent = await _pSimulator.SimulatePracticeAsync(_nascarEvent);

                _nascarEvent = await _qSimulator.SimulateQualifyingAsync(_nascarEvent);

                _nascarEvent = await _rSimulator.SimulateRaceAsync(_nascarEvent);

            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        List<NascarRaceLap> laps = new List<NascarRaceLap>();
        VehicleLapService _lapService;
        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (_lapService == null)
                {
                    var trackRepo = ServiceProvider.Instance.GetRequiredService<ITrackRepository>();
                    NascarTrack track = await trackRepo.GetAsync(0);

                    var seriesRepo = ServiceProvider.Instance.GetRequiredService<ISeriesRepository>();
                    NascarSeries series = await seriesRepo.GetAsync(0);

                    _nascarEvent = await _eventGenerator.GenerateEventAsync(track, series);

                    _nascarEvent = await _pSimulator.SimulatePracticeAsync(_nascarEvent);

                    _nascarEvent = await _qSimulator.SimulateQualifyingAsync(_nascarEvent);

                    _lapService = new VehicleLapService(_nascarEvent);
                }

                laps = _lapService.GetStartingLineup(_nascarEvent, (NascarRaceRun)_nascarEvent.Runs.FirstOrDefault(r => r.RunType == NascarRunType.RaceStage1));
                
                //laps = await _lapService.UpdateRaceLapsAsync(laps, VehicleLapState.Test);

                //laps.Skip(5).FirstOrDefault().TotalTime += 70;
                //laps.Skip(6).FirstOrDefault().TotalTime += 90;
                //laps.Skip(7).FirstOrDefault().TotalTime += 133;

                laps = _lapService.UpdateRaceLaps(laps, VehicleLapState.OneToGreenFlag);
                laps = _lapService.UpdateRaceLaps(laps, VehicleLapState.GreenFlag);
                laps = _lapService.UpdateRaceLaps(laps, VehicleLapState.GreenFlag);
                laps =  _lapService.UpdateRaceLaps(laps, VehicleLapState.GreenFlag);
                laps = _lapService.UpdateRaceLaps(laps, VehicleLapState.GreenFlag);
                laps = _lapService.UpdateRaceLaps(laps, VehicleLapState.CautionFlag);
                laps = _lapService.UpdateRaceLaps(laps, VehicleLapState.CautionFlag);
                laps =  _lapService.UpdateRaceLaps(laps, VehicleLapState.CautionFlag);
                laps =  _lapService.UpdateRaceLaps(laps, VehicleLapState.OneToGreenFlag);
                laps =  _lapService.UpdateRaceLaps(laps, VehicleLapState.GreenFlag);
                laps =  _lapService.UpdateRaceLaps(laps, VehicleLapState.GreenFlag);
                laps =  _lapService.UpdateRaceLaps(laps, VehicleLapState.GreenFlag);
                laps =  _lapService.UpdateRaceLaps(laps, VehicleLapState.GreenFlag);
                laps =  _lapService.UpdateRaceLaps(laps, VehicleLapState.GreenFlag);
                laps =  _lapService.UpdateRaceLaps(laps, VehicleLapState.GreenFlag);
                laps =  _lapService.UpdateRaceLaps(laps, VehicleLapState.CautionFlag);
                laps =  _lapService.UpdateRaceLaps(laps, VehicleLapState.CautionFlag);
                laps =  _lapService.UpdateRaceLaps(laps, VehicleLapState.OneToGreenFlag);
                laps =  _lapService.UpdateRaceLaps(laps, VehicleLapState.GreenFlag);
                laps =  _lapService.UpdateRaceLaps(laps, VehicleLapState.GreenFlag);

            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using NascarApi.Simulation.Internal;
using NascarApi.Simulation.Models;
using NascarApi.Simulation.Ports;

namespace NascarApi.Simulation.TestApp
{
    public partial class TestForm : Form
    {
        #region fields

        private IEventGenerator _eventGenerator;
        private IRaceSimulator _rSimulator;
        private IQualifyingSimulator _qSimulator;
        private IPracticeSimulator _pSimulator;
        private ITrackRepository _trackRepository;
        private ISeriesRepository _seriesRepository;
        private VehicleLapService _lapService;

        private NascarEvent _nascarEvent;
        private List<NascarRaceLap> laps = new List<NascarRaceLap>();

        #endregion

        #region ctor

        public TestForm()
        {
            InitializeComponent();

            _eventGenerator = ServiceProvider.Instance.GetRequiredService<IEventGenerator>();
            _pSimulator = ServiceProvider.Instance.GetRequiredService<IPracticeSimulator>();
            _qSimulator = ServiceProvider.Instance.GetRequiredService<IQualifyingSimulator>();
            _rSimulator = ServiceProvider.Instance.GetRequiredService<IRaceSimulator>();

            _trackRepository = ServiceProvider.Instance.GetRequiredService<ITrackRepository>();
            _seriesRepository = ServiceProvider.Instance.GetRequiredService<ISeriesRepository>();
        }

        #endregion

        #region protected

        protected virtual async Task<NascarEvent> GenerateNewEvent(int trackId, int seriesId)
        {
            NascarTrack track = await _trackRepository.GetAsync(trackId);

            NascarSeries series = await _seriesRepository.GetAsync(1);

            return await _eventGenerator.GenerateEventAsync(track, series);
        }

        protected virtual List<NascarRaceLap> GenerateRaceLaps(double averageLapTime)
        {
            List<NascarRaceLap> newLaps = new List<NascarRaceLap>();

            newLaps.Add(new NascarRaceLap()
            {
                Position = 1,
                DriverId = 1,
                VehicleId = 1,
                TotalTime = 450,
                LapNumber = 10,
                LeaderLap = 10,
                LapsSincePit = 0,
                PitInLap = false,
                PitOutLap = false,
                IsLuckyDog = false
            });

            newLaps.Add(new NascarRaceLap()
            {
                Position = 2,
                DriverId = 2,
                VehicleId = 2,
                TotalTime = 451,
                LapNumber = 10,
                LeaderLap = 10,
                LapsSincePit = 0,
                PitInLap = false,
                PitOutLap = false,
                IsLuckyDog = false
            });

            newLaps.Add(new NascarRaceLap()
            {
                Position = 3,
                DriverId = 3,
                VehicleId = 3,
                TotalTime = 420,
                LapNumber = 9,
                LeaderLap = 10,
                LapsSincePit = 0,
                PitInLap = false,
                PitOutLap = false,
                IsLuckyDog = false
            });

            newLaps.Add(new NascarRaceLap()
            {
                Position = 4,
                DriverId = 4,
                VehicleId = 4,
                TotalTime = 425,
                LapNumber = 8,
                LeaderLap = 10,
                LapsSincePit = 0,
                PitInLap = false,
                PitOutLap = false,
                IsLuckyDog = false
            });

            return newLaps;
        }

        #endregion

        #region private

        private void ExceptionHandler(Exception ex)
        {
            Console.WriteLine(ex);
            MessageBox.Show(ex.Message);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _nascarEvent = await GenerateNewEvent(4, (int)SeriesType.MonsterEnergyCup);
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
                    _nascarEvent = await GenerateNewEvent(4, (int)SeriesType.MonsterEnergyCup);
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

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (_lapService == null)
                {
                    _nascarEvent = await GenerateNewEvent(0, 0);

                    _nascarEvent = await _pSimulator.SimulatePracticeAsync(_nascarEvent);

                    _nascarEvent = await _qSimulator.SimulateQualifyingAsync(_nascarEvent);

                    _lapService = new VehicleLapService(_nascarEvent.Track);
                }

                laps = _lapService.GetStartingLineup(_nascarEvent);

                laps = _lapService.UpdateRaceLaps(laps, LapState.OneToGreenFlag);
                laps = _lapService.UpdateRaceLaps(laps, LapState.GreenFlag);
                laps = _lapService.UpdateRaceLaps(laps, LapState.GreenFlag);
                laps = _lapService.UpdateRaceLaps(laps, LapState.GreenFlag);
                laps = _lapService.UpdateRaceLaps(laps, LapState.GreenFlag);
                laps = _lapService.UpdateRaceLaps(laps, LapState.CautionFlag);
                laps = _lapService.UpdateRaceLaps(laps, LapState.CautionFlag);
                laps = _lapService.UpdateRaceLaps(laps, LapState.CautionFlag);
                laps = _lapService.UpdateRaceLaps(laps, LapState.OneToGreenFlag);
                laps = _lapService.UpdateRaceLaps(laps, LapState.GreenFlag);
                laps = _lapService.UpdateRaceLaps(laps, LapState.GreenFlag);
                laps = _lapService.UpdateRaceLaps(laps, LapState.GreenFlag);
                laps = _lapService.UpdateRaceLaps(laps, LapState.GreenFlag);
                laps = _lapService.UpdateRaceLaps(laps, LapState.GreenFlag);
                laps = _lapService.UpdateRaceLaps(laps, LapState.GreenFlag);
                laps = _lapService.UpdateRaceLaps(laps, LapState.CautionFlag);
                laps = _lapService.UpdateRaceLaps(laps, LapState.CautionFlag);
                laps = _lapService.UpdateRaceLaps(laps, LapState.OneToGreenFlag);
                laps = _lapService.UpdateRaceLaps(laps, LapState.GreenFlag);
                laps = _lapService.UpdateRaceLaps(laps, LapState.GreenFlag);

            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            try
            {
                double trackLength = 2.66;
                double cautionLapTime = 136.8;
                double raceLapTime = 46.00;
                double pitInTime = 12.5;
                double pitOutTime = 12.5;
                double pitStopTime = 15.0;
                int talladegaTrackId = 5;
                int testSeriesId = 0;

                _nascarEvent = await GenerateNewEvent(talladegaTrackId, testSeriesId);

                _lapService = new VehicleLapService(_nascarEvent.Track);

                _lapService.LapTimeService = new TestLapTimeService(
                    trackLength,
                    cautionLapTime,
                    raceLapTime,
                    pitInTime,
                    pitOutTime,
                    pitStopTime);

                var run = _nascarEvent.Runs.OfType<NascarRaceRun>().FirstOrDefault(r => r.RunType == NascarRunType.RaceStage1);

                laps = GenerateRaceLaps(raceLapTime);

                ((List<NascarRaceLap>)run.Laps).AddRange(laps);

                laps = _lapService.UpdateRaceLaps(laps, LapState.OneToGreenFlag);
                laps = _lapService.UpdateRaceLaps(laps, LapState.GreenFlag);
                laps.Where(l => l.VehicleId == 2).FirstOrDefault().PitInLap = true;
                laps = _lapService.UpdateRaceLaps(laps, LapState.GreenFlag);
                laps = _lapService.UpdateRaceLaps(laps, LapState.GreenFlag);
                laps.Where(l => l.VehicleId == 1).FirstOrDefault().PitInLap = true;
                laps.Where(l => l.VehicleId == 3).FirstOrDefault().PitInLap = true;
                laps = _lapService.UpdateRaceLaps(laps, LapState.GreenFlag);
                laps = _lapService.UpdateRaceLaps(laps, LapState.GreenFlag);
                laps = _lapService.UpdateRaceLaps(laps, LapState.GreenFlag);
                //laps = _lapService.UpdateRaceLaps(laps, LapState.CautionFlag);
                //laps = _lapService.UpdateRaceLaps(laps, LapState.CautionFlag);
                //laps = _lapService.UpdateRaceLaps(laps, LapState.CautionFlag);
                //laps = _lapService.UpdateRaceLaps(laps, LapState.CautionFlag);
                //laps = _lapService.UpdateRaceLaps(laps, LapState.OneToGreenFlag);
                //laps = _lapService.UpdateRaceLaps(laps, LapState.GreenFlag);
                //laps = _lapService.UpdateRaceLaps(laps, LapState.GreenFlag);

            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        #endregion
    }
}

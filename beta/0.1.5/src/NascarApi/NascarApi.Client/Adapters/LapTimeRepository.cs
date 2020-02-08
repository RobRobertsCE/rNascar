using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NascarApi.Client.Models;
using NascarApi.Client.Ports;
using Newtonsoft.Json;

namespace NascarApi.Client.Adapters
{
    class LapTimeRepository : ILapTimeRepository
    {
        #region fields

        private IList<LapTimeModel> _lapTimeModels;
        private IList<LapAverageModel> _lapAverageModels;

        #endregion

        #region ctor

        public LapTimeRepository()
        {
            _lapTimeModels = new List<LapTimeModel>();
            _lapAverageModels = new List<LapAverageModel>();

            _lapTimeModels.Add(new LapTimeModel()
            {
                LapNumber = 1,
                CarNumber = "1",
                Driver = $"Driver1",
                EventId = "1",
                LapSpeed = 1.0,
                LapTime = 1.7
            });
            _lapTimeModels.Add(new LapTimeModel()
            {
                LapNumber = 2,
                CarNumber = "1",
                Driver = $"Driver1",
                EventId = "1",
                LapSpeed = 1.0,
                LapTime = 1.8
            });
            _lapTimeModels.Add(new LapTimeModel()
            {
                LapNumber = 3,
                CarNumber = "1",
                Driver = $"Driver1",
                EventId = "1",
                LapSpeed = 1.0,
                LapTime = 1.7
            });
            _lapTimeModels.Add(new LapTimeModel()
            {
                LapNumber = 4,
                CarNumber = "1",
                Driver = $"Driver1",
                EventId = "1",
                LapSpeed = 1.0,
                LapTime = 1.3
            });
            _lapTimeModels.Add(new LapTimeModel()
            {
                LapNumber = 5,
                CarNumber = "1",
                Driver = $"Driver1",
                EventId = "1",
                LapSpeed = 1.0,
                LapTime = 1.2
            });
            _lapTimeModels.Add(new LapTimeModel()
            {
                LapNumber = 6,
                CarNumber = "1",
                Driver = $"Driver1",
                EventId = "1",
                LapSpeed = 1.0,
                LapTime = 1.2
            });
            _lapTimeModels.Add(new LapTimeModel()
            {
                LapNumber = 7,
                CarNumber = "1",
                Driver = $"Driver1",
                EventId = "1",
                LapSpeed = 1.0,
                LapTime = 1.8
            });
            _lapTimeModels.Add(new LapTimeModel()
            {
                LapNumber = 8,
                CarNumber = "1",
                Driver = $"Driver1",
                EventId = "1",
                LapSpeed = 1.0,
                LapTime = 1.8
            });
            _lapTimeModels.Add(new LapTimeModel()
            {
                LapNumber = 9,
                CarNumber = "1",
                Driver = $"Driver1",
                EventId = "1",
                LapSpeed = 1.0,
                LapTime = 1.7
            });
            _lapTimeModels.Add(new LapTimeModel()
            {
                LapNumber = 10,
                CarNumber = "1",
                Driver = $"Driver1",
                EventId = "1",
                LapSpeed = 1.0,
                LapTime = 1.8
            });
            _lapTimeModels.Add(new LapTimeModel()
            {
                LapNumber = 11,
                CarNumber = "1",
                Driver = $"Driver1",
                EventId = "1",
                LapSpeed = 1.0,
                LapTime = 2.2
            });
            _lapTimeModels.Add(new LapTimeModel()
            {
                LapNumber = 12,
                CarNumber = "1",
                Driver = $"Driver1",
                EventId = "1",
                LapSpeed = 1.0,
                LapTime = 2.1
            });

            for (int c = 3; c < 36; c++)
            {
                for (int i = 0; i < 5; i++)
                {
                    _lapTimeModels.Add(new LapTimeModel()
                    {
                        LapNumber = i,
                        CarNumber = c.ToString(),
                        Driver = $"Driver{c}",
                        EventId = "1",
                        LapSpeed = 1.0,
                        LapTime = 1.0
                    });
                }
                for (int i = 6; i < 13; i++)
                {
                    _lapTimeModels.Add(new LapTimeModel()
                    {
                        LapNumber = i,
                        CarNumber = c.ToString(),
                        Driver = $"Driver{c}",
                        EventId = "1",
                        LapSpeed = 1.0,
                        LapTime = 1.0
                    });
                }

                for (int i = 16; i < 36; i++)
                {
                    _lapTimeModels.Add(new LapTimeModel()
                    {
                        LapNumber = i,
                        CarNumber = c.ToString(),
                        Driver = $"Driver{c}",
                        EventId = "1",
                        LapSpeed = 1.0,
                        LapTime = 1.0
                    });
                }
            }
        }

        #endregion

        #region public

        public Task<LapTimeModel> GetAsync(string eventId, string carNumber, int lapNumber)
        {
            try
            {
                if (String.IsNullOrEmpty(eventId))
                    throw new ArgumentNullException(nameof(eventId));

                if (String.IsNullOrEmpty(carNumber))
                    throw new ArgumentNullException(nameof(carNumber));

                if (lapNumber < 0)
                    throw new ArgumentOutOfRangeException(nameof(lapNumber));

                LapTimeModel model = _lapTimeModels.FirstOrDefault(m =>
                    m.EventId == eventId &&
                    m.CarNumber == carNumber &&
                    m.LapNumber == lapNumber);

                return Task.FromResult(model);
            }
            catch (Exception ex)
            {
                return Task.FromException<LapTimeModel>(ex);
            }
        }

        public Task<IEnumerable<LapTimeModel>> GetListAsync(string eventId, string carNumber = null)
        {
            try
            {
                if (String.IsNullOrEmpty(eventId))
                {
                    throw new ArgumentNullException(nameof(eventId));
                }

                IEnumerable<LapTimeModel> models = _lapTimeModels.Where(m => m.EventId == eventId);

                if (!String.IsNullOrEmpty(carNumber))
                    models = _lapTimeModels.Where(m => m.CarNumber == carNumber);

                return Task.FromResult(models);
            }
            catch (Exception ex)
            {
                return Task.FromException<IEnumerable<LapTimeModel>>(ex);
            }
        }

        public async Task<bool> InsertAsync(LapTimeModel model)
        {
            try
            {
                if (IsValid(model))
                    _lapTimeModels.Add(model);

                var vehicleEventLaps = _lapTimeModels.Where(l =>
                    l.EventId == model.EventId &&
                    l.CarNumber == model.CarNumber &&
                    l.LapNumber >= model.LapNumber - 20);

                var sequential = vehicleEventLaps
                    .Zip(
                        vehicleEventLaps.Skip(1),
                        (a, b) => b.LapNumber - 1 == a.LapNumber ? a : null)
                        .Where(s => s != null)
                        .ToList();

                if (sequential.Count > 0)
                {
                    List<double> lapTimes = new List<double>();
                    List<double> lapSpeeds = new List<double>();
                    List<int> lapNumbers = new List<int>();

                    int sequentialLapCount = 0;
                    int previousLapNumber = sequential.FirstOrDefault().LapNumber;
                    foreach (LapTimeModel lapTime in sequential.Skip(1))
                    {
                        if (lapTime.LapNumber - 1 == previousLapNumber)
                        {
                            sequentialLapCount += 1;

                            lapTimes.Insert(0, lapTime.LapTime);
                            lapSpeeds.Insert(0, lapTime.LapSpeed);
                            lapNumbers.Insert(0, lapTime.LapNumber);

                            if (sequentialLapCount >= 5)
                            {
                                var lapCount = 5;
                                var avg = lapTimes.Take(lapCount).Average();

                                var existing = _lapAverageModels.FirstOrDefault(a =>
                                    a.EventId == model.EventId &&
                                    a.CarNumber == model.CarNumber &&
                                    a.LapCount == lapCount);

                                if (existing != null && existing.AverageTime > avg)
                                {
                                    _lapAverageModels.Remove(existing);
                                }
                                else if (existing == null)
                                {
                                    _lapAverageModels.Add(new LapAverageModel()
                                    {
                                        LapCount = lapCount,
                                        EndLap = lapNumbers.FirstOrDefault(),
                                        StartLap = lapNumbers.Skip(lapCount - 1).FirstOrDefault(),
                                        AverageTime = avg,
                                        AverageSpeed = lapSpeeds.Take(lapCount).Average(),
                                        EventId = model.EventId,
                                        CarNumber = model.CarNumber,
                                        Driver = model.Driver
                                    });
                                }
                            }
                            if (sequentialLapCount >= 10)
                            {
                                var lapCount = 10;
                                var avg = lapTimes.Take(lapCount).Average();
                                var existing = _lapAverageModels.FirstOrDefault(a =>
                                    a.EventId == model.EventId &&
                                    a.CarNumber == model.CarNumber &&
                                    a.LapCount == lapCount);
                                if (existing != null && existing.AverageTime > avg)
                                {
                                    _lapAverageModels.Remove(existing);
                                }
                                else if (existing == null)
                                {
                                    _lapAverageModels.Add(new LapAverageModel()
                                    {
                                        LapCount = lapCount,
                                        EndLap = lapNumbers.FirstOrDefault(),
                                        StartLap = lapNumbers.Skip(lapCount - 1).FirstOrDefault(),
                                        AverageTime = avg,
                                        AverageSpeed = lapSpeeds.Take(lapCount).Average(),
                                        EventId = model.EventId,
                                        CarNumber = model.CarNumber,
                                        Driver = model.Driver
                                    });
                                }
                            }
                            if (sequentialLapCount >= 20)
                            {
                                var lapCount = 20;
                                var avg = lapTimes.Take(lapCount).Average();
                                var existing = _lapAverageModels.FirstOrDefault(a =>
                                    a.EventId == model.EventId &&
                                    a.CarNumber == model.CarNumber &&
                                    a.LapCount == lapCount);
                                if (existing != null && existing.AverageTime > avg)
                                {
                                    _lapAverageModels.Remove(existing);
                                }
                                else if (existing == null)
                                {
                                    _lapAverageModels.Add(new LapAverageModel()
                                    {
                                        LapCount = lapCount,
                                        EndLap = lapNumbers.FirstOrDefault(),
                                        StartLap = lapNumbers.Skip(lapCount - 1).FirstOrDefault(),
                                        AverageTime = avg,
                                        AverageSpeed = lapSpeeds.Take(lapCount).Average(),
                                        EventId = model.EventId,
                                        CarNumber = model.CarNumber,
                                        Driver = model.Driver
                                    });
                                }
                            }
                        }
                        else
                        {
                            sequentialLapCount = 0;
                            lapTimes.Clear();
                            lapSpeeds.Clear();
                            lapNumbers.Clear();
                        }


                        previousLapNumber = lapTime.LapNumber;
                    }

                }

                return true;
            }
            catch (Exception ex)
            {
                return await Task.FromException<bool>(ex);
            }
        }

        #endregion

        #region protected

        protected virtual bool IsValid(LapTimeModel model)
        {

            if (String.IsNullOrEmpty(model.EventId))
            {
                throw new ArgumentNullException(nameof(model.EventId));
            }
            if (String.IsNullOrEmpty(model.CarNumber))
            {
                throw new ArgumentNullException(nameof(model.CarNumber));
            }
            if (model.LapNumber < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(model.LapNumber));
            }
            if (_lapTimeModels.Any(m => m.EventId == model.EventId &&
                m.CarNumber == model.CarNumber &&
                m.LapNumber == model.LapNumber))
            {
                throw new InvalidOperationException("Duplicate entry");
            }

            return true;
        }

        protected virtual void SaveChanges()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                NullValueHandling = NullValueHandling.Include
            };

            var content = JsonConvert.SerializeObject(
                    this,
                    Formatting.Indented,
                    settings);

            File.WriteAllText(FileName, content);

        }

        protected string FileName
        {
            get
            {
                return @"C:\Users\Rob\source\repos\rNascar\rNascarTS\bin\Debug\lapTimes.json";
            }
        }

        #endregion
    }
}

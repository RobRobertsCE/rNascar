using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using rNascarTimingAndScoring.Models;

namespace rNascarTimingAndScoring.UnitTests.Models
{
    [TestClass]
    public class EventLapsAveragesTests
    {
        #region tests

        // Last 5 laps

        [TestMethod]
        public void EventLapAverages_Last5LapAverage_ReturnsCorrectValues()
        {
            // Arrange

            int expectedCount = 3;
            string expectedFirstCarNumber = "3";
            double expectedFirstLapAverage = 27.0;
            string expectedSecondCarNumber = "2";
            double expectedSecondLapAverage = 28.0;
            string expectedThirdCarNumber = "1";
            double expectedThirdLapAverage = 29.0;

            EventLapAverages averages = BuildTestEvent20LapAverages();

            // Act

            var lapAverages = averages.LastFiveLapAverages.ToList();

            // Assert

            Assert.AreEqual(expectedCount, lapAverages.Count);

            Assert.AreEqual(expectedFirstCarNumber, lapAverages[0].CarNumber);
            Assert.AreEqual(expectedFirstLapAverage, lapAverages[0].AverageLapTime);

            Assert.AreEqual(expectedSecondCarNumber, lapAverages[1].CarNumber);
            Assert.AreEqual(expectedSecondLapAverage, lapAverages[1].AverageLapTime);

            Assert.AreEqual(expectedThirdCarNumber, lapAverages[2].CarNumber);
            Assert.AreEqual(expectedThirdLapAverage, lapAverages[2].AverageLapTime);
        }

        [TestMethod]
        public void EventLapAverages_Last5LapAverage_1CarNotEnoughLaps_Returns2Cars()
        {
            // Arrange

            int expectedCount = 2;
            string expectedFirstCarNumber = "2";
            double expectedFirstLapAverage = 28.0;
            string expectedSecondCarNumber = "1";
            double expectedSecondLapAverage = 29.0;

            EventLapAverages averages = BuildTestEvent20And2LapAverages();

            // Act

            var lapAverages = averages.LastFiveLapAverages.ToList();

            // Assert

            Assert.AreEqual(expectedCount, lapAverages.Count);

            Assert.AreEqual(expectedFirstCarNumber, lapAverages[0].CarNumber);
            Assert.AreEqual(expectedFirstLapAverage, lapAverages[0].AverageLapTime);

            Assert.AreEqual(expectedSecondCarNumber, lapAverages[1].CarNumber);
            Assert.AreEqual(expectedSecondLapAverage, lapAverages[1].AverageLapTime);
        }

        [TestMethod]
        public void EventLapAverages_Last5LapAverage_AllCarsNotEnoughLaps_EmptyList()
        {
            // Arrange

            int expectedCount = 0;

            EventLapAverages averages = BuildTestEvent2LapAverages();

            // Act

            var lapAverages = averages.LastFiveLapAverages.ToList();

            // Assert

            Assert.AreEqual(expectedCount, lapAverages.Count);
        }

        // Best 5 laps

        [TestMethod]
        public void EventLapAverages_Best5LapAverage_ReturnsCorrectValues()
        {
            // Arrange

            int expectedCount = 3;
            string expectedFirstCarNumber = "3";
            double expectedFirstLapAverage = 7.0;
            string expectedSecondCarNumber = "2";
            double expectedSecondLapAverage = 8.0;
            string expectedThirdCarNumber = "1";
            double expectedThirdLapAverage = 9.0;

            EventLapAverages averages = BuildTestEvent20LapAverages();

            // Act

            var lapAverages = averages.BestFiveLapAverages.ToList();

            // Assert

            Assert.AreEqual(expectedCount, lapAverages.Count);

            Assert.AreEqual(expectedFirstCarNumber, lapAverages[0].CarNumber);
            Assert.AreEqual(expectedFirstLapAverage, lapAverages[0].AverageLapTime);

            Assert.AreEqual(expectedSecondCarNumber, lapAverages[1].CarNumber);
            Assert.AreEqual(expectedSecondLapAverage, lapAverages[1].AverageLapTime);

            Assert.AreEqual(expectedThirdCarNumber, lapAverages[2].CarNumber);
            Assert.AreEqual(expectedThirdLapAverage, lapAverages[2].AverageLapTime);
        }

        [TestMethod]
        public void EventLapAverages_Best5LapAverage_AllCarsNotEnoughLaps_EmptyList()
        {
            // Arrange

            int expectedCount = 0;

            EventLapAverages averages = BuildTestEvent2LapAverages();

            // Act

            var lapAverages = averages.BestFiveLapAverages.ToList();

            // Assert

            Assert.AreEqual(expectedCount, lapAverages.Count);
        }

        [TestMethod]
        public void EventLapAverages_Best5LapAverage_1CarNotEnoughLaps_Returns2Cars()
        {
            // Arrange

            int expectedCount = 2;
            string expectedFirstCarNumber = "2";
            double expectedFirstLapAverage = 8.0;
            string expectedSecondCarNumber = "1";
            double expectedSecondLapAverage = 9.0;

            EventLapAverages averages = BuildTestEvent20And2LapAverages();

            // Act

            var lapAverages = averages.BestFiveLapAverages.ToList();

            // Assert

            Assert.AreEqual(expectedCount, lapAverages.Count);

            Assert.AreEqual(expectedFirstCarNumber, lapAverages[0].CarNumber);
            Assert.AreEqual(expectedFirstLapAverage, lapAverages[0].AverageLapTime);

            Assert.AreEqual(expectedSecondCarNumber, lapAverages[1].CarNumber);
            Assert.AreEqual(expectedSecondLapAverage, lapAverages[1].AverageLapTime);

        }

        // Last 10 laps

        [TestMethod]
        public void EventLapAverages_Last10LapAverage_ReturnsCorrectValues()
        {
            // Arrange

            int expectedCount = 3;
            string expectedFirstCarNumber = "3";
            double expectedFirstLapAverage = 22.0;
            string expectedSecondCarNumber = "2";
            double expectedSecondLapAverage = 23.0;
            string expectedThirdCarNumber = "1";
            double expectedThirdLapAverage = 24.0;

            EventLapAverages averages = BuildTestEvent20LapAverages();

            // Act

            var lapAverages = averages.LastTenLapAverages.ToList();

            // Assert

            Assert.AreEqual(expectedCount, lapAverages.Count);

            Assert.AreEqual(expectedFirstCarNumber, lapAverages[0].CarNumber);
            Assert.AreEqual(expectedFirstLapAverage, lapAverages[0].AverageLapTime);

            Assert.AreEqual(expectedSecondCarNumber, lapAverages[1].CarNumber);
            Assert.AreEqual(expectedSecondLapAverage, lapAverages[1].AverageLapTime);

            Assert.AreEqual(expectedThirdCarNumber, lapAverages[2].CarNumber);
            Assert.AreEqual(expectedThirdLapAverage, lapAverages[2].AverageLapTime);
        }

        [TestMethod]
        public void EventLapAverages_Last10LapAverage_1CarNotEnoughLaps_Returns2Cars()
        {
            // Arrange

            int expectedCount = 2;
            string expectedFirstCarNumber = "2";
            double expectedFirstLapAverage = 23.0;
            string expectedSecondCarNumber = "1";
            double expectedSecondLapAverage = 24.0;

            EventLapAverages averages = BuildTestEvent20And2LapAverages();

            // Act

            var lapAverages = averages.LastTenLapAverages.ToList();

            // Assert

            Assert.AreEqual(expectedCount, lapAverages.Count);

            Assert.AreEqual(expectedFirstCarNumber, lapAverages[0].CarNumber);
            Assert.AreEqual(expectedFirstLapAverage, lapAverages[0].AverageLapTime);

            Assert.AreEqual(expectedSecondCarNumber, lapAverages[1].CarNumber);
            Assert.AreEqual(expectedSecondLapAverage, lapAverages[1].AverageLapTime);
        }

        [TestMethod]
        public void EventLapAverages_Last10LapAverage_AllCarsNotEnoughLaps_EmptyList()
        {
            // Arrange

            int expectedCount = 0;

            EventLapAverages averages = BuildTestEvent2LapAverages();

            // Act

            var lapAverages = averages.LastTenLapAverages.ToList();

            // Assert

            Assert.AreEqual(expectedCount, lapAverages.Count);
        }

        // Best 10 laps

        [TestMethod]
        public void EventLapAverages_Best10LapAverage_ReturnsCorrectValues()
        {
            // Arrange

            int expectedCount = 3;
            string expectedFirstCarNumber = "3";
            double expectedFirstLapAverage = 12.0;
            string expectedSecondCarNumber = "2";
            double expectedSecondLapAverage = 13.0;
            string expectedThirdCarNumber = "1";
            double expectedThirdLapAverage = 14.0;

            EventLapAverages averages = BuildTestEvent20LapAverages();

            // Act

            var lapAverages = averages.BestTenLapAverages.ToList();

            // Assert

            Assert.AreEqual(expectedCount, lapAverages.Count);

            Assert.AreEqual(expectedFirstCarNumber, lapAverages[0].CarNumber);
            Assert.AreEqual(expectedFirstLapAverage, lapAverages[0].AverageLapTime);

            Assert.AreEqual(expectedSecondCarNumber, lapAverages[1].CarNumber);
            Assert.AreEqual(expectedSecondLapAverage, lapAverages[1].AverageLapTime);

            Assert.AreEqual(expectedThirdCarNumber, lapAverages[2].CarNumber);
            Assert.AreEqual(expectedThirdLapAverage, lapAverages[2].AverageLapTime);
        }

        [TestMethod]
        public void EventLapAverages_Best10LapAverage_AllCarsNotEnoughLaps_EmptyList()
        {
            // Arrange

            int expectedCount = 0;

            EventLapAverages averages = BuildTestEvent2LapAverages();

            // Act

            var lapAverages = averages.BestTenLapAverages.ToList();

            // Assert

            Assert.AreEqual(expectedCount, lapAverages.Count);
        }

        [TestMethod]
        public void EventLapAverages_Best10LapAverage_1CarNotEnoughLaps_Returns2Cars()
        {
            // Arrange

            int expectedCount = 2;
            string expectedFirstCarNumber = "2";
            double expectedFirstLapAverage = 13.0;
            string expectedSecondCarNumber = "1";
            double expectedSecondLapAverage = 14.0;

            EventLapAverages averages = BuildTestEvent20And2LapAverages();

            // Act

            var lapAverages = averages.BestTenLapAverages.ToList();

            // Assert

            Assert.AreEqual(expectedCount, lapAverages.Count);

            Assert.AreEqual(expectedFirstCarNumber, lapAverages[0].CarNumber);
            Assert.AreEqual(expectedFirstLapAverage, lapAverages[0].AverageLapTime);

            Assert.AreEqual(expectedSecondCarNumber, lapAverages[1].CarNumber);
            Assert.AreEqual(expectedSecondLapAverage, lapAverages[1].AverageLapTime);

        }

        // Last 20 laps

        [TestMethod]
        public void EventLapAverages_Last20LapAverage_ReturnsCorrectValues()
        {
            // Arrange

            int expectedCount = 3;
            string expectedFirstCarNumber = "3";
            double expectedFirstLapAverage = 17.0;
            string expectedSecondCarNumber = "2";
            double expectedSecondLapAverage = 18.0;
            string expectedThirdCarNumber = "1";
            double expectedThirdLapAverage = 19.0;

            EventLapAverages averages = BuildTestEvent20LapAverages();

            // Act

            var lapAverages = averages.LastTwentyLapAverages.ToList();

            // Assert

            Assert.AreEqual(expectedCount, lapAverages.Count);

            Assert.AreEqual(expectedFirstCarNumber, lapAverages[0].CarNumber);
            Assert.AreEqual(expectedFirstLapAverage, lapAverages[0].AverageLapTime);

            Assert.AreEqual(expectedSecondCarNumber, lapAverages[1].CarNumber);
            Assert.AreEqual(expectedSecondLapAverage, lapAverages[1].AverageLapTime);

            Assert.AreEqual(expectedThirdCarNumber, lapAverages[2].CarNumber);
            Assert.AreEqual(expectedThirdLapAverage, lapAverages[2].AverageLapTime);
        }

        [TestMethod]
        public void EventLapAverages_Last20LapAverage_1CarNotEnoughLaps_Returns2Cars()
        {
            // Arrange

            int expectedCount = 2;
            string expectedFirstCarNumber = "2";
            double expectedFirstLapAverage = 18.0;
            string expectedSecondCarNumber = "1";
            double expectedSecondLapAverage = 19.0;

            EventLapAverages averages = BuildTestEvent20And2LapAverages();

            // Act

            var lapAverages = averages.LastTwentyLapAverages.ToList();

            // Assert

            Assert.AreEqual(expectedCount, lapAverages.Count);

            Assert.AreEqual(expectedFirstCarNumber, lapAverages[0].CarNumber);
            Assert.AreEqual(expectedFirstLapAverage, lapAverages[0].AverageLapTime);

            Assert.AreEqual(expectedSecondCarNumber, lapAverages[1].CarNumber);
            Assert.AreEqual(expectedSecondLapAverage, lapAverages[1].AverageLapTime);
        }

        [TestMethod]
        public void EventLapAverages_Last20LapAverage_AllCarsNotEnoughLaps_EmptyList()
        {
            // Arrange

            int expectedCount = 0;

            EventLapAverages averages = BuildTestEvent2LapAverages();

            // Act

            var lapAverages = averages.LastTwentyLapAverages.ToList();

            // Assert

            Assert.AreEqual(expectedCount, lapAverages.Count);
        }

        // Best 20 laps

        [TestMethod]
        public void EventLapAverages_Best20LapAverage_ReturnsCorrectValues()
        {
            // Arrange

            int expectedCount = 3;
            string expectedFirstCarNumber = "3";
            double expectedFirstLapAverage = 17.0;
            string expectedSecondCarNumber = "2";
            double expectedSecondLapAverage = 18.0;
            string expectedThirdCarNumber = "1";
            double expectedThirdLapAverage = 19.0;

            EventLapAverages averages = BuildTestEvent20LapAverages();

            // Act

            var lapAverages = averages.BestTwentyLapAverages.ToList();

            // Assert

            Assert.AreEqual(expectedCount, lapAverages.Count);

            Assert.AreEqual(expectedFirstCarNumber, lapAverages[0].CarNumber);
            Assert.AreEqual(expectedFirstLapAverage, lapAverages[0].AverageLapTime);

            Assert.AreEqual(expectedSecondCarNumber, lapAverages[1].CarNumber);
            Assert.AreEqual(expectedSecondLapAverage, lapAverages[1].AverageLapTime);

            Assert.AreEqual(expectedThirdCarNumber, lapAverages[2].CarNumber);
            Assert.AreEqual(expectedThirdLapAverage, lapAverages[2].AverageLapTime);
        }

        [TestMethod]
        public void EventLapAverages_Best20LapAverage_AllCarsNotEnoughLaps_EmptyList()
        {
            // Arrange

            int expectedCount = 0;

            EventLapAverages averages = BuildTestEvent2LapAverages();

            // Act

            var lapAverages = averages.BestTwentyLapAverages.ToList();

            // Assert

            Assert.AreEqual(expectedCount, lapAverages.Count);
        }

        [TestMethod]
        public void EventLapAverages_Best20LapAverage_1CarNotEnoughLaps_Returns2Cars()
        {
            // Arrange

            int expectedCount = 2;
            string expectedFirstCarNumber = "2";
            double expectedFirstLapAverage = 18.0;
            string expectedSecondCarNumber = "1";
            double expectedSecondLapAverage = 19.0;

            EventLapAverages averages = BuildTestEvent20And2LapAverages();

            // Act

            var lapAverages = averages.BestTwentyLapAverages.ToList();

            // Assert

            Assert.AreEqual(expectedCount, lapAverages.Count);

            Assert.AreEqual(expectedFirstCarNumber, lapAverages[0].CarNumber);
            Assert.AreEqual(expectedFirstLapAverage, lapAverages[0].AverageLapTime);

            Assert.AreEqual(expectedSecondCarNumber, lapAverages[1].CarNumber);
            Assert.AreEqual(expectedSecondLapAverage, lapAverages[1].AverageLapTime);

        }

        #endregion

        #region protected

        /// <summary>
        /// Creates records for 3 cars having 20 laps
        /// </summary>
        protected virtual EventLapAverages BuildTestEvent20LapAverages()
        {
            EventLapAverages averages = new EventLapAverages();

            int carCount = 3;
            int lapCount = 20;
            int slowLapCutoff1 = 5;
            int slowLapCutoff2 = 15;

            for (int carIndex = 1; carIndex < carCount + 1; carIndex++)
            {
                for (int lapIndex = 1; lapIndex < lapCount + 1; lapIndex++)
                {
                    double lapTime;

                    if (lapIndex > slowLapCutoff2)
                    {
                        lapTime = 30.0 - carIndex;
                    }
                    else if (lapIndex > slowLapCutoff1)
                    {
                        lapTime = 20.0 - carIndex;
                    }
                    else
                    {
                        lapTime = 10.0 - carIndex;
                    }

                    averages.AddLapTime(
                       new VehicleLapTime()
                       {
                           CarNumber = carIndex.ToString(),
                           TrackState = TrackState.Green,
                           VehicleStatus = VehicleStatus.OnTrack,
                           LapNumber = lapIndex,
                           LapTime = lapTime,
                           LapSpeed = 100 - lapTime
                       });
                }
            }

            return averages;
        }

        /// <summary>
        /// Creates records for 3 cars having 2 laps
        /// </summary>
        protected virtual EventLapAverages BuildTestEvent2LapAverages()
        {
            EventLapAverages averages = new EventLapAverages();

            int carCount = 3;
            int lapCount = 2;

            for (int carIndex = 1; carIndex < carCount + 1; carIndex++)
            {
                for (int lapIndex = 1; lapIndex < lapCount + 1; lapIndex++)
                {
                    double lapTime = 10.0 - carIndex;

                    averages.AddLapTime(
                       new VehicleLapTime()
                       {
                           CarNumber = carIndex.ToString(),
                           TrackState = TrackState.Green,
                           VehicleStatus = VehicleStatus.OnTrack,
                           LapNumber = lapIndex,
                           LapTime = lapTime,
                           LapSpeed = 100 - lapTime
                       });
                }
            }

            return averages;
        }

        /// <summary>
        /// Creates records for 2 cars having 20 laps and 1 car having 2 laps
        /// </summary>
        protected virtual EventLapAverages BuildTestEvent20And2LapAverages()
        {
            EventLapAverages averages = new EventLapAverages();

            int carCount = 3;
            int lapCount = 20;
            int slowLapCutoff1 = 5;
            int slowLapCutoff2 = 15;

            for (int carIndex = 1; carIndex < carCount + 1; carIndex++)
            {
                for (int lapIndex = 1; lapIndex < lapCount + 1; lapIndex++)
                {
                    if (carIndex < 3 || (carIndex >= 3 && lapIndex < 3))
                    {
                        double lapTime;

                        if (lapIndex > slowLapCutoff2)
                        {
                            lapTime = 30.0 - carIndex;
                        }
                        else if (lapIndex > slowLapCutoff1)
                        {
                            lapTime = 20.0 - carIndex;
                        }
                        else
                        {
                            lapTime = 10.0 - carIndex;
                        }

                        averages.AddLapTime(
                           new VehicleLapTime()
                           {
                               CarNumber = carIndex.ToString(),
                               TrackState = TrackState.Green,
                               VehicleStatus = VehicleStatus.OnTrack,
                               LapNumber = lapIndex,
                               LapTime = lapTime,
                               LapSpeed = 100 - lapTime
                           });
                    }
                }
            }

            return averages;
        }

        #endregion
    }
}
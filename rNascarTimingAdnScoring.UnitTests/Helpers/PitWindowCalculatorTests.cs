using Microsoft.VisualStudio.TestTools.UnitTesting;
using rNascarTimingAndScoring.Helpers;

namespace rNascarTimingAndScoring.UnitTests.Helpers
{
    [TestClass]
    public class PitWindowCalculatorTests
    {
        #region tests

        [TestMethod]
        public void PitWindowCalculator_ShortTrack_ReturnsCorrectWindow()
        {
            // Arrange

            double trackLength = 0.5;
            double expectedPitWindow = 115.00;

            // Act

            var calculatedPitWindow = PitWindowCalculator.CalculatePitWindow(trackLength);

            // Assert

            Assert.AreEqual(expectedPitWindow, calculatedPitWindow);
        }

        [TestMethod]
        public void PitWindowCalculator_ShortIntermediateTrack_ReturnsCorrectWindow()
        {
            // Arrange

            double trackLength = 1.366;
            double expectedPitWindow = 57.0;

            // Act

            var calculatedPitWindow = PitWindowCalculator.CalculatePitWindow(trackLength);

            // Assert

            Assert.AreEqual(expectedPitWindow, calculatedPitWindow);
        }

        [TestMethod]
        public void PitWindowCalculator_CookieCutterTrack_ReturnsCorrectWindow()
        {
            // Arrange

            double trackLength = 1.5;
            double expectedPitWindow = 40.0;

            // Act

            var calculatedPitWindow = PitWindowCalculator.CalculatePitWindow(trackLength);

            // Assert

            Assert.AreEqual(expectedPitWindow, calculatedPitWindow);
        }

        [TestMethod]
        public void PitWindowCalculator_Superspeedway_ReturnsCorrectWindow()
        {
            // Arrange

            double trackLength = 2.5;
            double expectedPitWindow = 22.0;

            // Act

            var calculatedPitWindow = PitWindowCalculator.CalculatePitWindow(trackLength);

            // Assert

            Assert.AreEqual(expectedPitWindow, calculatedPitWindow);
        }

        #endregion
    }
}

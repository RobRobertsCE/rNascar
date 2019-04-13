using System;

namespace rNascarTimingAndScoring.Helpers
{
    public static class PitWindowCalculator
    {
        private const double FuelCapacityGallons = 18.0;
        private const double OzPerGallon = 128.0;
        private const double FuelCapacityOz = FuelCapacityGallons * OzPerGallon;

        private const double OzPerLap_Louden = 29.4;
        private const double OzPerLap_Dover = 27.8;
        private const double OzPerLap_CookieCutter = 41.7;
        private const double OzPerLap_Talladega = 74.0;
        private const double OzPerLap_Martinsville = 14.6;
        private const double OzPerLap_Phoenix = 27.8;

        private const double MarginOfError = 0.9;

        public static int CalculatePitWindow(int trackId)
        {
            throw new NotImplementedException();
        }

        public static int CalculatePitWindow(double trackLength)
        {
            int pitWindowLaps;

            if (trackLength < 1.0)
            {
                pitWindowLaps = (int)(FuelCapacityOz / OzPerLap_Martinsville);
            }
            else if (trackLength < 1.4)
            {
                pitWindowLaps = (int)(FuelCapacityOz / OzPerLap_Louden);
            }
            else if (trackLength < 2.5)
            {
                pitWindowLaps = (int)(FuelCapacityOz / OzPerLap_CookieCutter);
            }
            else
            {
                pitWindowLaps = (int)(FuelCapacityOz / OzPerLap_Talladega);
            }

            pitWindowLaps = (int)(pitWindowLaps * MarginOfError);

            return pitWindowLaps;
        }
    }
}

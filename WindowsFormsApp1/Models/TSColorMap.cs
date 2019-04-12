using System.Drawing;

namespace rNascarTimingAndScoring.Models
{
    static class TSColorMap
    {
        public static Color PrimaryBackColor = Color.MidnightBlue;// Color.Navy;// Color.DarkBlue;

        public static Color FastestLapTimeForeColor = Color.SkyBlue;
        public static Color FastestLapNumberForeColor = Color.Gainsboro;
        public static Color LastLapForeColor = Color.Gold;

        public static Color StartPositionGainForeColor = Color.GreenYellow;
        public static Color StartPositionLossForeColor = Color.Red;
        public static Color StartPositionForeColor = Color.Gainsboro;


        public static Color DriverForeColor = Color.White;
        public static Color BehindForeColor = Color.White;
        public static Color BehindWithinBattleGapForeColor = Color.Red;
        public static Color DriverWithinBattleGapForeColor = Color.Red;

        public static Color NewFastestLapForeColor = Color.GreenYellow;


        public static Color LastPitForeColor = Color.Gainsboro;
        public static Color LastPitWarningForeColor = Color.GreenYellow;
        public static Color LastPitOverLimitForeColor = Color.Red;

        public static Color AlternatingRowBackColor0 = Color.MidnightBlue;// Color.DarkBlue; //Color.MediumBlue;
        public static Color AlternatingRowBackColor1 = PrimaryBackColor;
    }
}

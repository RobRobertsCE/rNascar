using System.Drawing;

namespace rNascarTimingAndScoring.Models
{
    static class TSColorMap
    {
        public static Color DefaultPrimaryBackColor = Color.MidnightBlue;
        public static Color DefaultAlternateBackColor = Color.DarkBlue;

        public static Color PrimaryBackColor = DefaultPrimaryBackColor;
        public static Color AlternateBackColor = DefaultAlternateBackColor;

        public static Color LastLapForeColor = Color.Gold;
        public static Color FastestLapTimeForeColor = Color.SkyBlue;
        public static Color FastestLapNumberForeColor = Color.Gainsboro;
        public static Color NewFastestLapForeColor = Color.GreenYellow;
        public static Color FastestThisLapForeColor = Color.GreenYellow;

        public static Color StartPositionGainForeColor = Color.GreenYellow;
        public static Color StartPositionLossForeColor = Color.Red;
        public static Color StartPositionForeColor = Color.Gainsboro;
        public static Color CarNumberForeColor = Color.Gainsboro;

        public static Color DriverForeColor = Color.White;
        public static Color FavoriteDriverForeColor = Color.Gold;
        public static Color DriverWithinBattleGapForeColor = Color.Red;

        public static Color BehindForeColor = Color.White;
        public static Color BehindWithinBattleGapForeColor = Color.Red;

        public static Color OutOfEventColor = Color.Gray;
        public static Color BehindTheWallColor = Color.Silver;

        public static Color IsInPitsBackColor = Color.Gold;
        public static Color IsInPitsForeColor = Color.Black;
        public static Color LastPitForeColor = Color.Gainsboro;
        public static Color LastPitWarningForeColor = Color.GreenYellow;
        public static Color LastPitOverLimitForeColor = Color.Red;

        public static Color AlternatingRowBackColor0 = AlternateBackColor;
        public static Color AlternatingRowBackColor1 = PrimaryBackColor;
    }
}

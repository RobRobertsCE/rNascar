namespace rNascarTimingAndScoring.Models
{
    public class TSConfiguration
    {
        public const double DefaultBattleGap = 0.2;

        public double BattleGap { get; set; } = DefaultBattleGap;
        public int PitWindowWarning { get; set; } = 5;
        public int PitWindow = 50;
        public int PollInterval { get; set; } = 5;
        public RunType RunType { get; set; }
    }
}

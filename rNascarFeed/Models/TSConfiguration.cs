namespace rNascarTimingAndScoring.Models
{
    public class TSConfiguration
    {
        public const double DefaultBattleGap = 0.2;
        public const int DefaultPitWindowWarning = 5;
        public const int DefaultPollInterval = 5;

        public double BattleGap { get; set; } = DefaultBattleGap;
        public int PitWindowWarning { get; set; } = DefaultPitWindowWarning;
        public int? PitWindow { get; set; }
        public int PollInterval { get; set; } = DefaultPollInterval;
        public RunType RunType { get; set; }
    }
}

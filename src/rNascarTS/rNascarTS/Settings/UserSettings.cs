using System.Collections.Generic;
using log4net.Core;

namespace rNascarTS.Settings
{
    public class UserSettings : SettingsBase
    {
        #region constants

        private const string UserSettingsFileName = "userSettings.json";

        #endregion

        #region properties

        // Feed Properties

        public double BattleGap { get; set; }
        public int PitWindowWarning { get; set; }
        public int PollInterval { get; set; }
        public List<string> FavoriteDrivers { get; set; } = new List<string>();

        // Behavior

        public bool CheckForLiveEventOnStartup { get; set; }
        private Level _logLevel = Level.Error;
        public Level LogLevel
        {
            get
            {
                return _logLevel;
            }
            set
            {
                if (value != null)
                    _logLevel = value;
            }
        }

        // UI

        public bool ShowToolBar { get; set; }
        public bool ShowStatusBar { get; set; }

        protected override string SettingsFileName => UserSettingsFileName;

        #endregion

        #region public

        #endregion

        #region public

        public static UserSettings Load()
        {
            var settings = new UserSettings();

            return settings.Load<UserSettings>();
        }

        #endregion

        #region protected

        protected override T GetDefaultSettings<T>()
        {
            var defaultSettings = new UserSettings()
            {
                BattleGap = 0,
                PitWindowWarning = 0,
                PollInterval = 5,
            } as T;

            return defaultSettings;
        }

        #endregion
    }
}

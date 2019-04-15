using System.Collections.Generic;

namespace rNascarTS.Settings
{
    public class AppSettings : SettingsBase
    {
        #region constants

        private const string AppSettingsFileName = "appSettings.json";

        #endregion

        #region properties

        public IList<ViewState> ViewStates { get; set; } = new List<ViewState>();
        public int GridRowCount { get; set; } = 4;
        public int GridColumnCount { get; set; } = 4;
        protected override string SettingsFileName => AppSettingsFileName;

        #endregion

        #region public

        public static AppSettings Load()
        {
            var settings = new AppSettings();

            return settings.Load<AppSettings>();
        }

        #endregion

        #region protected

        protected override T GetDefaultSettings<T>()
        {
            var defaultSettings = new AppSettings() as T;

            return defaultSettings;
        }

        #endregion
    }
}

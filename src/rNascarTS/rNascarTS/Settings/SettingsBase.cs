using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace rNascarTS.Settings
{
    public abstract class SettingsBase
    {
        #region properties

        protected abstract string SettingsFileName { get; }

        protected string SettingsDirectory
        {
            get
            {
                return $"{Path.GetDirectoryName(Application.ExecutablePath)}\\settings\\"; ;
            }
        }

        #endregion

        #region public

        public bool Save()
        {
            var filePath = GetSettingsFilePath();

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                NullValueHandling = NullValueHandling.Include
            };

            var content = JsonConvert.SerializeObject(
                    this,
                    Formatting.Indented,
                    settings);

            File.WriteAllText(filePath, content);

            return true;
        }

        public string GetSettingsFilePath()
        {
            if (!Directory.Exists(SettingsDirectory))
                Directory.CreateDirectory(SettingsDirectory);

            return Path.Combine(SettingsDirectory, SettingsFileName);
        }

        #endregion

        #region protected

        protected virtual T Load<T>() where T : SettingsBase
        {
            var filePath = GetSettingsFilePath();

            if (!File.Exists(filePath))
            {
                var defaultSettings = GetDefaultSettings<T>();

                defaultSettings.Save();

                return defaultSettings;
            }

            var settingsContent = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<T>(settingsContent);
        }

        protected abstract T GetDefaultSettings<T>() where T : SettingsBase;

        #endregion
    }
}

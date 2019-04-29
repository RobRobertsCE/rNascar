using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace rNascarTimingAndScoring.Models
{
    public class UserSettings
    {
        public int PrimaryBackgroundColorArgb { get; set; }
        public int SecondaryBackgroundColorArgb { get; set; }
        public double BattleGap { get; set; }
        public int? PitWindow { get; set; }
        public int PitWindowWarning { get; set; }
        public int PollInterval { get; set; }
        public List<FavoriteDriver> FavoriteDrivers { get; set; } = new List<FavoriteDriver>();
        public bool UseVerboseLogging { get; set; }

        public static UserSettings Load()
        {
            var filePath = GetSettingsFilePath();

            if (!File.Exists(filePath))
            {
                var newSettings = new UserSettings()
                {
                    PrimaryBackgroundColorArgb = TSColorMap.PrimaryBackColor.ToArgb(),
                    SecondaryBackgroundColorArgb = TSColorMap.AlternateBackColor.ToArgb(),
                    BattleGap = TSConfiguration.DefaultBattleGap,
                    PitWindowWarning = TSConfiguration.DefaultPitWindowWarning,
                    PollInterval = TSConfiguration.DefaultPollInterval,
                };

                newSettings.Save();

                return newSettings;
            }

            var settingsContent = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<UserSettings>(settingsContent);
        }

        public bool Save()
        {
            var filePath = GetAppDirectory();

            var settingsContent = JsonConvert.SerializeObject(
                this,
                Formatting.Indented,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include });

            File.WriteAllText(filePath, settingsContent);

            return true;
        }

        protected static string GetAppDirectory()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;

            return Path.GetDirectoryName(path);
        }
    }
}

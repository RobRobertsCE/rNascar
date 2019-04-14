using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace rNascarTimingAndScoring.Models
{
    public class UserSettings
    {
        public int PrimaryBackgroundColorArgb { get; set; }
        public int SecondaryBackgroundColorArgb { get; set; }

        public static UserSettings Load()
        {
            var filePath = GetSettingsFilePath();

            if (!File.Exists(filePath))
            {
                return new UserSettings()
                {
                    PrimaryBackgroundColorArgb = TSColorMap.PrimaryBackColor.ToArgb(),
                    SecondaryBackgroundColorArgb = TSColorMap.AlternateBackColor.ToArgb()
                };
            }

            var settingsContent = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<UserSettings>(settingsContent);
        }

        public bool Save()
        {
            var filePath = GetSettingsFilePath();

            var settings = new UserSettings()
            {
                PrimaryBackgroundColorArgb = TSColorMap.PrimaryBackColor.ToArgb(),
                SecondaryBackgroundColorArgb = TSColorMap.AlternateBackColor.ToArgb()
            };

            var settingsContent = JsonConvert.SerializeObject(settings);

            File.WriteAllText(filePath, settingsContent);

            return true;
        }

        protected static string GetSettingsFilePath()
        {
            return $"{System.IO.Path.GetDirectoryName(Application.ExecutablePath)}\\UserSettings.json";
        }
    }
}

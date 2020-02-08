using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace rNascarTS.Themes
{
    public static class UserThemeRepository
    {
        #region constants/statics

        private const string ThemeFileName = "userThemes.json";
        private const string ThemesDirectoryName = "themes";

        public static Guid DefaultThemeId = Guid.Parse("{154B3791-FA74-4EE9-A58C-EDB832E02124}");
        public static Guid EmptyThemeId = Guid.Parse("{C0678E3D-5BD4-42A6-80E4-2AAC19A071C8}");
        public static Guid MainThemeId = Guid.Parse("{4C71D84A-7A6A-46F1-A805-6495AEBB5459}");

        #endregion

        #region public

        public static void ExportThemes(IList<Theme> themes)
        {
            var themesDir = GetThemesDirectory();

            var fileName = Path.Combine(themesDir, "exportedThemes.json");

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                NullValueHandling = NullValueHandling.Include
            };

            var content = JsonConvert.SerializeObject(
                    themes,
                    Formatting.Indented,
                    settings);

            File.WriteAllText(fileName, content);
        }

        public static void SaveThemes(IList<Theme> themes)
        {
            var themesDir = GetThemesDirectory();

            var fileName = Path.Combine(themesDir, ThemeFileName);

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                NullValueHandling = NullValueHandling.Include
            };

            var content = JsonConvert.SerializeObject(
                    themes,
                    Formatting.Indented,
                    settings);

            File.WriteAllText(fileName, content);
        }

        public static IList<Theme> GetThemes()
        {
            IList<Theme> themes = null;

            var themesDir = GetThemesDirectory();

            var fileName = Path.Combine(themesDir, ThemeFileName);

            if (!File.Exists(fileName))
            {
                themes = new List<Theme>();

                themes.Add(UserThemeRepository.GetDefaultTheme());

                SaveThemes(themes);
            }

            var content = File.ReadAllText(fileName);

            themes = JsonConvert.DeserializeObject<IList<Theme>>(content);

            return themes;
        }
        public static Theme GetTheme(System.Guid id)
        {
            var userThemes = GetThemes();

            return userThemes.FirstOrDefault(t => t.Id == id);
        }

        public static Theme GetTheme(string name)
        {
            var userThemes = GetThemes();

            return userThemes.FirstOrDefault(t => t.Name.ToUpper() == name.ToUpper());
        }

        public static Theme GetThemeOrDefault(string name)
        {
            var userTheme = GetTheme(name);

            if (userTheme == null)
                userTheme = GetTheme("DEFAULT");

            return userTheme;
        }

        public static Theme GetThemeOrDefault(System.Guid id)
        {
            var userTheme = GetTheme(id);

            if (userTheme == null)
                userTheme = GetTheme("DEFAULT");

            return userTheme;
        }

        public static Theme GetEmptyTheme()
        {
            var control = Color.FromKnownColor(KnownColor.Control);
            var controlLight = Color.FromKnownColor(KnownColor.ControlLight);
            var controlDark = Color.FromKnownColor(KnownColor.ControlDark);
            var controlDarkDark = Color.FromKnownColor(KnownColor.ControlDarkDark);
            var controlText = Color.FromKnownColor(KnownColor.ControlText);

            return new Theme()
            {
                Name = "Empty",
                IsApplicationType = true,

                Id = EmptyThemeId,

                ViewBackColor = control,

                PrimaryForeColor = controlText,
                PrimaryBackColor = control,

                SecondaryForeColor = controlText,
                SecondaryBackColor = controlDark,

                HeaderForeColor = controlText,
                HeaderBackColor = control,

                GridColumnHeaderForeColor = controlText,
                GridColumnHeaderBackColor = control,

                HeaderFont = new Font(new FontFamily("Segoe UI"), 10, FontStyle.Bold),
                GridColumnHeaderFont = new Font(new FontFamily("Segoe UI"), 10, FontStyle.Regular),
                GridFont = new Font(new FontFamily("Segoe UI"), 10, FontStyle.Regular),

                BorderColor = Color.Red,
                BorderSize = 2
            };
        }

        public static Theme GetDefaultTheme()
        {
            return new Theme()
            {
                Name = "Default",
                IsApplicationType = true,

                Id = DefaultThemeId,

                ViewBackColor = Color.Black,

                PrimaryForeColor = Color.White,
                PrimaryBackColor = Color.DarkBlue,

                SecondaryForeColor = Color.White,
                SecondaryBackColor = Color.MidnightBlue,

                HeaderForeColor = Color.GhostWhite,
                HeaderBackColor = Color.MidnightBlue,

                GridColumnHeaderForeColor = Color.MidnightBlue,
                GridColumnHeaderBackColor = Color.White,

                HeaderFont = new Font(new FontFamily("Segoe UI"), 10, FontStyle.Bold),
                GridColumnHeaderFont = new Font(new FontFamily("Segoe UI"), 10, FontStyle.Regular),
                GridFont = new Font(new FontFamily("Segoe UI"), 10, FontStyle.Regular),

                BorderColor = Color.Red,
                BorderSize = 2
            };
        }

        public static Theme GetMainTheme()
        {
            var control = Color.FromKnownColor(KnownColor.Control);
            var controlLight = Color.FromKnownColor(KnownColor.ControlLight);
            var controlDark = Color.FromKnownColor(KnownColor.ControlDark);
            var controlDarkDark = Color.FromKnownColor(KnownColor.ControlDarkDark);
            var controlText = Color.FromKnownColor(KnownColor.ControlText);

            return new Theme()
            {
                Name = "[Main Form]",

                ViewType = Models.ViewType.Application,
                IsApplicationType=true,

                Id = MainThemeId,

                ViewBackColor = control,

                PrimaryForeColor = controlText,
                PrimaryBackColor = control,

                SecondaryForeColor = controlText,
                SecondaryBackColor = controlDark,

                HeaderForeColor = controlText,
                HeaderBackColor = control,

                GridColumnHeaderForeColor = controlText,
                GridColumnHeaderBackColor = control,

                HeaderFont = new Font(new FontFamily("Segoe UI"), 10, FontStyle.Bold),
                GridColumnHeaderFont = new Font(new FontFamily("Segoe UI"), 10, FontStyle.Regular),
                GridFont = new Font(new FontFamily("Segoe UI"), 10, FontStyle.Regular),

                BorderColor = Color.Red,
                BorderSize = 2
            };
        }

        #endregion

        #region private

        private static string GetThemesDirectory()
        {
            var themeDirectory = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\{ThemesDirectoryName}";

            if (!Directory.Exists(themeDirectory))
            {
                Directory.CreateDirectory(themeDirectory);
            }

            return themeDirectory;
        }

        #endregion
    }
}

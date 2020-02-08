using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using log4net;
using rNascarTS.Models;
using rNascarTS.Settings;
using rNascarTS.Themes;

namespace rNascarTS.Dialogs
{
    public partial class ThemeDesignerDialog : Form
    {
        #region events

        public event EventHandler<Theme> ThemeUpdated;
        protected virtual void OnThemeUpdated(Theme theme)
        {
            var handler = ThemeUpdated;

            if (handler != null)
            {
                handler.Invoke(this, theme);
            }
        }

        #endregion

        #region fields

        public Guid? ThemeId { get; set; }
        private ILog _log { get; set; }
        private Theme _selectedTheme;

        private IList<SampleView> _sampleViews = new List<SampleView>();
        private SampleView _currentSampleView = null;

        private IList<ThemeSection> _themeSections = new List<ThemeSection>();
        private ThemeSection _currentThemeSection = null;

        #endregion

        #region properties

        public IList<Theme> Themes { get; set; }
        public IList<ViewState> ViewStates { get; set; } = new List<ViewState>();

        private ColorDialog _colorDialog;
        protected ColorDialog ColorDialog
        {
            get
            {
                if (_colorDialog == null)
                {
                    _colorDialog = new ColorDialog()
                    {
                        AllowFullOpen = true,
                        AnyColor = true,
                        FullOpen = true,
                        SolidColorOnly = false
                    };
                }

                return _colorDialog;
            }
        }

        #endregion

        #region ctor/load

        public ThemeDesignerDialog()
        {
            InitializeComponent();
        }

        private void ThemeDesignerDialog_Load(object sender, EventArgs e)
        {
            _log = LogManager.GetLogger("Theme Designer");

            try
            {
                PopulateThemeList();

                LoadViewTypes();

                _sampleViews = GetSampleViews();

                if (ThemeId != null && ThemeId.Value != Guid.Empty)
                    lstThemes.SelectedValue = ThemeId.Value;
                else
                    lstThemes.SelectedIndex = 0;

                FilterViewTypeList(_selectedTheme.ViewType);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error loading theme designer", ex);
            }
        }

        #endregion

        protected virtual void LoadViewTypes()
        {
            cboViewType.DataSource = Enum.GetValues(typeof(ViewType));
            cboViewType.SelectedIndex = -1;
        }

        protected virtual void FilterViewTypeList(ViewType viewType)
        {
            cboViewType.DataSource = null;

            IList<ViewType> filteredViewTypes = new List<ViewType>();

            foreach (ViewType viewTypeItem in Enum.GetValues(typeof(ViewType)))
            {
                if (viewTypeItem != ViewType.All)
                {
                    if (viewType.HasFlag(viewTypeItem))
                        filteredViewTypes.Add(viewTypeItem);
                }
            }

            cboViewType.DataSource = filteredViewTypes;
            cboViewType.SelectedIndex = 0;
            cboViewType.Enabled = filteredViewTypes.Count > 1;
        }

        private void cboViewType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboViewType.SelectedItem == null)
                return;

            var selectedViewType = (ViewType)cboViewType.SelectedItem;

            _currentSampleView = _sampleViews.FirstOrDefault(v => v.ViewType == selectedViewType);

            DisplaySampleView(_currentSampleView);

            PopulateControlList(_currentSampleView);
        }

        protected virtual void PopulateControlList(SampleView sampleView)
        {
            try
            {
                lstThemeSections.DataSource = null;

                if (sampleView == null)
                    return;

                _themeSections = sampleView.GetThemeSections();

                lstThemeSections.DisplayMember = "Name";
                lstThemeSections.DataSource = _themeSections;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error populating control list", ex);
            }
        }

        private IList<SampleView> GetSampleViews()
        {
            var sampleViews = new List<SampleView>();

            sampleViews.Add(new SampleGridView());
            sampleViews.Add(new SampleLeaderboardView());
            sampleViews.Add(new SampleGraphView());
            sampleViews.Add(new SampleFormView());

            return sampleViews;
        }

        private void ClearSampleView()
        {
            if (pnlSample.Controls.Count > 0)
            {
                var sampleView = pnlSample.Controls[0];

                if (sampleView is SampleView)
                {
                    ((SampleView)sampleView).ControlSelected -= SampleView_ControlSelected;
                }

                pnlSample.Controls.Remove(sampleView);
            }
        }

        private void DisplaySampleView(SampleView sampleView)
        {
            ClearSampleView();

            if (sampleView == null)
                return;

            sampleView.ControlSelected += SampleView_ControlSelected;
            sampleView.Location = new Point((pnlSample.Width / 2) - (sampleView.Width / 2), 20);
            sampleView.BorderStyle = BorderStyle.FixedSingle;

            sampleView.ApplyTheme(_selectedTheme);

            pnlSample.Controls.Add(sampleView);
        }

        private void SampleView_ControlSelected(object sender, Control e)
        {
            try
            {
                ThemeSection selectedThemeSection = _themeSections.FirstOrDefault(c => c.Controls.Contains(e));
                if (selectedThemeSection != null)
                    lstThemeSections.SelectedItem = selectedThemeSection;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error selecting theme property from control", ex);
            }
        }

        protected virtual void DisplaySelectedThemeSection(ThemeSection themeSection)
        {
            try
            {
                lblControlName.Text = themeSection.Name;

                var controlFont = themeSection.Controls.FirstOrDefault().Font;
                lblControlFont.Text = $"Name: {controlFont.Name}  Size: {controlFont.Size}  Style: {controlFont.Style.ToString()}";

                Color foreColor = themeSection.Controls.FirstOrDefault().ForeColor;
                picForeColor.BackColor = foreColor;
                lblForeColor.Text = foreColor.ToString();

                Color backColor = themeSection.Controls.FirstOrDefault().BackColor;
                picBackColor.BackColor = backColor;
                lblBackColor.Text = backColor.ToString();

                foreach (var control in themeSection.Controls)
                {
                    if (control is Label)
                    {
                        ((Label)control).BorderStyle = BorderStyle.None;
                    }
                    else if (control is Panel)
                    {
                        ((Panel)control).BorderStyle = BorderStyle.Fixed3D;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error displaying selected control", ex);
            }
        }

        #region protected

        protected virtual void ExceptionHandler(string message, Exception ex)
        {
            if (_log != null)
                _log.Error(message, ex);
#if DEBUG
            Console.WriteLine(ex);
#endif
            MessageBox.Show($"{message}: {ex.Message}");
        }

        protected virtual void ReloadThemeList()
        {
            try
            {
                Themes = UserThemeRepository.GetThemes().Where(t=>t.IsApplicationType == false).ToList();
                PopulateThemeList();

                lstThemes.SelectedIndex = -1;
                lstThemes.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error loading theme list", ex);
            }
        }

        protected virtual void PopulateThemeList()
        {
            try
            {
                lstThemes.DataSource = null;
                lstThemes.ValueMember = "Id";
                lstThemes.DisplayMember = "Name";
                lstThemes.DataSource = Themes.Where(t => t.IsApplicationType == false).ToList();
                lstThemes.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error populating theme list", ex);
            }
        }

        protected virtual void NewTheme()
        {
            try
            {
                using (var dialog = new InputDialog(
                    "New Theme",
                    "Enter a name for the new theme",
                    "<New Theme>"))
                {
                    if (dialog.ShowDialog(this) != DialogResult.Cancel)
                    {
                        var theme = new Theme() { Id = Guid.NewGuid() };

                        theme.Name = dialog.Value;

                        Themes.Add(theme);

                        PopulateThemeList();

                        lstThemes.SelectedItem = theme;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error creating a new theme", ex);
            }
        }

        protected virtual void RenameTheme()
        {
            try
            {
                if (_selectedTheme.Name == "Default")
                {
                    MessageBox.Show("Can't rename the default theme");
                    return;
                }

                using (var dialog = new InputDialog(
                    "Rename Theme",
                    "Enter a new name for the theme",
                    _selectedTheme.Name))
                {
                    if (dialog.ShowDialog(this) != DialogResult.Cancel)
                    {
                        _selectedTheme.Name = dialog.Value;

                        PopulateThemeList();

                        lstThemes.SelectedItem = _selectedTheme;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error renaming theme", ex);
            }
        }

        protected virtual void CopyTheme()
        {
            try
            {
                using (var dialog = new InputDialog(
                   "Copy Theme",
                   "Enter a name for the new theme",
                   $"Copy of {_selectedTheme.Name}"))
                {
                    if (dialog.ShowDialog(this) != DialogResult.Cancel)
                    {
                        var theme = new Theme()
                        {
                            Name = dialog.Value,
                            Id = Guid.NewGuid()
                        };

                        _currentSampleView.UpdateTheme(theme);

                        Themes.Add(theme);

                        PopulateThemeList();

                        lstThemes.SelectedItem = theme;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error copying theme", ex);
            }
        }

        protected virtual void DeleteTheme()
        {
            try
            {
                if (_selectedTheme.Name == "Default")
                {
                    MessageBox.Show("Can't delete the default theme");
                    return;
                }

                Themes.Remove(_selectedTheme);

                PopulateThemeList();

                lstThemes.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error deleting theme", ex);
            }
        }

        protected virtual void ResetThemes()
        {
            try
            {
                var selectedThemeId = _selectedTheme.Id;

                ReloadThemeList();

                foreach (Theme theme in Themes)
                {
                    OnThemeUpdated(theme);
                }

                var originalSelection = Themes.FirstOrDefault(t => t.Id == selectedThemeId);

                if (originalSelection != null)
                    lstThemes.SelectedItem = originalSelection;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error resetting themes", ex);
            }
        }

        protected virtual Color SelectColor(Color originalColor)
        {
            ColorDialog.Color = originalColor;

            if (ColorDialog.ShowDialog(this) == DialogResult.OK)
            {
                return ColorDialog.Color;
            }

            return originalColor;
        }

        protected virtual void DisplayUsedBy(Theme theme)
        {
            try
            {
                lstUsedBy.DataSource = null;
                if (theme != null)
                {
                    if (theme.Id == UserThemeRepository.MainThemeId)
                    {
                        lstUsedBy.Items.Add("Application Forms");
                    }
                    else
                    {
                        lstUsedBy.DisplayMember = "Name";
                        lstUsedBy.DataSource = ViewStates.Where(v => v.ThemeId == theme.Id).ToList();
                    }
                }

                lstUsedBy.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error displaying UsedBy list", ex);
            }
        }

        protected virtual void ApplyApplicationTheme(Theme theme)
        {
            try
            {
                pnlSample.ForeColor = theme.ViewForeColor;
                pnlSample.BackColor = theme.ViewBackColor;
                pnlSample.Font = theme.ViewFont;

                lblThemes.ForeColor = theme.PrimaryForeColor;
                lblThemes.BackColor = theme.PrimaryBackColor;
                lblThemes.Font = theme.ViewFont;

                lstThemes.ForeColor = theme.SecondaryForeColor;
                lstThemes.BackColor = theme.SecondaryBackColor;
                lstThemes.Font = theme.ViewFont;

                lblUsedBy.ForeColor = theme.PrimaryForeColor;
                lblUsedBy.BackColor = theme.PrimaryBackColor;
                lblUsedBy.Font = theme.ViewFont;

                lstUsedBy.ForeColor = theme.SecondaryForeColor;
                lstUsedBy.BackColor = theme.SecondaryBackColor;
                lstUsedBy.Font = theme.ViewFont;

                pnlUsedBy.ForeColor = theme.SecondaryForeColor;
                pnlUsedBy.BackColor = theme.SecondaryBackColor;

                lblThemeProperties.ForeColor = theme.PrimaryForeColor;
                lblThemeProperties.BackColor = theme.PrimaryBackColor;
                lblThemeProperties.Font = theme.ViewFont;

                lstThemeSections.ForeColor = theme.SecondaryForeColor;
                lstThemeSections.BackColor = theme.SecondaryBackColor;
                lstThemeSections.Font = theme.ViewFont;

                pnlThemeSections.ForeColor = theme.SecondaryForeColor;
                pnlThemeSections.BackColor = theme.SecondaryBackColor;

                pnlThemeList.ForeColor = theme.SecondaryForeColor;
                pnlThemeList.BackColor = theme.SecondaryBackColor;

                lblControlName.ForeColor = theme.PrimaryForeColor;
                lblControlName.BackColor = theme.PrimaryBackColor;
                lblControlName.Font = theme.ViewFont;

                lblViewTypeHeader.ForeColor = theme.PrimaryForeColor;
                lblViewTypeHeader.BackColor = theme.PrimaryBackColor;
                lblViewTypeHeader.Font = theme.ViewFont;

                lblViewTypeSelection.ForeColor = theme.PrimaryForeColor;
                lblViewTypeSelection.BackColor = theme.PrimaryBackColor;
                lblViewTypeSelection.Font = theme.ViewFont;

                pnlControlProperties.ForeColor = theme.SecondaryForeColor;
                pnlControlProperties.BackColor = theme.SecondaryBackColor;
                pnlControlProperties.Font = theme.ViewFont;

                pnlLeft.ForeColor = theme.ViewForeColor;
                pnlLeft.BackColor = theme.ViewBackColor;
                pnlLeft.Font = theme.ViewFont;

                toolStrip1.ForeColor = theme.ViewForeColor;
                toolStrip1.BackColor = theme.ViewBackColor;
                toolStrip1.Font = theme.ViewFont;

                btnClose.ForeColor = theme.ViewForeColor;
                btnClose.BackColor = theme.ViewBackColor;
                btnClose.Font = theme.ViewFont;

                btnSave.ForeColor = theme.ViewForeColor;
                btnSave.BackColor = theme.ViewBackColor;
                btnSave.Font = theme.ViewFont;

                btnReset.ForeColor = theme.ViewForeColor;
                btnReset.BackColor = theme.ViewBackColor;
                btnReset.Font = theme.ViewFont;

                pnlDialogButtons.ForeColor = theme.SecondaryForeColor;
                pnlDialogButtons.BackColor = theme.SecondaryBackColor;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error applying application theme", ex);
            }
        }

        #endregion

        #region private

        private void lstThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_selectedTheme != null && _currentSampleView != null)
                    _currentSampleView.UpdateTheme(_selectedTheme);

                _selectedTheme = (Theme)lstThemes.SelectedItem;

                DisplayUsedBy(_selectedTheme);

                if (_selectedTheme == null)
                    return;

                FilterViewTypeList(_selectedTheme.ViewType);

                if (_currentSampleView != null)
                    _currentSampleView.ApplyTheme(_selectedTheme);

                if (_currentThemeSection != null)
                    DisplaySelectedThemeSection(_currentThemeSection);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error selecting theme", ex);
            }
        }

        private void lstControls_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstThemeSections.SelectedItem == null)
                    return;

                _currentThemeSection = (ThemeSection)lstThemeSections.SelectedItem;

                foreach (var sampleControl in _currentThemeSection.Controls)
                {
                    foreach (var control in sampleControl.Controls)
                    {
                        if (control is Label)
                        {
                            ((Label)control).BorderStyle = BorderStyle.Fixed3D;
                        }
                        else if (control is Panel)
                        {
                            ((Panel)control).BorderStyle = BorderStyle.FixedSingle;
                        }
                    }
                }

                DisplaySelectedThemeSection(_currentThemeSection);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error selecting theme property", ex);
            }
        }

        private void btnSetFont_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dialog = new FontDialog()
                {
                    Font = _currentThemeSection.Controls.FirstOrDefault().Font
                })
                {
                    if (dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        foreach (var control in _currentThemeSection.Controls)
                        {
                            control.Font = dialog.Font;
                        }
                    }
                }

                DisplaySelectedThemeSection(_currentThemeSection);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error setting font", ex);
            }
        }

        private void btnSetForeColor_Click(object sender, EventArgs e)
        {
            try
            {
                var originalColor = _currentThemeSection.Controls.FirstOrDefault().ForeColor;

                var selectedColor = SelectColor(originalColor);
                if (selectedColor != originalColor)
                {
                    foreach (var control in _currentThemeSection.Controls)
                    {
                        control.ForeColor = selectedColor;
                    }
                }

                DisplaySelectedThemeSection(_currentThemeSection);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error setting fore color", ex);
            }
        }

        private void btnBackColor_Click(object sender, EventArgs e)
        {
            try
            {
                var originalColor = _currentThemeSection.Controls.FirstOrDefault().BackColor;

                var selectedColor = SelectColor(originalColor);
                if (selectedColor != originalColor)
                {
                    foreach (var control in _currentThemeSection.Controls)
                    {
                        control.BackColor = selectedColor;
                    }
                }

                DisplaySelectedThemeSection(_currentThemeSection);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error setting back color", ex);
            }
        }

        private void btnNewTheme_Click(object sender, EventArgs e)
        {
            NewTheme();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            CopyTheme();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteTheme();
        }

        private void btnApplyChanges_Click(object sender, EventArgs e)
        {
            _currentSampleView.UpdateTheme(_selectedTheme);

            if (_selectedTheme.ViewType.HasFlag(ViewType.Application))
            {
                ApplyApplicationTheme(_selectedTheme);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyTheme();
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenameTheme();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteTheme();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTheme();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _currentSampleView.UpdateTheme(_selectedTheme);
            DialogResult = DialogResult.OK;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetThemes();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void lblHeader_FontChanged(object sender, EventArgs e)
        {
            try
            {
                Image image = new Bitmap(1, 1);
                Graphics graphics = Graphics.FromImage(image);
                SizeF labelTextSize = graphics.MeasureString(lblHeader.Text, lblHeader.Font);
                pnlHeader.Height = (int)labelTextSize.Height + 2;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error setting new font size", ex);
            }
        }

        private void btnExportThemes_Click(object sender, EventArgs e)
        {
            var currentThemes = UserThemeRepository.GetThemes();
            UserThemeRepository.ExportThemes(currentThemes);
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using log4net;
using rNascarTS.Controls;
using rNascarTS.Models;
using rNascarTS.Services;
using rNascarTS.Settings;
using rNascarTS.Themes;

namespace rNascarTS.Dialogs
{
    public partial class ViewDesignerDialog : Form
    {
        #region events

        public event EventHandler<ViewState> ViewStateUpdated;
        protected virtual void OnViewStateUpdated(ViewState viewState)
        {
            var handler = ViewStateUpdated;

            if (handler != null)
            {
                handler.Invoke(this, viewState);
            }
        }

        #endregion

        #region fields

        private ViewState _selectedViewState;
        private ViewListColumn _selectedColumn;
        private bool _loading = true;
        private Theme _blankTheme;
        private ILog _log { get; set; }

        #endregion

        #region properties
        public Guid? ViewStateId { get; set; }
        public IList<Theme> Themes { get; set; }
        public IList<ViewDataSource> DataSources { get; set; } = new List<ViewDataSource>();
        public IList<ViewState> ViewStates { get; set; } = new List<ViewState>();

        #endregion

        #region ctor/load

        public ViewDesignerDialog()
        {
            InitializeComponent();
        }

        private void ViewDesignerDialog_Load(object sender, EventArgs e)
        {
            _log = LogManager.GetLogger("View Designer");

            try
            {
                LoadContentAlignment();

                LoadThemes();

                LoadViewTypes();

                LoadSortTypes();

                DisplayDataSources(DataSources);

                DisplayViewStates(ViewStates);

                _loading = false;

                if (ViewStateId != null && ViewStateId.Value != Guid.Empty)
                    cboViews.SelectedValue = ViewStateId.Value;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error loading view designer", ex);
            }
        }
        #endregion

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

        #endregion

        #region private

        private void DiscardViewStateChanges()
        {
            this.ViewStates = AppSettings.Load().ViewStates;

            DisplayViewStates(ViewStates);
        }

        private void LoadContentAlignment()
        {
            cboAlignment.DataSource = Enum.GetValues(typeof(ContentAlignment));
        }

        private void LoadSortTypes()
        {
            cboSort.DataSource = Enum.GetValues(typeof(SortType));
        }

        private void LoadViewTypes()
        {
            cboViewType.DataSource = Enum.GetValues(typeof(ViewType));
        }

        private void ApplyTheme(Theme theme)
        {
            lblHeader.BackColor = theme.HeaderBackColor;
            lblHeader.ForeColor = theme.HeaderForeColor;
            lblHeader.Font = theme.HeaderFont;

            pnlGridHeader.BackColor = theme.GridColumnHeaderBackColor;
            pnlGridHeader.ForeColor = theme.GridColumnHeaderForeColor;
            pnlGridHeader.Font = theme.GridColumnHeaderFont;

            pnlRow.BackColor = theme.PrimaryBackColor;
            pnlRow.ForeColor = theme.PrimaryForeColor;

            pnlRow.Font = theme.GridFont;

            this.Invalidate();
        }

        private Theme BuildBlankTheme()
        {
            return new Theme()
            {
                Name = "Blank",

                Id = Guid.Empty,

                ViewBackColor = flowLayoutPanel1.BackColor,

                PrimaryForeColor = pnlRow.ForeColor,
                PrimaryBackColor = pnlRow.BackColor,

                SecondaryForeColor = pnlRow.BackColor,
                SecondaryBackColor = pnlRow.ForeColor,

                HeaderForeColor = lblHeader.ForeColor,
                HeaderBackColor = lblHeader.BackColor,

                GridColumnHeaderForeColor = pnlGridHeader.ForeColor,
                GridColumnHeaderBackColor = pnlGridHeader.BackColor,

                HeaderFont = lblHeader.Font,
                GridColumnHeaderFont = pnlGridHeader.Font,
                GridFont = pnlRow.Font,

                BorderColor = Color.Red,
                BorderSize = 2
            };
        }

        private void LoadThemes()
        {
            if (_blankTheme == null)
            {
                _blankTheme = BuildBlankTheme();
            }

            cboThemes.DataSource = null; ;
            cboThemes.ValueMember = "Id";
            cboThemes.DisplayMember = "Name";
            cboThemes.DataSource = Themes;
        }

        private void DisplayViewStates(IList<ViewState> viewStates)
        {
            cboViews.DataSource = null;
            cboViews.DisplayMember = "Name";
            cboViews.ValueMember = "Id";
            cboViews.DataSource = viewStates;
            cboViews.SelectedIndex = -1;
        }

        private void DisplayDataSources(IList<ViewDataSource> dataSources)
        {
            trvDataSources.Nodes.Clear();

            foreach (ViewDataSource dataSource in dataSources)
            {
                var dataSourceNode = new TreeNode(dataSource.Name)
                {
                    Tag = dataSource
                };

                BuildDataSourceTreeView(dataSourceNode, dataSource);

                trvDataSources.Nodes.Add(dataSourceNode);
            }

            trvDataSources.ExpandAll();
        }

        private void BuildDataSourceTreeView(TreeNode dataSourceNode, ViewDataSource dataSource)
        {
            foreach (ViewDataMember field in dataSource.Fields)
            {
                var fieldNode = new TreeNode(field.Name)
                {
                    Tag = field
                };

                dataSourceNode.Nodes.Add(fieldNode);
            }

            foreach (ViewDataSource dataList in dataSource.Lists)
            {
                var listNode = new TreeNode(dataList.Name + "[]")
                {
                    Tag = dataList
                };

                BuildDataSourceTreeView(listNode, dataList);

                dataSourceNode.Nodes.Add(listNode);
            }

            foreach (ViewDataSource dataList in dataSource.NestedClasses)
            {
                var listNode = new TreeNode(dataList.Name)
                {
                    Tag = dataList
                };

                BuildDataSourceTreeView(listNode, dataList);

                dataSourceNode.Nodes.Add(listNode);
            }
        }

        private void ClearViewStateDetails()
        {
            txtName.Clear();
            txtHeader.Clear();
            txtDescription.Clear();
            txtDataSource.Clear();
            txtMaxRows.Clear();
            txtRowHeight.Clear();

            cboThemes.SelectedIndex = -1;
            cboViewType.SelectedIndex = -1;

            chkShowHeader.Checked = false;
            chkShowGridHeader.Checked = false;
            chkShowView.Checked = false;
        }

        private void ClearColumnDetails()
        {
            btnCopyColumn.Enabled = false;
            btnNewColumn.Enabled = false;
            btnDeleteColumn.Enabled = false;
            btnMoveLeft.Enabled = false;
            btnMoveRight.Enabled = false;

            ClearChildControls(pnlGridHeader);
            ClearChildControls(pnlRow);

            txtCaption.Clear();
            txtDataField.Clear();
            txtWidth.Clear();
            txtFormat.Clear();
            txtIndex.Clear();
            txtDataPath.Clear();

            cboAlignment.SelectedIndex = -1;
            cboSort.SelectedIndex = -1;

            _selectedColumn = null;
        }

        private void ClearChildControls(Control parentControl)
        {
            IList<Control> controlsToRemove = new List<Control>();
            foreach (Control control in parentControl.Controls)
            {
                controlsToRemove.Add(control);
            }
            foreach (Control control in controlsToRemove)
            {
                parentControl.Controls.Remove(control);
            }
        }

        private void DisplayViewState(ViewState viewState)
        {
            ClearViewStateDetails();

            txtName.Text = viewState.Name;
            txtHeader.Text = viewState.HeaderText;
            txtDescription.Text = viewState.Description;
            txtDataSource.Text = viewState.ListSettings.DataSource;

            if (viewState.ListSettings.RowHeight.HasValue)
            {
                txtRowHeight.Text = viewState.ListSettings.RowHeight.Value.ToString();
                UpdateViewStateRowHeight();
            }
            else
            {
                txtRowHeight.Text = String.Empty;
                pnlGridHeader.Height = 28;
                pnlRow.Height = 28;
            }

            txtMaxRows.Text = viewState.ListSettings.MaxRows.HasValue ? viewState.ListSettings.MaxRows.Value.ToString() : String.Empty;

            chkShowHeader.Checked = viewState.ListSettings.ShowHeader;
            chkShowGridHeader.Checked = viewState.ListSettings.ShowColumnCaptions;
            chkShowView.Checked = viewState.IsDisplayed;

            cboThemes.SelectedValue = viewState.ThemeId;
            cboViewType.SelectedItem = viewState.ViewType;

            ReloadColumns();
        }

        private void DisplayViewStateColumns(ViewListSettings listSettings)
        {
            ColumnBuilderService.BuildGridColumns(listSettings, pnlGridHeader.Controls, pnlRow.Controls);

            foreach (Label label in pnlGridHeader.Controls.OfType<Label>())
            {
                label.DoubleClick += ColumnLabel_DoubleClick;
            }
            foreach (Label label in pnlRow.Controls.OfType<Label>())
            {
                label.DoubleClick += ColumnLabel_DoubleClick;
            }

            if (listSettings.Columns.Count > 0)
                SelectColumn(listSettings.OrderedColumns[0]);
        }

        //private void AlignControls(Control.ControlCollection controls, int? fillColumnIndex)
        //{
        //    if (fillColumnIndex.HasValue)
        //    {
        //        for (int i = 0; i < fillColumnIndex.Value; i++)
        //        {
        //            controls[i].Dock = DockStyle.Left;
        //        }

        //        for (int i = fillColumnIndex.Value + 1; i < controls.Count; i++)
        //        {
        //            controls[i].Dock = DockStyle.Right;
        //        }

        //        controls[fillColumnIndex.Value].Dock = DockStyle.Fill;
        //        controls[fillColumnIndex.Value].BringToFront();
        //    }
        //    else
        //    {
        //        for (int i = controls.Count - 1; i >= 0; i--)
        //        {
        //            if (i == 0)
        //            {
        //                controls[i].Dock = DockStyle.Left;
        //            }
        //            else
        //            {
        //                controls[i].Dock = DockStyle.Right;
        //                //controls[i].BringToFront();
        //            }

        //            controls[0].Dock = DockStyle.Fill;
        //            controls[0].BringToFront();
        //        }
        //    }
        //}

        //private Label BuildColumnLabel(ViewListColumn column, bool isHeader = false)
        //{
        //    var columnLabel = new Label()
        //    {
        //        //Text = column.Caption,
        //        Text = isHeader ?
        //            $"{column.Index.ToString()} {column.Caption}" :
        //            column.Index.ToString(),
        //        TextAlign = column.Alignment,
        //        AutoSize = false,
        //        BackColor = Color.FromKnownColor(KnownColor.Control),
        //        BorderStyle = BorderStyle.FixedSingle,
        //        Tag = column
        //    };

        //    columnLabel.DoubleClick += ColumnLabel_DoubleClick;

        //    if (column.Width.HasValue)
        //        columnLabel.Size = new Size(column.Width.Value, columnLabel.Height);

        //    return columnLabel;
        //}

        private void ColumnLabel_DoubleClick(object sender, EventArgs e)
        {
            var columnLabel = (Label)sender;
            var columnSettings = (ViewListColumn)columnLabel.Tag;

            SelectColumn(columnSettings);
        }

        private void SelectColumn(ViewListColumn columnSettings)
        {
            HighlightSelectedColumn(columnSettings);

            DisplayColumnDetails(columnSettings);
        }

        private void UpdateViewState(ViewState viewState)
        {
            viewState.HeaderText = txtHeader.Text.Trim();
            viewState.Name = txtName.Text.Trim();
            viewState.Description = txtDescription.Text.Trim();
            viewState.ListSettings.DataSource = txtDataSource.Text.Trim();

            int maxRows = 0;
            if (Int32.TryParse(txtMaxRows.Text, out maxRows))
                viewState.ListSettings.MaxRows = maxRows;
            else
                viewState.ListSettings.MaxRows = null;

            int rowHeight = 0;
            if (Int32.TryParse(txtRowHeight.Text, out rowHeight))
                viewState.ListSettings.RowHeight = rowHeight;
            else
                viewState.ListSettings.RowHeight = null;

            viewState.ListSettings.ShowHeader = chkShowHeader.Checked;
            viewState.ListSettings.ShowColumnCaptions = chkShowGridHeader.Checked;
            viewState.IsDisplayed = chkShowView.Checked;

            if (cboViewType.SelectedItem != null)
                viewState.ViewType = (ViewType)cboViewType.SelectedItem;

            if (cboThemes.SelectedItem != null)
                viewState.ThemeId = ((Theme)cboThemes.SelectedItem).Id;
        }

        private void DisplayColumnDetails(ViewListColumn column)
        {
            if (_selectedColumn != null)
            {
                UpdateColumnDetails(_selectedColumn);
            }

            _selectedColumn = column;

            txtCaption.Text = column.Caption;
            txtDataField.Text = column.DataMember;
            txtDataPath.Text = column.DataFullPath;
            txtWidth.Text = column.Width.HasValue ? column.Width.Value.ToString() : String.Empty;
            txtFormat.Text = column.Format;
            cboAlignment.SelectedItem = column.Alignment;
            txtIndex.Text = column.Index.ToString();
            cboSort.SelectedItem = column.SortType;

            btnCopyColumn.Enabled = true;
            btnNewColumn.Enabled = true;
            btnDeleteColumn.Enabled = true;
            btnMoveLeft.Enabled = true;
            btnMoveRight.Enabled = true;
        }

        private void UpdateColumnDetails(ViewListColumn column)
        {
            column.Caption = txtCaption.Text.Trim();
            column.DataMember = txtDataField.Text.Trim();
            column.DataFullPath = txtDataPath.Text.Trim();
            column.Format = txtFormat.Text.Trim();

            SortType sort;
            if (Enum.TryParse<SortType>(cboSort.SelectedValue.ToString(), out sort))
                column.SortType = sort;

            ContentAlignment alignment;
            if (Enum.TryParse<ContentAlignment>(cboAlignment.SelectedValue.ToString(), out alignment))
                column.Alignment = alignment;

            int width = 0;
            if (Int32.TryParse(txtWidth.Text, out width))
                column.Width = width;
            else
                column.Width = null;
        }

        private void SetEditMode()
        {
            cboViews.Enabled = false;
            pnlViewStateDisplay.Enabled = true;
            pnlColumnDetails.Enabled = true;
            pnlViewStateDetails.Enabled = true;

            btnNewView.Enabled = false;
            btnCopyView.Enabled = false;
            btnDeleteView.Enabled = false;
            btnEditSave.Text = "Save";
            btnEditSave.Enabled = true;
            btnCancelEdit.Enabled = true;

            btnNewColumn.Enabled = true;
            btnCopyColumn.Enabled = false;
            btnDeleteColumn.Enabled = false;
            btnMoveLeft.Enabled = false;
            btnMoveRight.Enabled = false;
        }

        private void CancelEditMode()
        {
            cboViews.Enabled = true;
            pnlViewStateDisplay.Enabled = true;
            pnlColumnDetails.Enabled = false;
            pnlViewStateDetails.Enabled = false;

            btnEditSave.Text = "Edit";
            btnEditSave.Enabled = true;
            btnCancelEdit.Enabled = false;
            btnNewView.Enabled = true;
            btnCopyView.Enabled = (cboViews.SelectedItem != null);
            btnDeleteView.Enabled = (cboViews.SelectedItem != null);

            btnNewColumn.Enabled = false;
            btnCopyColumn.Enabled = false;
            btnDeleteColumn.Enabled = false;
            btnMoveLeft.Enabled = false;
            btnMoveRight.Enabled = false;

            //int selectedIndex = cboViews.SelectedIndex;
            //cboViews.SelectedIndex = -1;
            //cboViews.SelectedIndex = selectedIndex;
        }

        private void SaveChanges()
        {
            UpdateViewState(_selectedViewState);

            var savedId = _selectedViewState.Id;

            if (_selectedColumn != null)
                UpdateColumnDetails(_selectedColumn);

            CancelEditMode();

            DisplayViewStates(this.ViewStates);

            cboViews.SelectedValue = savedId;
        }

        private void NewViewState()
        {
            using (var dialog = new InputDialog(
              "New View",
              "Enter a name for the new view",
              "<New View>"))
            {
                if (dialog.ShowDialog(this) != DialogResult.Cancel)
                {
                    var viewState = new ViewState() { ThemeId = UserThemeRepository.DefaultThemeId };

                    viewState.Name = dialog.Value;

                    ViewStates.Add(viewState);

                    DisplayViewStates(ViewStates);

                    cboViews.SelectedItem = viewState;

                    SetEditMode();
                }
            }
        }

        private void CopyViewState()
        {
            using (var dialog = new InputDialog(
              "Copy View",
              "Enter a name for the new view",
              $"Copy of {_selectedViewState.Name}"))
            {
                if (dialog.ShowDialog(this) != DialogResult.Cancel)
                {
                    var viewState = new ViewState()
                    {
                        Name = dialog.Value
                    };

                    UpdateViewState(viewState);

                    viewState.ListSettings.Columns = _selectedViewState.ListSettings.Columns.ToList();

                    ViewStates.Add(viewState);

                    DisplayViewStates(ViewStates);

                    cboViews.SelectedItem = viewState;

                    SetEditMode();
                }
            }
        }

        private void DeleteViewState()
        {
            ViewStates.Remove(_selectedViewState);

            DisplayViewStates(ViewStates);

            cboViews.SelectedIndex = 0;
        }

        private void NewColumn()
        {
            using (var dialog = new InputDialog(
             "New Column",
             "Enter a caption for the new column",
             "<New Column>"))
            {
                if (dialog.ShowDialog(this) != DialogResult.Cancel)
                {
                    ViewListColumn column = new ViewListColumn();

                    column.Caption = dialog.Value;

                    column.Index = _selectedViewState.ListSettings.Columns.Count;

                    _selectedViewState.ListSettings.Columns.Add(column);

                    ReloadColumns();
                }
            }

        }

        private void CopyColumn()
        {
            using (var dialog = new InputDialog(
            "Copy Column",
            "Enter a name for the new column",
            $"Copy of {_selectedColumn.Caption}"))
            {
                if (dialog.ShowDialog(this) != DialogResult.Cancel)
                {
                    ViewListColumn column = new ViewListColumn();

                    column.Caption = dialog.Value;

                    column.Index = _selectedViewState.ListSettings.Columns.Count;

                    UpdateColumnDetails(column);

                    _selectedViewState.ListSettings.Columns.Add(column);

                    ReloadColumns();
                }
            }
        }

        private void DeleteColumn()
        {
            _selectedViewState.ListSettings.Columns.Remove(_selectedColumn);

            ReloadColumns();
        }

        private void ReloadColumns()
        {
            ClearColumnDetails();

            DisplayViewStateColumns(_selectedViewState.ListSettings);
        }

        private void MoveColumnLeft()
        {
            if (_selectedColumn.Index == 0)
                return;

            var columnToMoveDown = _selectedViewState.ListSettings.Columns.FirstOrDefault(c => c.Index == _selectedColumn.Index);

            var columnToMoveUp = _selectedViewState.ListSettings.Columns.FirstOrDefault(c => c.Index == _selectedColumn.Index - 1);

            columnToMoveDown.Index -= 1;
            columnToMoveUp.Index += 1;

            ReloadColumns();
        }

        private void MoveColumnRight()
        {
            if (_selectedColumn.Index == _selectedViewState.ListSettings.Columns.Count - 1)
                return;

            var columnToMoveUp = _selectedViewState.ListSettings.Columns.FirstOrDefault(c => c.Index == _selectedColumn.Index);

            var columnToMoveDown = _selectedViewState.ListSettings.Columns.FirstOrDefault(c => c.Index == _selectedColumn.Index + 1);

            columnToMoveDown.Index -= 1;
            columnToMoveUp.Index += 1;

            ReloadColumns();
        }

        private void cboViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_loading)
                    return;

                if (_selectedViewState != null)
                {
                    UpdateViewState(_selectedViewState);
                }

                ClearViewStateDetails();

                _selectedViewState = (ViewState)cboViews.SelectedItem;

                var hasSelection = (_selectedViewState != null);

                btnNewView.Enabled = true;
                btnEditSave.Enabled = hasSelection;
                btnCopyView.Enabled = hasSelection;
                btnDeleteView.Enabled = hasSelection;

                _selectedColumn = null;

                if (_selectedViewState == null)
                    return;

                DisplayViewState(_selectedViewState);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error selecting view", ex);
            }
        }

        private void txtHeader_TextChanged(object sender, EventArgs e)
        {
            lblHeader.Text = txtHeader.Text;
        }

        private void btnEditSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnEditSave.Text == "Edit")
                {
                    SetEditMode();
                }
                else if (btnEditSave.Text == "Save")
                {
                    SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("", ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                CancelEditMode();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error cancelling edit mode", ex);
            }
        }

        private void btnNewView_Click(object sender, EventArgs e)
        {
            try
            {
                NewViewState();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error creating new view", ex);
            }
        }

        private void btnCopyView_Click(object sender, EventArgs e)
        {
            try
            {
                CopyViewState();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error copying view", ex);
            }
        }

        private void btnDeleteView_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteViewState();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error deleting view", ex);
            }
        }

        private void btnNewColumn_Click(object sender, EventArgs e)
        {
            try
            {
                NewColumn();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error creating new column", ex);
            }
        }

        private void btnCopyColumn_Click(object sender, EventArgs e)
        {
            try
            {
                CopyColumn();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error copying column", ex);
            }
        }

        private void btnDeleteColumn_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteColumn();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error deleting column", ex);
            }
        }

        private void btnMoveLeft_Click(object sender, EventArgs e)
        {
            try
            {
                MoveColumnLeft();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error moving column", ex);
            }
        }

        private void btnMoveRight_Click(object sender, EventArgs e)
        {
            try
            {
                MoveColumnRight();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error moving column", ex);
            }
        }

        /* Column Details */
        private void HighlightSelectedColumn(ViewListColumn columnSettings)
        {
            try
            {
                foreach (Label columnLabel in pnlRow.Controls.OfType<Label>())
                {
                    ViewListColumn column = (ViewListColumn)columnLabel.Tag;
                    if (column.Index == columnSettings.Index)
                    {
                        columnLabel.BackColor = Color.Yellow;
                    }
                    else
                    {
                        columnLabel.BackColor = pnlRow.BackColor;
                    }
                }
                foreach (Label columnLabel in pnlGridHeader.Controls.OfType<Label>())
                {
                    ViewListColumn column = (ViewListColumn)columnLabel.Tag;
                    if (column.Index == columnSettings.Index)
                    {
                        columnLabel.BackColor = Color.Yellow;
                    }
                    else
                    {
                        columnLabel.BackColor = pnlRow.BackColor;
                    }
                }

            }
            catch (Exception ex)
            {
                ExceptionHandler("Error highlighting column", ex);
            }
        }

        private Label GetColumnHeaderLabel(int index)
        {
            foreach (Label columnLabel in pnlGridHeader.Controls.OfType<Label>())
            {
                ViewListColumn column = (ViewListColumn)columnLabel.Tag;
                if (column.Index == index)
                    return columnLabel;
            }

            return null;
        }

        private Label GetColumnRowLabel(int index)
        {
            foreach (Label columnLabel in pnlRow.Controls.OfType<Label>())
            {
                ViewListColumn column = (ViewListColumn)columnLabel.Tag;
                if (column.Index == index)
                    return columnLabel;
            }

            return null;
        }

        private void txtCaption_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (_selectedColumn == null)
                    return;

                var columnHeaderLabel = GetColumnHeaderLabel(_selectedColumn.Index);

                if (columnHeaderLabel != null)
                    columnHeaderLabel.Text = txtCaption.Text;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error setting column caption", ex);
            }
        }

        private void txtFormat_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (_selectedColumn == null)
                    return;

                var columnRowLabel = GetColumnRowLabel(_selectedColumn.Index);

                // TODO: Format sample data
                //if (columnRowLabel != null)
                //    columnRowLabel.Text = txtFormat.Text;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error setting new column format", ex);
            }
        }

        private void UpdateColumnWidths()
        {
            try
            {
                if (_selectedColumn == null)
                    return;

                int width = 0;
                if (Int32.TryParse(txtWidth.Text, out width))
                {
                    var columnHeaderLabel = GetColumnHeaderLabel(_selectedColumn.Index);

                    if (columnHeaderLabel != null)
                        columnHeaderLabel.Width = width;

                    var columnRowLabel = GetColumnRowLabel(_selectedColumn.Index);

                    if (columnRowLabel != null)
                        columnRowLabel.Width = width;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error updating column width", ex);
            }
        }

        private void cboAlignment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboAlignment.SelectedItem == null || _selectedColumn == null)
                    return;

                var alignment = (ContentAlignment)cboAlignment.SelectedItem;

                var columnHeaderLabel = GetColumnHeaderLabel(_selectedColumn.Index);

                if (columnHeaderLabel != null)
                    columnHeaderLabel.TextAlign = alignment;

                var columnRowLabel = GetColumnRowLabel(_selectedColumn.Index);

                if (columnRowLabel != null)
                    columnRowLabel.TextAlign = alignment;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error updating column alignment", ex);
            }
        }

        private void txtWidth_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                UpdateColumnWidths();
        }

        private void txtWidth_Leave(object sender, EventArgs e)
        {
            UpdateColumnWidths();
        }
        /* End Column Details */

        /* ViewState Details */
        private void chkShowHeader_CheckedChanged(object sender, EventArgs e)
        {
            lblHeader.Visible = chkShowHeader.Checked;
        }

        private void chkShowGridHeader_CheckedChanged(object sender, EventArgs e)
        {
            pnlGridHeader.Visible = chkShowGridHeader.Checked;
        }

        private void txtRowHeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                UpdateViewStateRowHeight();
        }

        private void txtRowHeight_Leave(object sender, EventArgs e)
        {
            UpdateViewStateRowHeight();
        }

        private void UpdateViewStateRowHeight()
        {
            try
            {
                int height = 0;
                if (Int32.TryParse(txtRowHeight.Text, out height))
                {
                    pnlGridHeader.Height = height;
                    pnlRow.Height = height;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error updating row height", ex);
            }
        }
        /* End ViewState Details */

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedViewState != null)
                    UpdateViewState(_selectedViewState);

                if (_selectedColumn != null)
                    UpdateColumnDetails(_selectedColumn);

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error saving changes", ex);
            }
        }

        private void btnDiscardChanges_Click(object sender, EventArgs e)
        {
            try
            {
                DiscardViewStateChanges();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error resetting view state", ex);
            }
        }

        private void chkApplyTheme_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkApplyTheme.Checked)
                {
                    var theme = UserThemeRepository.GetThemeOrDefault((Guid)cboThemes.SelectedValue);

                    ApplyTheme(theme);
                }
                else
                {
                    ApplyTheme(_blankTheme);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error applying theme", ex);
            }
        }

        private void cboThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkApplyTheme.Checked && cboThemes.SelectedValue != null)
                {
                    var theme = UserThemeRepository.GetThemeOrDefault((Guid)cboThemes.SelectedValue);

                    if (theme != null)
                        ApplyTheme(theme);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error selecting theme", ex);
            }
        }

        private void trvDataSources_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataSelected(trvDataSources.SelectedNode);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error setting column data source", ex);
            }
        }

        private void DataSelected(TreeNode node)
        {
            var feedName = node.FullPath.Split('\\')[0];
            var relativeFeedPath = node.FullPath.Substring(feedName.Length + 1);

            if (node.Tag is ViewDataMember)
            {
                if (_selectedColumn != null)
                {
                    var dataMember = (ViewDataMember)node.Tag;

                    _selectedColumn.DataFeed = feedName;
                    _selectedColumn.DataMember = dataMember.Name;
                    _selectedColumn.DataFullPath = relativeFeedPath;

                    txtDataField.Text = _selectedColumn.DataMember;
                    txtDataPath.Text = _selectedColumn.DataFullPath;
                }
            }
            else if (node.Tag is ViewDataSource)
            {
                if (_selectedViewState != null)
                {
                    var dataSource = (ViewDataSource)node.Tag;
                    _selectedViewState.ListSettings.DataSource = feedName;
                    txtDataSource.Text = _selectedViewState.ListSettings.DataSource;
                }
            }
        }

        #endregion
    }
}

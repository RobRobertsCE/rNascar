using System;
using System.IO;
using System.Windows.Forms;

namespace rNascarTS.Dialogs
{
    public partial class FileViewerDialog : Form
    {
        #region properties

        public string Title { get; set; }
        public string FilePath { get; set; }

        #endregion

        #region ctor

        public FileViewerDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region protected

        protected virtual void ReadLogFile()
        {
            using (FileStream file = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var fileStream = new StreamReader(file))
                {
                    txtLog.Text = fileStream.ReadToEnd();
                }
            }
        }

        #endregion

        #region private

        private void LogFileDialog_Load(object sender, EventArgs e)
        {
            Text = Title;
            lblFile.Text = FilePath;
            ReadLogFile();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            ReadLogFile();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            txtLog.SelectAll();
            txtLog.Copy();
        }

        private void btnWrap_Click(object sender, EventArgs e)
        {
            txtLog.WordWrap = btnWrap.Checked;
        }

        #endregion
    }
}

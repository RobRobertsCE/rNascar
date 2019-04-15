using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rNascarTS.Dialogs
{
    public partial class InputDialog : Form
    {
        public string Title { get; set; }
        public string Prompt { get; set; }
        public string Value { get; set; }

        public InputDialog(string title, string prompt, string defaultResponse = "")
            : this()
        {
            Title = title;
            Prompt = prompt;
            Value = defaultResponse;
        }

        public InputDialog()
        {
            InitializeComponent();
        }

        private void InputDialog_Load(object sender, EventArgs e)
        {
            Text = Title;
            lblPrompt.Text = Prompt;
            txtResponse.Text = Value;

            txtResponse.Focus();
            txtResponse.SelectAll();
        }

        private void txtResponse_TextChanged(object sender, EventArgs e)
        {
            Value = txtResponse.Text;
        }
    }
}

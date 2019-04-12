using System;
using System.Windows.Forms;

namespace rNascarTimingAndScoring
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new TSMainForm());
            Application.Run(new TimingAndScoring());
            //Application.Run(new Form1());
        }
    }
}

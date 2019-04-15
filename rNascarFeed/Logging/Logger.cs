using System.Windows.Forms;
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace rNascarTimingAndScoring.Logging
{
    public class Logger
    {
        public static void Setup()
        {
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();

            PatternLayout patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = "%date %-5level %logger - %message%newline";
            patternLayout.ActivateOptions();

            RollingFileAppender roller = new RollingFileAppender();
            roller.AppendToFile = true;
            roller.File = GetLogFilePath();
            roller.Layout = patternLayout;
            roller.MaxSizeRollBackups = 5;
            roller.MaximumFileSize = "1GB";
            roller.RollingStyle = RollingFileAppender.RollingMode.Size;
            roller.StaticLogFileName = true;
            roller.ActivateOptions();
            roller.ImmediateFlush = true;

            hierarchy.Root.AddAppender(roller);

            hierarchy.Root.Level = Level.Error;
            hierarchy.Configured = true;
        }

        protected static string GetLogFilePath()
        {
            return $"{System.IO.Path.GetDirectoryName(Application.ExecutablePath)}\\rNascarT-SLog.json";
        }
    }
}
using System;
using System.IO;
using NascarApi.Models;

namespace rNascarTimingAndScoring.Helpers
{
    public static class FeedWriter
    {
        public static void LogFeedData(EventSettings eventSettings, int lapNumber, string feedData)
        {
            int? index = null;

            string logDirectory = @"C:\Logs";

            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            var fileTitle = $"{eventSettings.season}-{eventSettings.seriesId}-{eventSettings.eventId}-{eventSettings.activityId}-{lapNumber}-feedData{(index.HasValue ? $"({index.Value})" : String.Empty)}.json";

            var fileName = Path.Combine(logDirectory, fileTitle);

            while (File.Exists(fileName))
            {
                var json = File.ReadAllText(fileName);

                if (json != feedData)
                {
                    if (index.HasValue)
                        index++;
                    else
                        index = 0;

                    fileTitle = $"{eventSettings.season}-{eventSettings.seriesId}-{eventSettings.eventId}-{eventSettings.activityId}-{lapNumber}-feedData{(index.HasValue ? $"({index.Value})" : String.Empty)}.json";

                    fileName = Path.Combine(logDirectory, fileTitle);
                }
                else
                {
                    return;
                }
            }

            File.WriteAllText(fileName, feedData);
        }
    }
}

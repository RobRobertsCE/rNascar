using System.IO;
using NascarFeed.Models;

namespace rNascarTimingAndScoring.Helpers
{
    public static class FeedWriter
    {
        public static void LogFeedData(EventSettings eventSettings, int lapNumber, string feedData)
        {
            var fileName = $"C:\\Logs\\{eventSettings.season}-{eventSettings.seriesId}-{eventSettings.eventId}-{eventSettings.activityId}-{lapNumber}-feedData.json";

            File.WriteAllText(fileName, feedData);
        }
    }
}

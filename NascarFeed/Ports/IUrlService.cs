using NascarFeed.Models;

namespace NascarFeed.Ports
{
    public interface IUrlService
    {
        string GetPracticeUrl(EventSettings settings);
        string GetPracticeUrl(int season, int seriesId, int eventId, int sessionId);

        string GetLapAverageUrl(EventSettings settings);
        string GetLapAverageUrl(int season, int seriesId, int eventId, int sessionId);

        string GetLiveFeedUrl();
        string GetLiveFeedUrl(EventSettings settings);
        string GetLiveFeedUrl(int seriesId, int eventId);

        string GetEntryListUrl(EventSettings settings);
        string GetEntryListUrl(int season, int seriesId, int eventId);

        string GetLiveFlagDataUrl();

        string GetLivePitDataUrl(EventSettings settings);
        string GetLivePitDataUrl(int seriesId, int eventId);

        string GetLivePointsUrl(EventSettings settings);
        string GetLivePointsUrl(int seriesId, int eventId);

        string GetLiveQualifyingDataUrl(EventSettings settings);
        string GetLiveQualifyingDataUrl(int seriesId, int eventId);

        string GetPointStandingsUrl(EventSettings settings);
        string GetPointStandingsUrl(int season, int seriesId);

        string GetRaceResultsUrl(EventSettings settings);
        string GetRaceResultsUrl(int season, int seriesId, int eventId);

        string GetQualifyingResultsUrl(EventSettings settings);
        string GetQualifyingResultsUrl(int season, int seriesId, int eventId);

        string GetAudioFeedUrl();

        string GetStageFeedUrl(EventSettings settings);
        string GetStageFeedUrl(int seriesId, int eventId, int sessionId);

        string GetDriveConfigUrl();
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using NascarFeed.Models;

namespace NascarFeed.Ports
{
    public interface IApiClient
    {
        Task<string>  GetRawJsonAsync(string url);

        Task<List<Models.EntryList.RootObject>> GetEntryListAsync(EventSettings settings);
        Task<Models.LapAverage.RootObject> GetLapAveragesAsync(EventSettings settings);
        Task<Models.LiveFeed.RootObject> GetLiveFeedAsync(EventSettings settings);
        Task<Models.LiveFeed.RootObject> GetLiveFeedAsync();
        Task<List<Models.LiveFlagData.RootObject>> GetLiveFlagDataAsync();
        Task<List<Models.LivePitData.RootObject>> GetLivePitDataAsync(EventSettings settings);
        Task<List<Models.LivePoints.RootObject>> GetLivePointsAsync(EventSettings settings);
        Task<List<Models.LiveQualifyingData.RootObject>> GetLiveQualifyingDataAsync(EventSettings settings);
        Task<List<Models.PointStandings.RootObject>> GetPointsStandingsAsync(EventSettings settings);
        Task<List<Models.RaceResults.RootObject>> GetRaceResultsAsync(EventSettings settings);
        Task<List<Models.QualifyingResults.RootObject>> GetQualifyingResultsAsync(EventSettings settings);
        Task<Models.AudioFeed.RootObject> GetAudioFeedAsync();
        Task<Models.StageFeed.RootObject> GetStageFeedAsync(EventSettings settings);
        Task<EventSettings> GetLiveEventSettingsAsync();
    }
}
using System.Collections.Generic;
using NascarFeed.Models;

namespace NascarFeed.Ports
{
    public interface IApiClient
    {
        string GetRawJson(string url);

        List<Models.EntryList.RootObject> GetEntryList(EventSettings settings);
        Models.LapAverage.RootObject GetLapAverages(EventSettings settings);
        Models.LiveFeed.RootObject GetLiveFeed(EventSettings settings);
        Models.LiveFeed.RootObject GetLiveFeed();
        List<Models.LiveFlagData.RootObject> GetLiveFlagData();
        List<Models.LivePitData.RootObject> GetLivePitData(EventSettings settings);
        List<Models.LivePoints.RootObject> GetLivePoints(EventSettings settings);
        List<Models.LiveQualifyingData.RootObject> GetLiveQualifyingData(EventSettings settings);
        List<Models.PointStandings.RootObject> GetPointsStandings(EventSettings settings);
        List<Models.RaceResults.RootObject> GetRaceResults(EventSettings settings);
        List<Models.QualifyingResults.RootObject> GetQualifyingResults(EventSettings settings);
        Models.AudioFeed.RootObject GetAudioFeed();
        Models.StageFeed.RootObject GetStageFeed(EventSettings settings);
        Models.Drive.RootObject GetDriveConfiguration();
        EventSettings GetLiveEventSettings();
    }
}
using System;
using System.Collections.Generic;
using NascarFeed.Models;
using NascarFeed.Models.LiveFlagData;
using NascarFeed.Models.LivePitData;
using NascarFeed.Models.LivePoints;
using NascarFeed.Models.LiveQualifyingData;
using NascarFeed.Models.PointStandings;
using NascarFeed.Models.RaceResults;
using NascarFeed.Ports;
using RestSharp;

namespace NascarFeed.Adapters
{
    public class ApiClient : IApiClient
    {
        #region fields

        private readonly IUrlService _urlService;

        #endregion

        #region ctor

        public ApiClient(IUrlService urlService)
        {
            _urlService = urlService ?? throw new ArgumentNullException(nameof(urlService));
        }

        #endregion

        #region public

        public EventSettings GetLiveEventSettings()
        {
            EventSettings liveEvent = new EventSettings();

            var feed = GetLiveFeed();

            if (feed != null)
            {
                liveEvent.eventId = feed.race_id;
                liveEvent.seriesId = feed.series_id;
                liveEvent.activityId = feed.run_type;
                liveEvent.sessionId = feed.run_id;
                liveEvent.trackId = feed.track_id;
                liveEvent.trackLength = feed.track_length;
            }

            return liveEvent;
        }

        // raw json
        public string GetRawJson(string url)
        {
            var client = new RestClient(url);

            IRestResponse response = client.Execute(new RestRequest());

            return response.Content;
        }

        public Models.LiveFeed.RootObject GetLiveFeed()
        {
            var url = _urlService.GetLiveFeedUrl();

            return GetData<Models.LiveFeed.RootObject>(url);
        }

        public Models.LiveFeed.RootObject GetLiveFeed(EventSettings settings)
        {
            var url = _urlService.GetLiveFeedUrl(settings);

            return GetData<Models.LiveFeed.RootObject>(url);
        }

        public Models.LapAverage.RootObject GetLapAverages(EventSettings settings)
        {
            var url = _urlService.GetLapAverageUrl(settings);

            return GetData<Models.LapAverage.RootObject>(url);
        }

        public List<Models.EntryList.RootObject> GetEntryList(EventSettings settings)
        {
            var url = _urlService.GetEntryListUrl(settings);

            return GetData<List<Models.EntryList.RootObject>>(url);
        }

        public List<Models.LiveFlagData.RootObject> GetLiveFlagData()
        {
            var url = _urlService.GetLiveFlagDataUrl();

            return GetData<List<Models.LiveFlagData.RootObject>>(url);
        }

        public List<Models.LivePitData.RootObject> GetLivePitData(EventSettings settings)
        {
            var url = _urlService.GetLivePitDataUrl(settings);

            return GetData<List<Models.LivePitData.RootObject>>(url);
        }

        public List<Models.LivePoints.RootObject> GetLivePoints(EventSettings settings)
        {
            var url = _urlService.GetLivePointsUrl(settings);

            return GetData<List<Models.LivePoints.RootObject>>(url);
        }

        public List<Models.LiveQualifyingData.RootObject> GetLiveQualifyingData(EventSettings settings)
        {
            var url = _urlService.GetLiveQualifyingDataUrl(settings);

            return GetData<List<Models.LiveQualifyingData.RootObject>>(url);
        }

        public List<Models.PointStandings.RootObject> GetPointsStandings(EventSettings settings)
        {
            var url = _urlService.GetPointStandingsUrl(settings);

            return GetData<List<Models.PointStandings.RootObject>>(url);
        }

        public List<Models.RaceResults.RootObject> GetRaceResults(EventSettings settings)
        {
            var url = _urlService.GetRaceResultsUrl(settings);

            return GetData<List<Models.RaceResults.RootObject>>(url);
        }

        public List<Models.QualifyingResults.RootObject> GetQualifyingResults(EventSettings settings)
        {
            var url = _urlService.GetQualifyingResultsUrl(settings);

            return GetData<List<Models.QualifyingResults.RootObject>>(url);
        }

        public Models.AudioFeed.RootObject GetAudioFeed()
        {
            var url = _urlService.GetAudioFeedUrl();

            return GetData<Models.AudioFeed.RootObject>(url);
        }

        public Models.StageFeed.RootObject GetStageFeed(EventSettings settings)
        {
            var url = _urlService.GetStageFeedUrl(settings);

            return GetData<Models.StageFeed.RootObject>(url);
        }

        public Models.Drive.RootObject GetDriveConfiguration()
        {
            var url = _urlService.GetDriveConfigUrl();

            return GetData<Models.Drive.RootObject>(url);
        }

        #endregion

        #region protected

        protected virtual T GetData<T>(string url) where T : class, new()
        {
            var client = new RestClient(url);

            var response = client.Execute<T>(new RestRequest());

            return response.Data;
        }

        #endregion
    }
}

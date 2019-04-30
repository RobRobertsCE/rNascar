using System;
using NascarApi.Models;
using NascarApi.Ports;

namespace NascarApi.Adapters
{
    class UrlService : IUrlService
    {
        #region public

        // https://www.nascar.com/cacher/2019/1/4780/practice1.json
        private const string practiceUrlTemplate = "https://www.nascar.com/cacher/{0}/{1}/{2}/practice{3}.json";
        public string GetPracticeUrl(EventSettings settings)
        {
            return GetPracticeUrl(settings.season, settings.series_id, settings.race_id, settings.run_id);
        }
        public string GetPracticeUrl(int season, int seriesId, int eventId, int sessionId)
        {
            return string.Format(practiceUrlTemplate, season, seriesId, eventId, sessionId);
        }

        // https://www.nascar.com/cacher/2019/1/4780/entryList.json
        // https://www.nascar.com/cacher/2019/2/4817/entryList.json
        private const string entryListUrlTemplate = "https://www.nascar.com/cacher/{0}/{1}/{2}/entryList.json";
        public string GetEntryListUrl(EventSettings settings)
        {
            return GetEntryListUrl(settings.season, settings.series_id, settings.race_id);
        }
        public string GetEntryListUrl(int season, int seriesId, int eventId)
        {
            return string.Format(entryListUrlTemplate, season, seriesId, eventId);
        }

        // https://www.nascar.com/cacher/2019/2/4817/lapAvg_nxs_practice_1.json
        // https://www.nascar.com/cacher/2019/1/4780/lapAvg_mencs_final_practice.json
        private const string lapAverageUrlTemplate = "https://www.nascar.com/cacher/{0}/{1}/{2}/lapAvg_{3}_{4}.json";
        public string GetLapAverageUrl(EventSettings settings)
        {
            return GetLapAverageUrl(settings.season, settings.series_id, settings.race_id, settings.run_id);
        }
        public string GetLapAverageUrl(int season, int seriesId, int eventId, int sessionId)
        {
            var seriesKey = GetSeriesKey(seriesId);
            var sessionKey = GetSessionKey(sessionId);

            return string.Format(lapAverageUrlTemplate, season, seriesId, eventId, seriesKey, sessionKey);
        }

        // https://www.nascar.com/live/feeds/live-feed.json <- used for K&N race at Bristol, ARCA at Talladega, seriesId = 999
        private const string genericLiveFeedUrlTemplate = "https://www.nascar.com/live/feeds/live-feed.json";
        // https://www.nascar.com/live/feeds/series_2/4817/live_feed.json
        private const string liveFeedUrlTemplate = "https://www.nascar.com/live/feeds/series_{0}/{1}/live_feed.json";
        public string GetLiveFeedUrl(EventSettings settings)
        {
            return GetLiveFeedUrl(settings.series_id, settings.race_id);
        }
        public string GetLiveFeedUrl(int seriesId, int eventId)
        {
            if (seriesId > 3)
                return genericLiveFeedUrlTemplate;
            else
                return string.Format(liveFeedUrlTemplate, seriesId, eventId);
        }
        public string GetLiveFeedUrl()
        {
            return "https://www.nascar.com/live/feeds/live-feed.json";
        }

        // https://www.nascar.com/cacher/live/live-flag-data.json
        private const string liveFlagDataUrl = "https://www.nascar.com/cacher/live/live-flag-data.json";
        public string GetLiveFlagDataUrl()
        {
            return liveFlagDataUrl;
        }

        // https://www.nascar.com/live/feeds/series_1/4779/live-pit-data.json
        private const string livePitDataUrlTemplate = "https://www.nascar.com/live/feeds/series_{0}/{1}/live-pit-data.json";
        public string GetLivePitDataUrl(EventSettings settings)
        {
            return GetLivePitDataUrl(settings.series_id, settings.race_id);
        }
        public string GetLivePitDataUrl(int seriesId, int eventId)
        {
            return string.Format(livePitDataUrlTemplate, seriesId, eventId);
        }


        // https://www.nascar.com/live/feeds/series_2/4817/live-points.json
        private const string livePointsUrlTemplate = "https://www.nascar.com/live/feeds/series_{0}/{1}/live-points.json";
        public string GetLivePointsUrl(EventSettings settings)
        {
            return GetLivePointsUrl(settings.series_id, settings.race_id);
        }
        public string GetLivePointsUrl(int seriesId, int eventId)
        {
            return string.Format(livePointsUrlTemplate, seriesId, eventId);
        }

        // https://www.nascar.com/live/feeds/series_2/4817/live-qualifying-data.json
        private const string liveQualifyingDataUrlTemplate = "https://www.nascar.com/live/feeds/series_{0}/{1}/live-qualifying-data.json";
        public string GetLiveQualifyingDataUrl(EventSettings settings)
        {
            return GetLiveQualifyingDataUrl(settings.series_id, settings.race_id);
        }
        public string GetLiveQualifyingDataUrl(int seriesId, int eventId)
        {
            return string.Format(liveQualifyingDataUrlTemplate, seriesId, eventId);
        }

        // https://www.nascar.com/cacher/2019/1/points-feed.json
        private const string pointsStandingsUrlTemplate = "https://www.nascar.com/cacher/{0}/{1}/points-feed.json";
        public string GetPointStandingsUrl(EventSettings settings)
        {
            return GetPointStandingsUrl(settings.season, settings.series_id);
        }
        public string GetPointStandingsUrl(int season, int seriesId)
        {
            return string.Format(liveQualifyingDataUrlTemplate, season, seriesId);
        }

        // https://www.nascar.com/cacher/2019/1/4779/raceResults.json?del=0.32764
        private const string raceResultsUrlTemplate = "https://www.nascar.com/cacher/{0}/{1}/{2}/raceResults.json?del=0.32764";
        public string GetRaceResultsUrl(EventSettings settings)
        {
            return GetRaceResultsUrl(settings.season, settings.series_id, settings.race_id);
        }
        public string GetRaceResultsUrl(int season, int seriesId, int eventId)
        {
            return string.Format(raceResultsUrlTemplate, season, seriesId, eventId);
        }

        // https://www.nascar.com/cacher/2019/1/4779/qualification.json
        private const string qualifyingResultsUrlTemplate = "https://www.nascar.com/cacher/{0}/{1}/{2}/qualification.json";
        public string GetQualifyingResultsUrl(EventSettings settings)
        {
            return GetQualifyingResultsUrl(settings.season, settings.series_id, settings.race_id);
        }
        public string GetQualifyingResultsUrl(int season, int seriesId, int eventId)
        {
            return string.Format(qualifyingResultsUrlTemplate, season, seriesId, eventId);
        }

        private const string audioFeedUrl = "https://www.nascar.com/config/audio/audio_mapping_2_3.json";
        public string GetAudioFeedUrl()
        {
            return audioFeedUrl;
        }

        // https://www.nascar.com/live/feeds/series_2/4817/stage1-feed.json
        private const string stageFeedUrlTemplate = "https://www.nascar.com/live/feeds/series_{0}/{1}/stage{2}-feed.json";
        public string GetStageFeedUrl(EventSettings settings)
        {
            return GetStageFeedUrl(settings.series_id, settings.race_id, settings.run_id);
        }
        public string GetStageFeedUrl(int seriesId, int eventId, int sessionId)
        {
            return string.Format(stageFeedUrlTemplate, seriesId, eventId, sessionId);
        }

        private const string driveConfigUrl = "https://www.nascar.com/drive/configs.json";
        public string GetDriveConfigUrl()
        {
            return driveConfigUrl;
        }

        #endregion

        #region protected

        protected virtual string GetSeriesKey(int seriesId)
        {
            switch (seriesId)
            {
                case 1:
                    {
                        return "mencs";
                    }
                case 2:
                    {
                        return "nxs";
                    }
                case 3:
                    {
                        return "nts";
                    }
                default:
                    {
                        throw new ArgumentException($"Unrecognized seriesId: {seriesId}");
                    }
            }
        }

        protected virtual string GetSessionKey(int sessionId)
        {
            switch (sessionId)
            {
                case 1:
                    {
                        return $"practice_{sessionId}";
                    }
                case 2:
                    {
                        return $"practice_{sessionId}";
                    }
                case 3:
                    {
                        return $"final_practice";
                    }
                default:
                    {
                        throw new ArgumentException($"Unrecognized sessionId: {sessionId}");
                    }
            }
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using NascarApi.Models;
using NascarApi.Ports;
using NascarApi.Client.Configuration;
using NascarApi.Client.Ports;

namespace NascarApi.Client.Adapters
{
    class FeedService : IFeedService
    {
        #region events

        public event EventHandler<Exception> FeedException;
        protected virtual void OnFeedException(Exception e)
        {
            var handler = FeedException;
            handler?.Invoke(this, e);
        }

        #endregion

        #region fields

        private IApiClient _apiClient;
        private IList<FeedSubscription> _subscriptions;
        private Timer _feedTimer;

        #endregion

        #region properties

        public EventSettings Event { get; set; }

        #endregion

        #region ctor

        public FeedService(IApiClient apiClient)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));

            _subscriptions = new List<FeedSubscription>();

            _feedTimer = new Timer(5000);

            _feedTimer.Elapsed += FeedTimer_Elapsed;
        }

        #endregion

        #region public

        public void Register(FeedSubscription subscription)
        {
            _subscriptions.Add(subscription);

            if (!_feedTimer.Enabled)
            {
                _feedTimer.Start();
            }
        }

        public void Unregister(FeedSubscription subscription)
        {
            _subscriptions.Remove(subscription);

            if (_subscriptions.Count == 0 && _feedTimer.Enabled)
            {
                _feedTimer.Stop();
            }
        }

        #endregion

        #region protected

        protected virtual void ExceptionHandler(Exception ex, string message = "")
        {
            // log here

            OnFeedException(ex);
        }

        #endregion

        #region private

        private async void FeedTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                _feedTimer.Stop();

                IEnumerable<LiveFeedSubscription> liveFeedSubscriptions = _subscriptions
                    .Where(s => s is LiveFeedSubscription)
                    .Cast<LiveFeedSubscription>();

                if (liveFeedSubscriptions.Count() > 0)
                {
                    var data = await _apiClient.GetLiveFeedAsync(Event);

                    DeliverSubscriptionData(liveFeedSubscriptions, data);
                }

                IEnumerable<LiveFeedDataSubscription> liveFeedDataSubscriptions = _subscriptions
                    .Where(s => s is LiveFeedDataSubscription)
                    .Cast<LiveFeedDataSubscription>();

                if (liveFeedDataSubscriptions.Count() > 0)
                {
                    var data = await _apiClient.GetLiveFeedAsync(Event);

                    foreach (LiveFeedDataSubscription subscription in liveFeedDataSubscriptions)
                    {
                        subscription.Feed.Invoke(this, data);
                    }
                }

                //var livePointsSubscriptions = _subscriptions.Where(s => s is LivePointsSubscription);

                //if (livePointsSubscriptions.Count() > 0)
                //{

                //}

                //var liveFlagSubscriptions = _subscriptions.Where(s => s is LiveFlagSubscription);

                //if (liveFlagSubscriptions.Count() > 0)
                //{

                //}

                _feedTimer.Start();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex, "Error calling subscriptions");
            }

        }

        private void DeliverSubscriptionData(IEnumerable<LiveFeedSubscription> subscriptions, NascarApi.Models.LiveFeed.RootObject data)
        {
            foreach (LiveFeedSubscription subscription in subscriptions)
            {
                var values = GetSubscriptionFields(subscription.Fields, data);

                subscription.Feed.Invoke(this, values);
            }
        }

        private IDictionary<string, string> GetSubscriptionFields(IList<string> fields, NascarApi.Models.LiveFeed.RootObject data)
        {
            IDictionary<string, string> values = new Dictionary<string, string>();

            var myType = data.GetType();

            foreach (string field in fields)
            {
                var myPropInfo = myType.GetProperty(field);
                var myValue = myPropInfo.GetValue(data, null);
                values.Add(field, myValue.ToString());
            }

            return values;
        }

        #endregion
    }
}

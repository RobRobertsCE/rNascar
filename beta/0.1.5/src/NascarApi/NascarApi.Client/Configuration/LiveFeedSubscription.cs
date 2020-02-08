using System;
using System.Collections.Generic;

namespace NascarApi.Client.Configuration
{
    public class LiveFeedSubscription : FeedSubscription
    {
        public EventHandler<IDictionary<string, string>> Feed { get; set; }
        public IList<string> CarNumbers { get; set; } = new List<string>();
    }

    public class LiveFeedDataSubscription : FeedSubscription
    {
        public EventHandler<NascarApi.Models.LiveFeed.RootObject> Feed { get; set; }
        public IList<string> CarNumbers { get; set; } = new List<string>();
    }
}

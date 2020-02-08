using System;

namespace NascarApi.Client.Configuration
{
    public class LiveFlagSubscription : FeedSubscription
    {
        public EventHandler<NascarApi.Models.LiveFlagData.RootObject> Feed { get; set; }
    }
}

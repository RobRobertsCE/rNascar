using System;
using System.Collections.Generic;

namespace NascarApi.Client.Configuration
{
    public class LivePointsSubscription : FeedSubscription
    {
        public EventHandler<NascarApi.Models.LivePoints.RootObject> Feed { get; set; }
        public IList<string> CarNumbers { get; set; } = new List<string>();
    }
}

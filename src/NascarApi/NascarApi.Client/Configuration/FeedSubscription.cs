using System.Collections.Generic;

namespace NascarApi.Client.Configuration
{
    public abstract class FeedSubscription
    {
        public IList<string> Fields { get; set; } = new List<string>();
    }
}

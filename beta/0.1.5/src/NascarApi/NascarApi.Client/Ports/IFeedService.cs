using System;
using NascarApi.Models;
using NascarApi.Models.LiveFeed;
using NascarApi.Client.Configuration;
using NascarApi.Client.Models;

namespace NascarApi.Client.Ports
{
    public interface IFeedService
    {
        EventSettings Event { get; set; }

        event EventHandler<Exception> FeedException;

        void Register(FeedSubscription subscription);
        void Unregister(FeedSubscription subscription);
    }
}
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NascarApi.Client.Adapters;
using NascarApi.Client.Ports;

namespace NascarApi.Client
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNascarFeedReader(this IServiceCollection services)
        {
            services.AddTransient<IFeedService, FeedService>();
            services.AddTransient<ILapTimeService, LapTimeService>();
            services.TryAddTransient<ILapTimeRepository, LapTimeRepository>();

            services.TryAddTransient<ILapTimeContext, LapTimeContext>();

            return services;
        }
    }
}

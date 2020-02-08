using Microsoft.Extensions.DependencyInjection;
using NascarApi.Data.Ports;

namespace NascarApi.Data.Adapters
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNascarFeedData(this IServiceCollection services)
        {
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<ISeriesRepository, SeriesRepository>();

            return services;
        }
    }
}

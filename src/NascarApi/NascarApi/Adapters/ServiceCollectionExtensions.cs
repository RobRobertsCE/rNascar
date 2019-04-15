using Microsoft.Extensions.DependencyInjection;
using NascarApi.Ports;

namespace NascarApi.Adapters
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNascarFeed(this IServiceCollection services)
        {
            services.AddTransient<IApiClient, ApiClient>();
            services.AddTransient<IUrlService, UrlService>();

            return services;
        }
    }
}

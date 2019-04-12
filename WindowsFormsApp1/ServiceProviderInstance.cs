using System;
using Microsoft.Extensions.DependencyInjection;
using NascarFeed.Adapters;
using NascarFeed.Data.Adapters;
using rNascarTimingAndScoring.ViewModels;

namespace rNascarTimingAndScoring
{
    static class ServiceProvider
    {
        private static IServiceProvider _instance;
        public static IServiceProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = CreateServiceProvider();

                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        private static IServiceProvider CreateServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddTransient<IRaceViewModel, RaceViewModel>();

            services.AddNascarFeed();
            services.AddNascarFeedData();

            return services.BuildServiceProvider();
        }
    }
}

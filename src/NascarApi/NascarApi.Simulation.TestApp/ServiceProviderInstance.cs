using System;
using Microsoft.Extensions.DependencyInjection;
using NascarApi.Mock.Adapters;

namespace NascarApi.Mock.TestApp
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

            services.AddNascarFeedMock();

            return services.BuildServiceProvider();
        }
    }
}

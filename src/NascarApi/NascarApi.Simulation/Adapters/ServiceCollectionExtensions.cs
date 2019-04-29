using Microsoft.Extensions.DependencyInjection;
using NascarApi.Simulation.Internal.Factories;
using NascarApi.Simulation.Ports;

namespace NascarApi.Simulation.Adapters
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNascarFeedMock(this IServiceCollection services)
        {
            services.AddSingleton(new VehicleFactory());
            services.AddSingleton(new TrackFactory());
            services.AddSingleton(new DriverFactory());
            services.AddSingleton(new SeriesFactory());

            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<IEventGenerator, EventGenerator>();
            services.AddTransient<IRaceSimulator, RaceSimulator>();
            services.AddTransient<IPracticeSimulator, PracticeSimulator>();
            services.AddTransient<IQualifyingSimulator, QualifyingSimulator>();
            services.AddTransient<IDriverRepository, DriverRepository>();
            services.AddTransient<IVehicleRepository, VehicleRepository>();
            services.AddTransient<ITrackRepository, TrackRepository>();
            services.AddTransient<ISeriesRepository, SeriesRepository>();

            return services;
        }
    }
}

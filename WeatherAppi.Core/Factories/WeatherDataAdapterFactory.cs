using System;
using WeatherApp.Core.Adapters;
using WeatherApp.Core.Infrastructure.Adapter;
using WeatherApp.Domain;

namespace WeatherApp.Core.Factories
{
    public class WeatherDataAdapterFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public WeatherDataAdapterFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public IWeatherDataAdapter GetWeatherAdapter(DataAdapterType dataAdapterType)
        {
            return dataAdapterType switch
            {
                DataAdapterType.OpenWeatherMap => (IWeatherDataAdapter)_serviceProvider.GetService(typeof(OpenWeatherMapDataAdapter)),
                DataAdapterType.Dummy => (IWeatherDataAdapter)_serviceProvider.GetService(typeof(DummyDataAdapter)),
                _ => throw new NotSupportedException(),
            };
        }
    }
}

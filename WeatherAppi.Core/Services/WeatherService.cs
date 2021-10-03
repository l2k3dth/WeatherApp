using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WeatherApp.Core.Factories;
using WeatherApp.Core.Infrastructure.Adapter;
using WeatherApp.Core.Infrastructure.Services;
using WeatherApp.Domain;

namespace WeatherAppi.Core.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherDataAdapter _weatherDataAdapter;

        public WeatherService(ILogger<WeatherService> log, WeatherDataAdapterFactory weatherDataAdapterFactory)
        {

            _weatherDataAdapter = weatherDataAdapterFactory.GetWeatherAdapter(DataAdapterType.OpenWeatherMap);
        }

        public async Task<WeatherResponse> GetWeatherAsync(WeatherRequest request) 
            => await _weatherDataAdapter.GetWeatherByLocationAsync(request);
       
    }
}

using System.Threading.Tasks;
using WeatherApp.Domain;

namespace WeatherApp.Core.Infrastructure.Adapter
{
    public interface IWeatherDataAdapter
    {
        Task<WeatherResponse> GetWeatherByLocationAsync(WeatherRequest request);
    }
}

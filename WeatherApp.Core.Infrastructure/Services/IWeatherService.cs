using System.Threading.Tasks;
using WeatherApp.Domain;

namespace WeatherApp.Core.Infrastructure.Services
{
    public interface IWeatherService
    {
        Task<WeatherResponse> GetWeatherAsync(WeatherRequest request);
    }
}

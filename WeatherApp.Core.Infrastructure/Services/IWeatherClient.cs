using System.Threading.Tasks;
using WeatherApp.Domain.OpenWeatherMapResponses;

namespace WeatherApp.Core.Infrastructure.Services
{
    public interface IWeatherClient
    {
        Task<OpenWeatherMapResponse> GetWeatherByLocationAsync(string request);
    }
}

using System.Threading.Tasks;
using WeatherApp.Core.Infrastructure.Adapter;
using WeatherApp.Domain;

namespace WeatherApp.Core.Adapters
{
    public class DummyDataAdapter : IWeatherDataAdapter
    {
        public DummyDataAdapter()
        {

        }

        public async Task<WeatherResponse> GetWeatherByLocationAsync(WeatherRequest request)
        {
            return await Task.Run(() =>
                new WeatherResponse()
                {
                    Humidity = 00,
                    Icon = "10d",
                    Location = "test",
                    Pressure = 23,
                    Description = "Raining",
                    Sunrise = 1632895075,
                    Sunset = 1632937413,
                    Status = System.Net.HttpStatusCode.OK,
                    Temprature = new Temparature()
                    {
                        Current = 4,
                        Maximum = 5,
                        Minimum = 2
                    }
                });
        }
    }
}

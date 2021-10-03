using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Core.Infrastructure.Adapter;
using WeatherApp.Core.Infrastructure.Services;
using WeatherApp.Domain;
using WeatherApp.Domain.OpenWeatherMapResponses;

namespace WeatherApp.Core.Adapters
{

    public class OpenWeatherMapDataAdapter : IWeatherDataAdapter
    {
        private readonly IWeatherClient _weatherClient;

        public OpenWeatherMapDataAdapter(IWeatherClient weatherClient)
        {
            _weatherClient = weatherClient;
        }

        public async Task<WeatherResponse> GetWeatherByLocationAsync(WeatherRequest request)
            =>  MapResponse(await _weatherClient.GetWeatherByLocationAsync(request.Location));

        private WeatherResponse MapResponse(OpenWeatherMapResponse OpenWeatherMapResponse)
        {
            var response = new WeatherResponse();

            switch (OpenWeatherMapResponse.Cod)
            {
                case 500:
                    response.Status = System.Net.HttpStatusCode.InternalServerError;
                    response.Message.Add("Weather provider is currently down");

                    return response;
                case 404:
                    response.Status = System.Net.HttpStatusCode.NotFound;
                    response.Message.Add(OpenWeatherMapResponse.Message);

                    return response;
                case 200:
                    return new WeatherResponse
                    {
                        Status = System.Net.HttpStatusCode.OK,
                        Humidity = OpenWeatherMapResponse.Main.Humidity,
                        Icon = OpenWeatherMapResponse.Weather.FirstOrDefault().Icon,
                        Location = OpenWeatherMapResponse.Name,
                        Pressure = OpenWeatherMapResponse.Main.Pressure,
                        Description = OpenWeatherMapResponse.Weather.FirstOrDefault().Description,
                        Sunrise = OpenWeatherMapResponse.Sys.Sunrise,
                        Sunset = OpenWeatherMapResponse.Sys.Sunset,
                        Temprature = new Temparature()
                        {
                            Current = OpenWeatherMapResponse.Main.Temp,
                            Maximum = OpenWeatherMapResponse.Main.TempMax,
                            Minimum = OpenWeatherMapResponse.Main.TempMin
                        }
                    };
                default:
                    response.Status = System.Net.HttpStatusCode.InternalServerError;
                    response.Message.Add("There was an issue with this request");
                    break;
            }


            return response;
        }
    }
}

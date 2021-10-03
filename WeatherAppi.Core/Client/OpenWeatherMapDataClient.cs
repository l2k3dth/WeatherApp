using RestSharp;
using System;
using System.Threading.Tasks;
using WeatherApp.Core.Infrastructure.Services;
using WeatherApp.Domain;
using WeatherApp.Domain.OpenWeatherMapResponses;

namespace WeatherApp.Core.Client
{
    public class OpenWeatherMapDataClient : IWeatherClient
    {
        private readonly RestClient _client;
        private readonly OpenWeatherMapApiSettings _settings;

        public OpenWeatherMapDataClient(OpenWeatherMapApiSettings settings)
        {
            _settings = settings;
            _client = CreateClient();
        }

        private RestClient CreateClient()
            => new RestClient(_settings.BaseUrl);

        public async Task<OpenWeatherMapResponse> GetWeatherByLocationAsync(string request)
        {
            var openWeatherMapRequest = CreateWeatherByLocationRequest(request);
            try
            {
                return await _client.GetAsync<OpenWeatherMapResponse>(openWeatherMapRequest);

            }
            catch (Exception e)
            {
                return new OpenWeatherMapResponse()
                {
                    Cod = 500,
                    Message = "There was an issue making the request to openweather map"
                };

            }
        }

        private RestRequest CreateWeatherByLocationRequest(string location)
        {
            var query = "weather";
            var countryCode = "GB";
            var units = "metric";

            var request = new RestRequest(query,DataFormat.Json);

            request.AddQueryParameter("q", $"{location},{countryCode}", false);
            request.AddQueryParameter("units", units,false);
            request.AddQueryParameter("appid", _settings.ApiKey,false);

            return request;
        }
    }
}

using FluentAssertions;
using Moq;
using NUnit.Framework;
using RestSharp;
using System.Threading.Tasks;
using WeatherApp.Core.Adapters;
using WeatherApp.Core.Client;
using WeatherApp.Core.Infrastructure.Adapter;
using WeatherApp.Core.Infrastructure.Services;
using WeatherApp.Domain;

namespace WeatherApp.Tests.Unit
{
    [TestFixture]
    public class WeatherClient_tests
    {
        private  OpenWeatherMapApiSettings _settings;
        private OpenWeatherMapDataClient _client;

        [SetUp]
        public void SetUp()
        {

            
        }

        [Test]
        public async Task GetWeatherByLocation_Success()
        {
            _settings = new OpenWeatherMapApiSettings()
            {
                ApiKey = "af0e66bc4578abbed17b338b0bee4fc4",
                BaseUrl = "https://api.openweathermap.org/data/2.5/"
            };

            _client = new OpenWeatherMapDataClient(_settings);

            var result = await _client.GetWeatherByLocationAsync("london");

            result.Name.Should().Be("London");
        }

        [Test]
        public async Task GetWeatherByLocation_Not_found()
        {
            _settings = new OpenWeatherMapApiSettings()
            {
                ApiKey = "af0e66bc4578abbed17b338b0bee4fc4",
                BaseUrl = "https://api.openweathermap.org/data/2.5/"
            };

            _client = new OpenWeatherMapDataClient(_settings);
            var result = await _client.GetWeatherByLocationAsync("kfukhfhujkfkuyf");

            result.Cod.Should().Be(404);

        }
    }
}

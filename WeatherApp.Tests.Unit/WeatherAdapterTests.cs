using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using WeatherApp.Core.Adapters;
using WeatherApp.Core.Infrastructure.Adapter;
using WeatherApp.Core.Infrastructure.Services;
using WeatherApp.Domain;

namespace WeatherApp.Tests.Unit
{
    [TestFixture]
    public class WeatherAdapter_tests
    {
        private Mock<IWeatherClient> _weatherClient;

        private IWeatherDataAdapter _weatherDataAdapter;

        [SetUp]
        public void SetUp()
        {
            _weatherClient = new Mock<IWeatherClient>();
            _weatherDataAdapter = new OpenWeatherMapDataAdapter(_weatherClient.Object);


        }

        [Test]
        public async Task GetWeatherByLocation_Success()
        {
            _weatherClient.Setup(e => e.GetWeatherByLocationAsync(It.IsAny<string>())).Returns(Task.FromResult(new Domain.OpenWeatherMapResponses.OpenWeatherMapResponse()
            {
                Cod = 200,
                Weather = new System.Collections.Generic.List<Domain.OpenWeatherMapResponses.Weather>() {new Domain.OpenWeatherMapResponses.Weather() {
                Description = "clouds",
                Icon = "04n",
                } },
                Main = new Domain.OpenWeatherMapResponses.Main()
                {
                    Humidity = 94,
                    Temp = 2,
                    TempMax = 3,
                    TempMin = 2,
                    Pressure = 2,
                },
                Sys = new Domain.OpenWeatherMapResponses.Sys()
                {
                    Sunrise = 1633154567,
                    Sunset = 1633154567
                },
                Name = "London",
            }));

            var request = new WeatherRequest()
            {
                Location = "London",
                Test = false
            };

            var expectedResponse = new WeatherResponse()
            {
                Description = "clouds",
                Humidity = 94,
                Temprature = new Temparature
                {
                    Current = 2,
                    Maximum = 3,
                    Minimum = 2,
                },
                Icon = "04n",
                Pressure = 2,
                Location = "London",
               Status = System.Net.HttpStatusCode.OK,
               Sunrise = 1633154567,
               Sunset = 1633154567
            };

            var result = await _weatherDataAdapter.GetWeatherByLocationAsync(request);

            result.Should().BeEquivalentTo(expectedResponse);
        }

        [Test]
        public async Task Map_Response_404()
        {
            _weatherClient.Setup(e => e.GetWeatherByLocationAsync(It.IsAny<string>())).Returns(Task.FromResult(new Domain.OpenWeatherMapResponses.OpenWeatherMapResponse()
            {
                Cod = 404,
                Message = "Test Fail",
            }));

            var request = new WeatherRequest()
            {
                Location = "asdfasdf",
                Test = false
            };

            var expectedResponse = new WeatherResponse()
            {
                Status = System.Net.HttpStatusCode.NotFound,
                Message = new System.Collections.Generic.List<string>() { "Test Fail" }
            };

            var result = await _weatherDataAdapter.GetWeatherByLocationAsync(request);
            result.Should().BeEquivalentTo(expectedResponse);

        }

        [Test]
        public async Task Request_Succesful_Response_500()
        {
            _weatherClient.Setup(e => e.GetWeatherByLocationAsync(It.IsAny<string>())).Returns(Task.FromResult(new Domain.OpenWeatherMapResponses.OpenWeatherMapResponse()
            {
                Cod = 500,
            }));

            var request = new WeatherRequest()
            {
                Location = "asdfasdf",
                Test = false
            };

            var expectedResponse = new WeatherResponse()
            {
                Status = System.Net.HttpStatusCode.InternalServerError,
                Message = new System.Collections.Generic.List<string>() { "Weather provider is currently down" }
            };

            var result = await _weatherDataAdapter.GetWeatherByLocationAsync(request);
            result.Should().BeEquivalentTo(expectedResponse);

        }

        [Test]
        public async Task Request_Unsuccesful_Response_default()
        {
            _weatherClient.Setup(e => e.GetWeatherByLocationAsync(It.IsAny<string>())).Returns(Task.FromResult(new Domain.OpenWeatherMapResponses.OpenWeatherMapResponse()
            {
            }));

            var request = new WeatherRequest()
            {
                Location = "peterborough",
                Test = true
            };

            var expectedResponse = new WeatherResponse()
            {
                Status = System.Net.HttpStatusCode.InternalServerError,
                Message = new System.Collections.Generic.List<string>() { "There was an issue with this request" }
            };

            var result = await _weatherDataAdapter.GetWeatherByLocationAsync(request);
            result.Should().BeEquivalentTo(expectedResponse);

        }

    }
}

using System.Threading.Tasks;
using Xunit;
using WeatherApp.Web;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;

namespace WeatherApp.Tests.Integration
{

    public class WeatherControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {


        private readonly WebApplicationFactory<WeatherApp.Web.Startup> _factory;

        public WeatherControllerTests(WebApplicationFactory<WeatherApp.Web.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/weather?location=")]
        public async Task GetLocation_Success(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url+"london");

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("/weather?location=")]
        public async Task GetLocation_BadRequest(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }


        [Theory]
        [InlineData("/weather?location=asdfasd")]
        public async Task GetLocation_City_Not_Found(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }
    }
}

using System.Text.Json.Serialization;

namespace WeatherApp.Domain.OpenWeatherMapResponses
{
    public class Clouds
    {
        [JsonPropertyName("all")]
        public int All { get; set; }
    }


}

using System.Collections.Generic;
using System.Net;

namespace WeatherApp.Domain
{
    public class WeatherResponse
    {
        public WeatherResponse()
        {
            Message = new List<string>();
        }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
        public Temparature Temprature { get; set; }
        public string Icon { get; set; }
        public HttpStatusCode Status { get; set; }
        public List<string> Message { get; set; }

    }
}

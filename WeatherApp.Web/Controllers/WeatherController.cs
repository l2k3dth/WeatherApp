using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WeatherApp.Core.Infrastructure.Services;
using WeatherApp.Domain;
using WeatherApp.Validation;

namespace WeatherApp.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {

        private readonly IWeatherService _weatherService;

        public WeatherController(ILogger<WeatherController> logger, IWeatherService weatherService)
        {
            _weatherService = weatherService ?? throw new ArgumentNullException(nameof(weatherService));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]WeatherRequest request)
        {
            var response = await _weatherService.GetWeatherAsync(request);

            return response.Status switch
            {
                HttpStatusCode.OK => Ok(response),
                HttpStatusCode.NotFound => NotFound(new { response.Status, response.Message }),
                _ => BadRequest(new { Status = HttpStatusCode.InternalServerError, response.Message }),
            };
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WeatherApp.Domain
{
    [BindProperties]

    public class WeatherRequest
    {
        [BindProperty]
        public string Location { get; set; }
        [BindProperty]
        public bool Test { get; set; }

    }
}

using FluentValidation;
using WeatherApp.Domain;

namespace WeatherApp.Validation
{
    public class OpenWeatherMapApiSettingsValidator : AbstractValidator<OpenWeatherMapApiSettings>
    {
        public OpenWeatherMapApiSettingsValidator()
        {
            RuleFor(s => s.ApiKey).NotNull().WithMessage("Api Key is null");
            RuleFor(s => s.BaseUrl).NotNull().WithMessage("Base Url is null");

        }
    }
}

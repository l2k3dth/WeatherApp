using FluentValidation;
using System.Text.RegularExpressions;
using WeatherApp.Domain;

namespace WeatherApp.Validation
{
    public class WeatherRequestValidator : AbstractValidator<WeatherRequest>
    {
        public WeatherRequestValidator()
        {
            RuleFor(r => r.Location).NotEmpty().WithMessage("Please specify a location");
        }
    }
}

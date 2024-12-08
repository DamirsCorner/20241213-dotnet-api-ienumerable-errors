using Microsoft.AspNetCore.Mvc;

namespace ApiIenumerableErrors.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
        [
            "Freezing",
            "Bracing",
            "Chilly",
            "Cool",
            "Mild",
            "Warm",
            "Balmy",
            "Hot",
            "Sweltering",
            "Scorching"
        ];

        private static IEnumerable<WeatherForecast> GetForecasts()
        {
            return Enumerable
                .Range(1, 5)
                .Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[10] // throws IndexOutOfRangeException
                });
        }

        [HttpGet(Name = "GetWeatherForecastUnhandled")]
        [Route("unhandled")]
        public IEnumerable<WeatherForecast> GetUnhandled()
        {
            return GetForecasts();
        }

        [HttpGet(Name = "GetWeatherForecastHandled")]
        [Route("handled")]
        public IEnumerable<WeatherForecast> GetHandled()
        {
            return GetForecasts().ToArray();
        }
    }
}

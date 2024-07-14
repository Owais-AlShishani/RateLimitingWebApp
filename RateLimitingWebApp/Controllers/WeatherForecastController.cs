using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RateLimitingWebApp.Models;

namespace RateLimitingWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly IOptionsSnapshot<RateLimitingSettings> _options;

        public WeatherForecastController(IOptionsSnapshot<RateLimitingSettings> options)
        {
            _options = options;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("/GetSettings")]
        public IActionResult GetRateLimitingSettings()
        {
            return Ok(_options.Value);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Serilog;

using SorteoEstacionamientos.Shared;

namespace SorteoEstacionamientos.Server.CapaDataAccess.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(ILogger<WeatherForecastController> logger) : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger = logger;

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogInformation("Get All Data.");

            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            Log.Information("Fetch All Data {@result}.", result);
            Log.Information("Usuario: {user}", Environment.GetEnvironmentVariable("USERNAME"));

            return result;
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace cs_test.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpPost("/weather")]
    public void Create(WeatherForecast data)
    {
        Console.WriteLine(data.TemperatureC);
    }

    [HttpGet("/weather")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index =>
        {
            var Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index));
            int TemperatureC = Random.Shared.Next(-20, 55);
            string Summary = Summaries[Random.Shared.Next(Summaries.Length)];

            return new WeatherForecast
            {
                Date = Date,
                TemperatureC = TemperatureC,
                Summary = Summary
            };
        })
        .ToArray();
    }
}

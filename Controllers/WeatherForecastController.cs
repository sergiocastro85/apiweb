using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private const string Value = "Deleted weather forecast from list";
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };




    private readonly ILogger<WeatherForecastController> _logger;


    
    //coleccion estactica permite mantener datos en memoria

    private static List<WeatherForecast> ListWatherForecast=new List<WeatherForecast>();

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;

        if (ListWatherForecast==null || !ListWatherForecast.Any())
        {
            ListWatherForecast= Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
            
        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    //[Route ("Get/weatherForecast")]
    //[Route ("action")]
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogDebug("Retorno la lista de weatherforecast");
        return ListWatherForecast;
    }

    [HttpPost]
    public IActionResult Post(WeatherForecast weatherForecast)
    {
        ListWatherForecast.Add(weatherForecast);
        return Ok();
    }

    [HttpDelete("{index}")]
    public IActionResult Put(int index){
        try
        {
            ListWatherForecast.RemoveAt(index);            
        }
        catch (ArgumentOutOfRangeException)
        {            
            return BadRequest(new { msg = $"Data doesn't exist at index: { index }"});
        }

        return Ok(new {msg = "Deleted!"});
    }
}

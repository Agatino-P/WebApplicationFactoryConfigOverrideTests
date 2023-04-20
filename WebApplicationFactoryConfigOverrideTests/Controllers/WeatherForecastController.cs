using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace WebApplicationFactoryConfigOverrideTests.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IConfiguration _configuration;
    private readonly Store1 _store1;
    private readonly Store2 _store2;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration,
                                     Store1 store1, Store2 store2)
    {
        _logger = logger;
        
        _configuration = configuration;
        _store1 = store1;
        _store2 = store2;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public ActionResult Get()
    {
        _logger.LogError($"Logging from my controller {DateTime.Now.ToString("f")}");
        return Ok(_configuration["Store2"]);
    }
}

using Microsoft.AspNetCore.Mvc;
using SomeWarehouse.warehousesLogic;

namespace SomeWarehouse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IProductAddService _product;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IProductAddService product)
        {
            _logger = logger;
            _product = product;
        }

        [HttpGet]
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

        [HttpGet("getProduct")]

        public ActionResult< IEnumerable<Product>> Products()
        {
            var result = _product.Products();
            return Ok(result);
        }
    }
}

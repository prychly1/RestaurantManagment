using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Sellstorm;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly ISelectedAtributesRanking _atributes;
        private readonly IweatherForecastService _service;
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWarehouseService _collect;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IweatherForecastService service, ISelectedAtributesRanking atributes, IWarehouseService collect)
        {
            _logger = logger;
            _service = service;
            _atributes = atributes;
            _collect = collect;
        }

        //        [HttpPost]
        //        [Route("generate")]
        //        public IEnumerable<WeatherForecast> Get()
        //        {
        //            var result = _service.Get();
        //            return result;

        //        }
        //        [HttpGet]
        //        [Route("CarsDict")]

        //        public IEnumerable<SelectedAtributes> Get2()
        //        {
        //            var result2 = _atributes.Get2();
        //            return result2;
        //        }
        //        [HttpPost]

        //        public ActionResult<string> Hello([FromBody] string name)
        //        {
        //            //HttpContext.Response.StatusCode = 401;
        //            return NotFound( $"Hello {name}");
        //        }
        [HttpPost("generate")]   
        public ActionResult<IEnumerable<WeatherForecast>> Generate([FromQuery] int count, [FromBody] TemperatureRequest request)
        {
            if (count < 0 || request.Max < request.Min)
            {
                return BadRequest();
            }

            var result = _service.Get(count,request.Min,request.Max);
            return Ok(result);

        }

        [HttpPost]
        [Route("GetProdukt")]

        public ActionResult<IEnumerable<Warehouse>> Get3([FromBody]SetNewPrice price)
        {
            if ( price == null)
            {
                return BadRequest();
            }
            var result = _collect.Get3(price.getprice);
            return Ok(result);
        }
    }
}

       
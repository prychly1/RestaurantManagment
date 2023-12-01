using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Restaurant;
using System.Globalization;



namespace RestaurantAPI.Controllers
{
    [Route("api/restaurant")]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantDbContext _dbContext;
        public RestaurantController(RestaurantDbContext dbcontext )
        {
            _dbContext = dbcontext;
        }
        public ActionResult<IEnumerable<Restaurante>> GetAll()
        {
            var restaurant = _dbContext
                .Restaurants
                .ToList();
            return Ok(restaurant);
        }
    }
}

namespace RestaurantAPI.Restaurant
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;
        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "Wielkopolska Restauracja",
                    Category = "Fast Food",
                    Description = "Najtańsza restauracja w Czerniejewie",
                    ContactEmail = "restauracjawielkopolska@gmail.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "dewolaj",
                            Price = 119.50M,
                        },

                        new Dish()
                        {
                            Name = "Specjał PGR-u",
                            Price = 350.50M,
                        }
                    },

                    Address = new Address()
                    {
                        City = "Czerniejewo",
                        Street = "Długa 5",
                        PostalCode = "30-001",
                    }
                }


            };
            return restaurants;
        }
    }
}

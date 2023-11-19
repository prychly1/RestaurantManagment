namespace RestaurantAPI
{
    public class SelectedAtributesRanking : ISelectedAtributesRanking
    {
        private static readonly string[] colors = new[]
        {
            "biały", "czarny beż", "rudy", "czerwony-najszybszy"
        };
        private static readonly string[] brands = new[]
        {
            "audi", " bmw", "vw", "honda"
        };
        public IEnumerable<SelectedAtributes> Get2()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new SelectedAtributes
            {
                Brand = brands[rng.Next(brands.Length)],
                YearOfProduction = rng.Next(2000, 2023),
                color = colors[rng.Next(colors.Length)],
                price = rng.Next(100, 25000)
            })
            .ToArray();
        }
    }
}

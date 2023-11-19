using System.Data;

namespace RestaurantAPI.Sellstorm
{
    public class WarehouseService : IWarehouseService
    {
        private static readonly string[] product = new[]
        {
            "zderzak", "błotnik", "silnik", "tapicerka"
        };
        private static readonly string[] NumOfWarehouse = new[]
        {
            "A", " B", "C", "D"
        };
        public IEnumerable<Warehouse> Get3(int newPrice)
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Warehouse
            {
                Id = Guid.NewGuid(),
                numOfWarehouses = NumOfWarehouse[rng.Next(NumOfWarehouse.Length)],
                quantity = rng.Next(2000, 2023),
                products = product[rng.Next(product.Length)],
                prices = newPrice
            })
            .ToArray();
        }
    }
}

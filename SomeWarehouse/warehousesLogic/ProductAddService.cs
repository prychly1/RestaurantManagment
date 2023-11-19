using System.Security.Cryptography.X509Certificates;

namespace SomeWarehouse.warehousesLogic
{
    public class ProductAddService : IProductAddService
    {
        private static readonly string[] gotproduct = new[]
        {
            "zniszczony","sredni","do użytku","dobry","bardzo dobry", "nowy"
        };

        private static readonly string[] Warehouses = new[]
        {
            "A","B","C","D"
        };
        private static readonly string[] NamesOfProducts = new[]
        {
            "golarka","smieciarka","zamiatarka","dojarka"
        };


        public IEnumerable<Product> Products()
        {
            var rng = new Random();
            int poczatek = 1;
            int koniec = 10;
            return Enumerable.Range(1, 5).Select(r => new Product
            {
                Name = NamesOfProducts[rng.Next(NamesOfProducts.Length)],
                Description = gotproduct[rng.Next(gotproduct.Length)],
                WarehouseId = Warehouses[rng.Next(Warehouses.Length)],
                Quantity = rng.Next(poczatek, koniec)


            })
            .ToArray();
        }


    }
}

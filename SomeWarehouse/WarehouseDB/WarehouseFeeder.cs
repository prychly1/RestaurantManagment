using System.Globalization;

namespace SomeWarehouse.WarehouseDB

{
    public class WarehouseFeeder
    {
        private readonly WarehoudeDbContext _dbContext;

        public WarehouseFeeder(WarehoudeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Feed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Warehouses.Any())
                {
                    var warehouses = GetProduct();
                    _dbContext.Warehouses.AddRange(warehouses);
                    _dbContext.SaveChanges();
                }
            }

        }


        private IEnumerable<Warehouse> GetProduct()
        {
            var warehouses = new List<Warehouse>()
            {
                new Warehouse()
                {
                    Name = "engine",
                    Description = "good",
                    Address = "storage",
                    City = "london",
                    Alloy = new List<Alloy>()
                    {
                        new Alloy()
                        {
                            NumbOfAlloy = 1,
                            numOfDirect = 1,
                            Shelf = new Shelf()
                            {
                                numberOfShelf = 1,
                            }
                        }
                    }
                }
            };
            return warehouses;
        }
    }


}

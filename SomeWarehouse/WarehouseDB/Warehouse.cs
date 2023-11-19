namespace SomeWarehouse.WarehouseDB
{
    public class Warehouse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public virtual List<Alloy> Alloy { get; set;}

        public virtual Shelf Shelf { get; set;}
    }
}

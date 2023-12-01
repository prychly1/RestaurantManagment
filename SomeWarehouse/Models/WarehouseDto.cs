namespace SomeWarehouse.Models
{
    public class WarehouseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public bool HasDelivery {  get; set; }

        public int numberOfShelf { get; set; }


        public List<AlloyDto> AlloyDto { get; set; }
    }
}

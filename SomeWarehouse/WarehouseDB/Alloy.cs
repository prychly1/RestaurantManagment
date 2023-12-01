namespace SomeWarehouse.WarehouseDB
{
    public class Alloy
    {
        public int id {  get; set; }

        public int NumbOfAlloy { get; set; }

        public int numOfDirect {  get; set; }

        public virtual Shelf Shelf { get; set; }
    }
}

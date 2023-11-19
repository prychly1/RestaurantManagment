
namespace RestaurantAPI.Sellstorm
{
    public interface IWarehouseService
    {
        IEnumerable<Warehouse> Get3(int newPrice);
    }
}
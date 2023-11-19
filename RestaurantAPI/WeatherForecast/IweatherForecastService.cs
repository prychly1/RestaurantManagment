
namespace RestaurantAPI
{
    public interface IweatherForecastService
    {
        IEnumerable<WeatherForecast> Get(int count, int minTemperature, int maxTemperature);
    }
}
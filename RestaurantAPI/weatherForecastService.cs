using System.Diagnostics.Metrics;
using System.Reflection.Metadata.Ecma335;

namespace RestaurantAPI
{
    public class weatherForecastService : IweatherForecastService
    {
        
        
        private static readonly string[] Summaries = new[]
        {
            "zamarza", "troche zimno", "wiaterkowo", "Łagodny"
        };
        public IEnumerable<WeatherForecast> Get(int count, int minTemperature, int maxTemperature)
        {
            var rng = new Random();
            return Enumerable.Range(1, count).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(minTemperature, maxTemperature),
                Summary = Summaries[rng.Next(Summaries.Length)],
                

            })
            .ToArray();
        }
    }
}

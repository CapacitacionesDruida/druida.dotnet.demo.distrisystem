using druida.dotnet.shared.setup.API.Infrastructure;


namespace druida.dotnet.demo.distrisystem.order.api.Controllers
{
    /// <summary>
    /// Endpoint with information about the weather
    /// </summary>
    public class WeatherForecasts : EndpointGroupBase
    {
        /// <summary>
        /// Override map method
        /// </summary>
        /// <param name="app"></param>
        public override void Map(WebApplication app)
        {
            app.MapGroup(this)
            .MapGet(GetWeatherForecasts);
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        /// <summary>
        /// Get all information about the weather
        /// </summary>
        /// <returns></returns>
        public IEnumerable<WeatherForecast> GetWeatherForecasts()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }


    }
}

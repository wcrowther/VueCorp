
namespace coreApi;

public static partial class Endpoints
{
    public static void WeatherEndpoints(this WebApplication app)
    {
        app.MapGet("/v1/weatherforecast", () =>
        {
            var summaries = GetSummaries();

            var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
                .ToArray();

            return forecast;
        })
        .WithName("GetWeatherForecast")
        .WithOpenApi()
		.WithTags("Weather"); 
	}

	// ==============================================================================================


    private static string[] GetSummaries()
    {
        return [ "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" ];
    }

    // ==============================================================================================
}

public record WeatherForecast(DateOnly Date, int TemperatureC, string Summary)
{
	public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}


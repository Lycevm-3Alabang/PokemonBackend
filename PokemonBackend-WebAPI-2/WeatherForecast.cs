namespace PokemonBackend_WebAPI_2
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }

    public class PokemonDto
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public float? Height { get; set; }
        public float? Weight { get; set; }
        public string? ImageUrl { get; set; }
    }
}

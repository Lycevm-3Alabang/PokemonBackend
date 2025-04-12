namespace PokemonBackend_WebApi
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }

    public class Pokemon
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public string? ImageUrl { get; set; }
    }
}

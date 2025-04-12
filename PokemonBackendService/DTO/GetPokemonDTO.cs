namespace PokemonBackendApplication.DTO
{
    public record GetPokemonDTO
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
    }
}

namespace PokemonBackend_WebAPI_3
{
    public class PokemonDto
    {
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public float? Height { get; set; }
        public float? Weight { get; set; }
        public string? Type { get; set; }
    }

    // Static repository class
    public static class PokemonRepository
    {
        // Static list to hold Pokemon data
        private static readonly List<PokemonDto> PokemonList;

        // Static constructor to initialize the repository
        static PokemonRepository()
        {
            PokemonList = new List<PokemonDto>
        {
            new PokemonDto
            {
                ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/151.png",
                Name = "Mew",
                Height = 4.0f,
                Weight = 40.0f,
                Type = "Psycho"
            },
            new PokemonDto
            {
                ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/1.png",
                Name = "Bulbasaur",
                Height = 0.7f,
                Weight = 6.9f,
                Type = "Grass/Poison"
            },
            new PokemonDto
            {
                ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/4.png",
                Name = "Charmander",
                Height = 0.6f,
                Weight = 8.5f,
                Type = "Fire"
            },
            new PokemonDto
            {
                ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/7.png",
                Name = "Squirtle",
                Height = 0.5f,
                Weight = 9.0f,
                Type = "Water"
            },
            new PokemonDto
            {
                ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/25.png",
                Name = "Pikachu",
                Height = 0.4f,
                Weight = 6.0f,
                Type = "Electric"
            }
        };
        }

        // Method to retrieve all Pokemon
        public static List<PokemonDto> GetAllPokemons()
        {
            return PokemonList;
        }

        public static void AddPokemon(PokemonDto dto)
        {
            PokemonList.Add(dto);
        }
    }

}

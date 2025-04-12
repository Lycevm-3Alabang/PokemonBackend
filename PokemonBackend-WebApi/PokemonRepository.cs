namespace PokemonBackend_WebApi
{
    public class PokemonRepository
    {
        private static List<Pokemon> _pokemons = new List<Pokemon>();

        public static void Initialize()
        {
            _pokemons.Add(new Pokemon
            {
                Name = "Pikachu",
                Type = "Meralco",
                Height = 0.4f,
                Weight = 6.0f,
                ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/25.png"
            });
            _pokemons.Add(new Pokemon
            {
                Name = "Bulbasaur",
                Type = "Grass",
                Height = 0.7f,
                Weight = 6.9f,
                ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/1.png"
            });
        }

        public static List<Pokemon> GetPokemonList()
        {
            if(_pokemons == null || _pokemons.Count() == 0) {
                Initialize();
            }
            return _pokemons;
        }

        public static void AddPokemon(Pokemon pokemon)
        {
            _pokemons.Add(pokemon);
        }
    }
}

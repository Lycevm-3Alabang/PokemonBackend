using PokemonBackendApplication.DTO;
using PokemonBackendApplication.Interfaces;

namespace PokemonBackendListOnly
{
    public class AlmostAPokemon
    {
        public string? Key { get; set; }
        public string? Description { get; set; }
    }
    public class ListPokemonRepository : IPokemonRepository
    {
        private static List<AlmostAPokemon> _pokemons = new List<AlmostAPokemon>()
    {
        new AlmostAPokemon { Key = "1", Description = "Pikachu" },
        new AlmostAPokemon { Key = "2", Description = "Charmander" },
        new AlmostAPokemon { Key = "3", Description = "Bulbasaur" },
        new AlmostAPokemon { Key = "4", Description = "Squirtle" }
    };




        public async Task<GetPokemonDTO> AddPokemonAsync(AddPokemonDTO pokemon)
        {
           var lastKey = _pokemons.Select(p => int.Parse(p.Key)).Max();

           var newKey = lastKey + 1;

            var newPokemon = new AlmostAPokemon
            {
                Key = newKey.ToString(),
                Description = pokemon.Name
            };
            _pokemons.Add(newPokemon);

            return new GetPokemonDTO
            {
                Id = newKey,
                Name = pokemon.Name
            };

        }

        public async Task<bool> DeletePokemonAsync(int id)
        {
            try
            {
                var pokemonToDelete = _pokemons.FirstOrDefault(p => int.Parse(p.Key) == id);
                if (pokemonToDelete != null)
                {
                    _pokemons.Remove(pokemonToDelete);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Handle exception
                return false;
            }
        }

        public async Task<GetPokemonDTO> GetPokemonByIdAsync(int id)
        {
            return _pokemons
                .Where(p => int.Parse(p.Key) == id)
                .Select(x => new GetPokemonDTO
                {
                    Id = int.Parse(x.Key),
                    Name = x.Description
                })
                .FirstOrDefault();
        }

        public async Task<GetPokemonDTO> GetPokemonByNameAsync(string name)
        {
            return _pokemons
                .Where(p => p.Description == name)
                .Select(x => new GetPokemonDTO
                {
                    Id = int.Parse(x.Key),
                    Name = x.Description
                })
                .FirstOrDefault();
        }

        public async Task<IEnumerable<GetPokemonDTO>> GetPokemonsAsync()
        {
            return _pokemons.Select(x => new GetPokemonDTO
            {
                Id = int.Parse(x.Key),
                Name = x.Description
            });
        }

        public async Task<GetPokemonDTO> UpdatePokemonAsync(UpdatePokemonDTO pokemon)
        {
            var existingPokemon = _pokemons.FirstOrDefault(p => p.Key == pokemon.Id.ToString());
            if (existingPokemon != null)
            {
                existingPokemon.Description = pokemon.Name;
                return new GetPokemonDTO
                {
                    Id = int.Parse(existingPokemon.Key),
                    Name = existingPokemon.Description
                };
            }
            else
            {
                throw new Exception("Pokemon not found");
            }
        }
    }
}

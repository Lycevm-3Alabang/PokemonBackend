using PokemonBackendApplication.DTO;

namespace PokemonBackendApplication.Interfaces
{
    public interface IPokemonRepository
    {
        Task<GetPokemonDTO> GetPokemonByIdAsync(int id);
        Task<GetPokemonDTO> GetPokemonByNameAsync(string name);
        Task<IEnumerable<GetPokemonDTO>> GetPokemonsAsync();
        Task<GetPokemonDTO> AddPokemonAsync(AddPokemonDTO pokemon);
        Task<GetPokemonDTO> UpdatePokemonAsync(UpdatePokemonDTO pokemon);
        Task<bool> DeletePokemonAsync(int id);
    }
}
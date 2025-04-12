using Microsoft.EntityFrameworkCore;
using PokemonBackendApplication.DTO;
using PokemonBackendApplication.Interfaces;
using PokemonBackendEFCore.Data;

namespace PokemonBackendEFCore
{
    public class DbContextRepository : IPokemonRepository
    {
        private PokemonDbContext _context;
        public DbContextRepository(PokemonDbContext context)
        {
            _context = context;
        }

        public async Task<GetPokemonDTO> AddPokemonAsync(AddPokemonDTO dto)
        {
            
            var pokemon = new Pokemon
            {
                Name = dto.Name
            };
            _context.Pokemon.Add(pokemon);
            await _context.SaveChangesAsync();


            return await GetPokemonByIdAsync(pokemon.Id.Value);
        }

        public Task<bool> DeletePokemonAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<GetPokemonDTO> GetPokemonByIdAsync(int id)
        {
            var result = await _context.Pokemon
              .Where(p => p.Id == id)
              .FirstOrDefaultAsync();

            return new GetPokemonDTO
            {
                Id = result.Id,
                Name = result.Name
            };
        }

        public Task<GetPokemonDTO> GetPokemonByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetPokemonDTO>> GetPokemonsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<GetPokemonDTO> UpdatePokemonAsync(UpdatePokemonDTO pokemon)
        {
            //find the pokemon
            var toEdit = await _context.Pokemon
                .FirstOrDefaultAsync(p => p.Id == pokemon.Id);
            if (toEdit != null)
            {
                toEdit.Name = pokemon.Name;
                await _context.SaveChangesAsync();
            }

            return await GetPokemonByIdAsync(pokemon.Id.Value);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PokemonBackendApplication.DTO;
using PokemonBackendApplication.Interfaces;

namespace PokemonBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonsController : ControllerBase
    {
        // Our repository dependency—because even our Pokémon need somewhere to hang out.
        private IPokemonRepository _pokemonRepository;

        public PokemonsController(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        // GET: api/Pokemons
        // Fetch all the Pokémon. Because apparently, you really want to see them all.
        [HttpGet]
        public async Task<IActionResult> GetPokemons()
        {
            var pokemons = await _pokemonRepository.GetPokemonsAsync();
            return Ok(pokemons);
        }

        // GET: api/Pokemons/{id}
        // Fetch a single Pokémon by ID. Try to remember which one you're after.
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPokemonByIdAsync(int id)
        {
            var pokemon = await _pokemonRepository.GetPokemonByIdAsync(id);
            if (pokemon == null)
            {
                // Nothing to see here; the Pokémon apparently doesn't exist.
                return NoContent();
            }
            return Ok(pokemon);
        }

        // POST: api/Pokemons
        // Add a new Pokémon. Just a name is enough—leave the ID wizardry to the API.
        [HttpPost]
        public async Task<IActionResult> AddPokemon([FromBody] AddPokemonDTO pokemon)
        {
            if (pokemon == null)
            {
                return BadRequest("Invalid data.");
            }

            // Because some things are simply not allowed:
            if (pokemon.Name.ToLower() == "pikachu")
            {
                ModelState.AddModelError("Name", "Pikachu is not allowed.");
            }

            if (!ModelState.IsValid)
            {
                // If your data (or your logic) isn't valid, here's your error list.
                return BadRequest(ModelState);
            }

            // Create the new Pokémon and marvel at the magic.
            var createdPokemon = await _pokemonRepository.AddPokemonAsync(pokemon);
            return CreatedAtAction(nameof(GetPokemons), new { id = createdPokemon.Id }, createdPokemon);
        }

        // PUT: api/Pokemons/{id}
        // Update an existing Pokémon.
        // Note: The ID in the URL must match the ID provided in the body. Shocking, right?
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePokemon(int id, [FromBody] UpdatePokemonDTO pokemon)
        {
            if (pokemon == null || id != pokemon.Id)
            {
                return BadRequest("Invalid data.");
            }

            var updatedPokemon = await _pokemonRepository.UpdatePokemonAsync(pokemon);
            if (updatedPokemon == null)
            {
                // Oops—couldn't update what's not there.
                return NotFound();
            }
            // Update succeeded but there's nothing to send back, so enjoy the silence.
            return NoContent();
        }

        // DELETE: api/Pokemons/{id}
        // Delete a Pokémon. It disappears, like it was never even here.
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletePokemon(int id)
        {
            var result = await _pokemonRepository.DeletePokemonAsync(id);
            if (result)
            {
                // Success: the Pokémon is gone, and we return nothing—a mystery wrapped in silence.
                return NoContent();
            }
            // If we can't find the Pokémon to delete, then clearly it never existed.
            return NotFound();
        }
    }
}
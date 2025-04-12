using Microsoft.AspNetCore.Mvc;
using PokemonBackendApplication.DTO;
using PokemonBackendApplication.Interfaces;

namespace PokemonBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonsController : ControllerBase
    {
         private IPokemonRepository _pokemonRepository;
        public PokemonsController(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        // GET: api/Pokemons    
        [HttpGet]
        public async Task<IActionResult> GetPokemons()
        {
            return Ok(await _pokemonRepository.GetPokemonsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddPokemon([FromBody] AddPokemonDTO pokemon)
        {
            if (pokemon == null)
            {
                return BadRequest("Invalid data.");
            }

            if(pokemon.Name == "pikachu")
            {
                ModelState.AddModelError("Name", "Pikachu is not allowed.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var createdPokemon = await _pokemonRepository.AddPokemonAsync(pokemon);
            return CreatedAtAction(nameof(GetPokemons), new { id = createdPokemon.Id }, createdPokemon);
        }

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
                return NotFound();
            }
            return NoContent();
        }
    }
}

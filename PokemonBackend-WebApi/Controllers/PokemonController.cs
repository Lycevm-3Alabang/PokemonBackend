using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PokemonBackend_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {

        public PokemonController()
        {
            PokemonRepository.Initialize();

        }

        [HttpGet]
        [Route("get-all")]
        public IActionResult Get()
        {
            return Ok(PokemonRepository.GetPokemonList());
        }
        [HttpGet]
        [Route("get-by-type")]
        public IActionResult GetByType(string? type)
        {
            return Ok(); //should return all pokemon of the same type of 'type'
        }
        [HttpGet]
        public IActionResult Get(string? name)
        {
            if (name == null) return Ok("not okay!");
            var result = PokemonRepository.GetPokemonList()
                .Where(x => name.ToLower() == x.Name.ToLower())
                .SingleOrDefault();

            if (result != null) return Ok(result);

            return NoContent();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pokemon pokemon)
        {
            PokemonRepository.AddPokemon(pokemon);
            return Created();
        }

    }
}

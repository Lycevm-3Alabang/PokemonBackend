using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PokemonBackend_WebAPI_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private static List<PokemonDto> _pokemons = new();

        public PokemonController()
        {
           
        }

        [HttpGet]
        public IActionResult Get(string? name)
        {
            var pokemon = _pokemons.Where(i => i.Name.ToLower() == name.ToLower()).SingleOrDefault();
            return Ok(pokemon);
        }

        [HttpGet]
        [Route("get-all")]
        public IActionResult GetAll()
        {
            return Ok(_pokemons);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PokemonDto pokemon) {
            if (pokemon == null) return BadRequest("null imong pokemon");

            _pokemons.Add(pokemon);

            return Created();
        }

    }
}

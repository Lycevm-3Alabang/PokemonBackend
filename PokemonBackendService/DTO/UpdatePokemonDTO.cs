using System.ComponentModel.DataAnnotations;

namespace PokemonBackendApplication.DTO
{

    public record UpdatePokemonDTO
    {
        [Required]
        public int? Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}

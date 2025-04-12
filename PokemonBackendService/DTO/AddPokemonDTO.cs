using System.ComponentModel.DataAnnotations;

namespace PokemonBackendApplication.DTO
{
    public record AddPokemonDTO
    {
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace PokemonDbBackend.Data
{
    public class PokemonType
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace PokemonDbBackend.Data
{
    public class Pokemon
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        
    }
}

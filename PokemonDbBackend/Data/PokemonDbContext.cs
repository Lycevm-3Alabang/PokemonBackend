using Microsoft.EntityFrameworkCore;

namespace PokemonDbBackend.Data
{
    public class PokemonDbContext : DbContext
    {
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<PokemonType> PokemonType { get; set; }

        public PokemonDbContext(DbContextOptions<PokemonDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Pokemon>().ToTable("pokemon");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PokemonBackendApplication.Interfaces;
using PokemonBackendEFCore.Data;

namespace PokemonBackendEFCore;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddPokemonBackendEFCore(this IServiceCollection services, string? connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentNullException(nameof(connectionString), "Connection string cannot be null or empty.");
        }
  
        services.AddDbContext<PokemonDbContext>(options =>
            options.UseSqlServer(connectionString)); // Ensure Microsoft.EntityFrameworkCore.SqlServer is referenced
        services.AddScoped<IPokemonRepository, DbContextRepository>();
        return services;
    }
}
      

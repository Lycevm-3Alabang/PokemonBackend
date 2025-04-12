using Microsoft.Extensions.DependencyInjection;
using PokemonBackendApplication.Interfaces;
using PokemonBackendListOnly;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddListPokemonRepository(this IServiceCollection services)
    {
        services.AddScoped<IPokemonRepository, ListPokemonRepository>();
        return services;
    }
}
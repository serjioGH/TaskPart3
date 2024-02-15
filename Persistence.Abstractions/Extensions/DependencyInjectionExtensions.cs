namespace Persistence.Abstractions.Repositories;

using Microsoft.Extensions.DependencyInjection;
using Persistence.Abstractions.Interfaces;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddGenericRepository(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        return services;
    }
}
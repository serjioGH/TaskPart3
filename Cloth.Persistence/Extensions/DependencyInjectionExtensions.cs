namespace Cloth.Persistence.Extensions;

using Cloth.Application.Interfaces;
using Cloth.Persistence.Ef.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection RegisterPersistenceDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterEfPersistence(configuration);
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
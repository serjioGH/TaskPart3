namespace Cloth.Infrastructure.Extensions;

using Cloth.Application.Interfaces;
using Cloth.Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration == null)
        {
            throw new ArgumentNullException(nameof(configuration));
        }

        services.Configure<MockyHttpConfiguration>(configuration.GetSection("MockyClient"));
        services.AddHttpClient<MockyHttpServiceClient>();
        services.AddScoped<IMockyHttpServiceClient, MockyHttpServiceClient>();

        return services;
    }
}
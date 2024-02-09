namespace Cloth.Persistence.Ef.Extensions;

using Cloth.Application.Interfaces;
using Cloth.Application.Services;
using Microsoft.EntityFrameworkCore;
using Cloth.Persistence.Ef.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Cloth.Infrastructure.Configuration;
using Cloth.Infrastructure;
using Cloth.Persistence.Ef.Repositories;

public static class DependencyInjectionExtension
{
    public static IServiceCollection RegisterEfPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration == null)
        {
            throw new ArgumentNullException(nameof(configuration));
        }

        services.AddDbContext<DbContext, ClothInventoryDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ClothInventoryDbConnection")));
        services.Configure<MockyHttpConfiguration>(configuration.GetSection("MockyClient"));
        services.AddScoped<IClothRepository, ClothRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<ISizeRepository, SizeRepository>();
        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<IClothService, ClothService>();
        services.AddHttpClient<MockyHttpServiceClient>();
        services.AddScoped<IMockyHttpServiceClient, MockyHttpServiceClient>();

        return services;
    }
}

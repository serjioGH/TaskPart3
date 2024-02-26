namespace Cloth.Persistence.Ef.Extensions;

using Cloth.Application.Interfaces;
using Cloth.Application.Interfaces.Repositories;
using Cloth.Infrastructure;
using Cloth.Infrastructure.Configuration;
using Cloth.Persistence.Ef.Context;
using Cloth.Persistence.Ef.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjectionExtension
{
    public static IServiceCollection RegisterEfPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration == null)
        {
            throw new ArgumentNullException(nameof(configuration));
        }

        services.AddDbContext<DbContext, ClothInventoryDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ClothInventoryDbConnection")));
        services.Configure<MockyHttpConfiguration>(configuration.GetSection("MockyClient"));
        services.AddScoped<IClothRepository, ClothRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IBasketRepository, BasketRepository>();
        services.AddScoped<IBasketLineRepository, BasketLineRepository>();
        services.AddScoped<ISizeRepository, SizeRepository>();
        services.AddScoped<IClothSizeRepository, ClothSizeRepository>();
        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddHttpClient<MockyHttpServiceClient>();
        services.AddScoped<IMockyHttpServiceClient, MockyHttpServiceClient>();

        return services;
    }
}
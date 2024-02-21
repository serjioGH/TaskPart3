namespace Cloth.Application.Extensions;

using Cloth.Application.Behavior;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}
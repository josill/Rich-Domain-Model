using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace RichDomainModel.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssembly(typeof(DependencyInjection)
                    .Assembly); // Automatically inject all commands and queries
            });
            // .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
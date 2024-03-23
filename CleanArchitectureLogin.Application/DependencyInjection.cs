using CleanArchitectureLogin.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureLogin.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly,
                typeof(AppUser).Assembly);

        });
        return services;
    }
}

using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Bootcamp.Application;

public static class Installer
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
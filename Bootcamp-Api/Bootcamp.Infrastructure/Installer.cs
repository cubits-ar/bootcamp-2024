using Bootcamp.Domain.Interfaces;
using Bootcamp.Infrastructure.Database;
using Bootcamp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bootcamp.Infrastructure;

public static class Installer
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SqlServerDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Default"));
        });

        services.AddScoped<IUserRepository, UserRepository>();
    }
}
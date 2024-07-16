using Bootcamp.Infrastructure.Database.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp.Infrastructure.Database;

public class SqlServerDbContext : DbContext
{
    public SqlServerDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}
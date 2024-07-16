using Bootcamp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bootcamp.Infrastructure.Database.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("usuarios");

        builder.HasKey(user => user.Id);

        builder.Property(user => user.Id)
            .HasColumnName("id_usuario");

        builder.Property(user => user.Name)
            .HasColumnName("nombre");

        builder.Property(user => user.RoleId)
            .HasColumnName("id_role");

        builder.HasOne(user => user.Role)
            .WithMany()
            .HasForeignKey(user => user.RoleId);
    }
}
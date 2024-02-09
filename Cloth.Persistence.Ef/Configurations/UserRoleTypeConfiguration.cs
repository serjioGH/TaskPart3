namespace Cloth.Persistence.Ef.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Cloth.Domain.Entities;

public class UserRoleTypeConfiguration : IEntityTypeConfiguration<UserRoles>
{
    public void Configure(EntityTypeBuilder<UserRoles> builder)
    {
        builder.HasKey(p => new { p.UserId, p.RoleId });

        builder.HasOne(p => p.User)
            .WithMany(p => p.UserRoles)
            .HasForeignKey(p => p.UserId);

        builder.HasOne(p => p.Role)
            .WithMany(g => g.UserRoles)
            .HasForeignKey(p => p.RoleId);
    }
}

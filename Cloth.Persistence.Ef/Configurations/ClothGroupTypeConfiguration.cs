namespace Cloth.Persistence.Ef.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Cloth.Domain.Entities;

public class ClothGroupTypeConfiguration : IEntityTypeConfiguration<ClothGroup>
{
    public void Configure(EntityTypeBuilder<ClothGroup> builder)
    {
        builder.HasKey(p => new { p.ClothId, p.GroupId });

        builder.HasOne(p => p.Cloth)
            .WithMany(p => p.ClothGroups)
            .HasForeignKey(p => p.ClothId);

        builder.HasOne(p => p.Group)
            .WithMany(g => g.ClothGroups)
            .HasForeignKey(p => p.GroupId);
    }
}

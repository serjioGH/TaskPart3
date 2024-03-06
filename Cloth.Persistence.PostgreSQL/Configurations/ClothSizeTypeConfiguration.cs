namespace Cloth.Persistence.PostgreSQL.Configurations;

using Cloth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ClothSizeTypeConfiguration : IEntityTypeConfiguration<ClothSize>
{
    public void Configure(EntityTypeBuilder<ClothSize> builder)
    {
        builder.HasKey(p => new { p.ClothId, p.SizeId });

        builder.HasOne(p => p.Cloth)
            .WithMany(p => p.ClothSizes)
            .HasForeignKey(p => p.ClothId);

        builder.HasOne(p => p.Size)
            .WithMany(s => s.ClothSizes)
            .HasForeignKey(p => p.SizeId);
    }
}
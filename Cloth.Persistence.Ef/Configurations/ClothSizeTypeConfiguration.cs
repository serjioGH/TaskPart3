namespace Cloth.Persistence.Ef.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Cloth.Domain.Entities;
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

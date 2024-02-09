using Cloth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cloth.Persistence.Ef.Configurations;

public class BasketLineTypeConfiguration : IEntityTypeConfiguration<BasketLine>
{
    public void Configure(EntityTypeBuilder<BasketLine> builder)
    {
        builder.HasKey(p => new { p.BasketId, p.ClothId });

        builder.HasOne(p => p.Cloth)
            .WithMany(p => p.BasketLines)
            .HasForeignKey(p => p.ClothId);

        builder.HasOne(p => p.Size)
            .WithMany(s => s.BasketLines)
            .HasForeignKey(p => p.SizeId);

        builder.HasOne(p => p.Basket)
            .WithMany(g => g.BasketLines)
            .HasForeignKey(p => p.BasketId);

        builder.Property(p => p.Price)
            .HasColumnType("decimal(18, 2)");
    }
}

using Cloth.Domain.Entities;
using Cloth.Persistence.Ef.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cloth.Persistence.Ef.Configurations;

public class BasketLineTypeConfiguration : IEntityTypeConfiguration<BasketLine>
{
    public void Configure(EntityTypeBuilder<BasketLine> builder)
    {
        builder.HasKey(p => p.Id);
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
            .HasColumnType(ConfigurationConstants.DecimalTypeNpgsql);
    }
}
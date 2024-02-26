namespace Cloth.Persistence.Ef.Configurations;

using Cloth.Domain.Entities;
using Cloth.Persistence.Ef.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OrderLinesTypeConfiguration : IEntityTypeConfiguration<OrderLines>
{
    public void Configure(EntityTypeBuilder<OrderLines> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasOne(p => p.Order)
            .WithMany(p => p.OrderLines)
            .HasForeignKey(p => p.OrderId);
        builder.HasOne(p => p.Size)
            .WithMany(s => s.OrderLines)
            .HasForeignKey(p => p.SizeId);
        builder.HasOne(p => p.Cloth)
            .WithMany(p => p.OrderDetails)
            .HasForeignKey(p => p.ClothId);
        builder.Property(p => p.Price)
            .HasColumnType(ConfigurationConstants.DecimalType);
    }
}
namespace Cloth.Persistence.Ef.Configurations;

using Cloth.Domain.Entities;
using Cloth.Persistence.Ef.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OrderStatusTypeConfiguration : IEntityTypeConfiguration<OrderStatus>
{
    public void Configure(EntityTypeBuilder<OrderStatus> builder)
    {
        builder.Property(p => p.Name).HasColumnType(ConfigurationConstants.NvarcharType);
    }
}
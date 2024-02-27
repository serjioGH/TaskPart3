namespace Cloth.Persistence.Ef.Configurations;

using Cloth.Domain.Entities;
using Cloth.Persistence.Ef.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PaymentTypeConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.Property(p => p.PaymentMethod).HasColumnType(ConfigurationConstants.VarcharType);
    }
}
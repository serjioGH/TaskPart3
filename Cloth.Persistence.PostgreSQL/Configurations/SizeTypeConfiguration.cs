namespace Cloth.Persistence.PostgreSQL.Configurations;

using Cloth.Domain.Entities;
using Cloth.Persistence.PostgreSQL.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SizeTypeConfiguration : IEntityTypeConfiguration<Size>
{
    public void Configure(EntityTypeBuilder<Size> builder)
    {
        builder.Property(p => p.Name).HasColumnType(ConfigurationConstants.VarcharType);
    }
}
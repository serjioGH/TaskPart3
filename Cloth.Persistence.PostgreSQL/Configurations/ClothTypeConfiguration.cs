namespace Cloth.Persistence.PostgreSQL.Configurations;

using Cloth.Domain.Entities;
using Cloth.Persistence.PostgreSQL.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ClothTypeConfiguration : IEntityTypeConfiguration<Cloth>
{
    public void Configure(EntityTypeBuilder<Cloth> builder)
    {
        builder.Property(p => p.CreatedOn)
               .HasColumnType(ConfigurationConstants.DateColumnTypeNpgsql)
               .HasDefaultValueSql(ConfigurationConstants.GetdateTypeNpgsql);

        builder.HasOne(p => p.Brand)
          .WithMany(s => s.Cloths)
          .HasForeignKey(p => p.BrandId);

        builder.Property(p => p.IsDeleted)
           .HasDefaultValue(false);

        builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Description)
            .HasColumnType("text");

        builder.Property(p => p.Price)
            .HasColumnType(ConfigurationConstants.DecimalTypeNpgsql);
    }
}
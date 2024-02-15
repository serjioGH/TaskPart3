namespace Cloth.Persistence.Ef.Configurations;

using Cloth.Domain.Entities;
using Cloth.Persistence.Ef.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ClothTypeConfiguration : IEntityTypeConfiguration<Cloth>
{
    public void Configure(EntityTypeBuilder<Cloth> builder)
    {
        builder.Property(p => p.CreatedOn)
          .HasDefaultValueSql("getDate()");

        builder.HasOne(p => p.Brand)
          .WithMany(s => s.Cloths)
          .HasForeignKey(p => p.BrandId);

        builder.Property(p => p.IsDeleted)
           .HasColumnType("bit")
           .HasDefaultValue(false);

        builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Description)
            .HasColumnType("text");

        builder.Property(p => p.Price)
            .HasColumnType(ConfigurationConstants.DecimalType);
    }
}
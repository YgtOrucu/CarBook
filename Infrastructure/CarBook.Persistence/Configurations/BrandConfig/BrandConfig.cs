using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarBook.Persistence.Configurations.BrandConfig;
public class BrandConfig : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.Name).HasMaxLength(100).IsRequired(false);

        builder.HasMany(x => x.Cars)
               .WithOne(x => x.Brand)
               .HasForeignKey(x => x.BrandId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarBook.Persistence.Configurations.CarConfig;

public class CarConfig : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.Model).HasMaxLength(100).IsRequired(false);
        builder.Property(x => x.CoverImageUrl).HasColumnType("varchar(500)").IsRequired(false);

        builder.Property(x => x.Fuel).HasMaxLength(50).IsRequired(false);
        builder.Property(x => x.BigImageUrl).HasColumnType("varchar(500)").IsRequired(false);

        builder.HasOne(x => x.Brand)
               .WithMany(x => x.Cars)
               .HasForeignKey(x => x.BrandId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.CarDescription)
               .WithOne(x => x.Car)
               .HasForeignKey<CarDescription>(x => x.CarId)
               .OnDelete(DeleteBehavior.Cascade);
    }

}

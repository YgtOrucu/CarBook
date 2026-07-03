using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarBook.Persistence.Configurations.CarPricingConfig;

public class CarPricingConfig : IEntityTypeConfiguration<CarPricing>
{
    public void Configure(EntityTypeBuilder<CarPricing> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.Amount).HasColumnType("decimal(18,2)");

        builder.HasOne(x => x.Car)
               .WithMany(x => x.CarPricings)
               .HasForeignKey(x => x.CarId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Pricing)
               .WithMany(x => x.CarPricings)
               .HasForeignKey(x => x.PricingId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}

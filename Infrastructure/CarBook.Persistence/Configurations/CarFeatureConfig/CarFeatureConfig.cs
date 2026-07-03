using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarBook.Persistence.Configurations.CarFeatureConfig;

public class CarFeatureConfig : IEntityTypeConfiguration<CarFeature>
{
    public void Configure(EntityTypeBuilder<CarFeature> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.HasOne(x => x.Car)
               .WithMany(x => x.CarFeatures)
               .HasForeignKey(x => x.CarId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Feature)
               .WithMany(x => x.CarFeatures)
               .HasForeignKey(x => x.FeatureId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}

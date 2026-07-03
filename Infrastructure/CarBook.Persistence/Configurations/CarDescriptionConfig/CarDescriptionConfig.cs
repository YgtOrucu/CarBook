using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarBook.Persistence.Configurations.CarDescriptionConfig;

public class CarDescriptionConfig : IEntityTypeConfiguration<CarDescription>
{
    public void Configure(EntityTypeBuilder<CarDescription> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.Details).HasColumnType("nvarchar(max)").IsRequired(false);
    }
}

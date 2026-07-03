using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarBook.Persistence.Configurations.CarDetailsConfig;

public class CarDetailsConfig : IEntityTypeConfiguration<CarDetails>
{
    public void Configure(EntityTypeBuilder<CarDetails> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.Fuel).HasMaxLength(50).IsRequired(false);
        builder.Property(x => x.BigImageUrl).HasColumnType("varchar(500)").IsRequired(false);
    }
}

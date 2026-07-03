using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarBook.Persistence.Configurations.FooterAddressConfig;

public class FooterAddressConfig : IEntityTypeConfiguration<FooterAddress>
{
    public void Configure(EntityTypeBuilder<FooterAddress> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.Description).HasMaxLength(500).IsRequired(false);
        builder.Property(x => x.Address).HasMaxLength(250).IsRequired(false);
        builder.Property(x => x.Phone).HasColumnType("varchar(50)").IsRequired(false);
        builder.Property(x => x.Email).HasColumnType("varchar(100)").IsRequired(false);
    }
}

using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarBook.Persistence.Configurations.ServiceConfig;

public class ServiceConfig : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.Title).HasMaxLength(150).IsRequired(false);
        builder.Property(x => x.Description).HasMaxLength(500).IsRequired(false);
        builder.Property(x => x.IconUrl).HasColumnType("varchar(250)").IsRequired(false);
    }
}

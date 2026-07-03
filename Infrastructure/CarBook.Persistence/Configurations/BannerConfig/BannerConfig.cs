using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarBook.Persistence.Configurations.BannerConfig;

public class BannerConfig : IEntityTypeConfiguration<Banner>
{
    public void Configure(EntityTypeBuilder<Banner> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.Title).HasMaxLength(150).IsRequired(false);
        builder.Property(x => x.Description).HasMaxLength(500).IsRequired(false);
        builder.Property(x => x.VideoUrl).HasColumnType("varchar(500)").IsRequired(false);
    }
}

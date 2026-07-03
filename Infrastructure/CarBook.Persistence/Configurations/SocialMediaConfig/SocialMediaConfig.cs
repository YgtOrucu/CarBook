using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarBook.Persistence.Configurations.SocialMediaConfig;

public class SocialMediaConfig : IEntityTypeConfiguration<SocialMedia>
{
    public void Configure(EntityTypeBuilder<SocialMedia> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.Name).HasMaxLength(50).IsRequired(false);
        builder.Property(x => x.Icon).HasColumnType("varchar(100)").IsRequired(false);
        builder.Property(x => x.Url).HasColumnType("varchar(250)").IsRequired(false);
    }
}

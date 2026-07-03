using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CarBook.Persistence.Configurations.AboutConfig;
public class AboutConfig : IEntityTypeConfiguration<About>
{
    public void Configure(EntityTypeBuilder<About> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.Title).HasMaxLength(150).IsRequired(false);
        builder.Property(x => x.Description).HasMaxLength(1000).IsRequired(false);
        builder.Property(x => x.ImageUrl).HasColumnType("varchar(500)").IsRequired(false);
    }
}

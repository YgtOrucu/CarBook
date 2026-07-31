using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarBook.Persistence.Configurations.TagConfig;

public class TagConfig : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.TagName).HasColumnType("varchar(70)");

        builder
            .HasMany(x => x.Blogs)
            .WithMany(x => x.Tags)
            .UsingEntity<Dictionary<string, object>>
            (
                "BlogTag",
                y => y.HasOne<Blog>().WithMany().HasForeignKey("BlogId"),
                y => y.HasOne<Tag>().WithMany().HasForeignKey("TagId")
            );
    }
}

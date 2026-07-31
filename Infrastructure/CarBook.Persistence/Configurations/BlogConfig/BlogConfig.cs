using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarBook.Persistence.Configurations.BlogConfig;

public class BlogConfig : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(x => x.Title).HasMaxLength(150).IsRequired(false);
        builder.Property(x => x.CoverImageUrl).HasMaxLength(500).IsRequired(false);

        builder.HasOne(x => x.Author)
            .WithMany(x => x.Blogs)
            .HasForeignKey(x => x.AuthorId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.Category)
            .WithMany(x => x.Blogs)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.BlogDetail)
            .WithOne(x => x.Blog)
            .HasForeignKey<BlogDetail>(x => x.BlogId)
            .OnDelete(DeleteBehavior.Cascade);    
    }
}

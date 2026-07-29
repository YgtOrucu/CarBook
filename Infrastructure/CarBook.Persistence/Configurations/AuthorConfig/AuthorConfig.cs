using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarBook.Persistence.Configurations.AuthorConfig;

public class AuthorConfig : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).UseIdentityColumn();
        builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
        builder.Property(a => a.ImageUrl).HasMaxLength(500);
        builder.Property(a => a.Description).HasMaxLength(1000);
    }
}

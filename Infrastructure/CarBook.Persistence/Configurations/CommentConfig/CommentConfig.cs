using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarBook.Persistence.Configurations.CommentConfig;

public class CommentConfig : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x=> x.NameSurname).HasColumnType("nvarchar(100)").IsRequired(true);
        builder.Property(x=> x.MessageBody).HasColumnType("nvarchar(700)").IsRequired(true);
        builder.Property(x => x.ImageUrl).HasColumnType("nvarchar(300)").IsRequired(false);

        builder.HasOne(x=>x.Blog)
            .WithMany(x=>x.Comments)
            .HasForeignKey(x=>x.BlogId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}

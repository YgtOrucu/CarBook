using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarBook.Persistence.Configurations.BlogDetailConfig;

public class BlogDetailConfig : IEntityTypeConfiguration<BlogDetail>
{
    public void Configure(EntityTypeBuilder<BlogDetail> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.MainTitle).HasColumnType("varchar(50)");
        builder.Property(x => x.MainDescription).HasColumnType("nvarchar(700)");
        builder.Property(x => x.SecondTitle).HasColumnType("varchar(50)");
        builder.Property(x => x.SecondDescription).HasColumnType("nvarchar(2000)");
    }
}

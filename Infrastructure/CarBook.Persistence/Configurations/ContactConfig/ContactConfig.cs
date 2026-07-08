using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarBook.Persistence.Configurations.ContactConfig;

public class ContactConfig : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.Name).HasMaxLength(100).IsRequired(false);
        builder.Property(x => x.Email).HasColumnType("varchar(100)").IsRequired(false);
        builder.Property(x => x.Subject).HasMaxLength(150).IsRequired(false);
        builder.Property(x => x.Message).HasMaxLength(2000).IsRequired(false);
    }
}

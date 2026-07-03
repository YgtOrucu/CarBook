using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarBook.Persistence.Configurations.TestimonialConfig;

public class TestimonialConfig : IEntityTypeConfiguration<Testimonial>
{
    public void Configure(EntityTypeBuilder<Testimonial> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.Name).HasMaxLength(100).IsRequired(false);
        builder.Property(x => x.Title).HasMaxLength(100).IsRequired(false);
        builder.Property(x => x.Comment).HasMaxLength(1000).IsRequired(false);
        builder.Property(x => x.ImageUrl).HasColumnType("varchar(500)").IsRequired(false);
    }
}

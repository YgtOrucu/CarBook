using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarBook.Persistence.Configurations.ReservationConfig;

public class ReservationConfig : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.FullName).HasColumnType("varchar(50)");
        builder.Property(x => x.Email).HasColumnType("varchar(50)");
        builder.Property(x => x.Phone).HasColumnType("varchar(50)");
        builder.Property(x => x.Status).HasConversion<string>();
        builder.Property(x => x.TotalPrice).HasColumnType("decimal(18,2)");

        builder.HasOne(x => x.Car)
        .WithMany(x => x.Reservations)
        .HasForeignKey(x => x.CarId)
        .OnDelete(DeleteBehavior.Cascade);


        builder.HasOne(r => r.PickUpLocation)
        .WithMany(l => l.PickUpReservations)
        .HasForeignKey(r => r.PickUpLocationId)
        .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.DropOffLocation)
        .WithMany(l => l.DropOffReservations)
        .HasForeignKey(r => r.DropOffLocationId)
        .OnDelete(DeleteBehavior.Restrict);
    }
}

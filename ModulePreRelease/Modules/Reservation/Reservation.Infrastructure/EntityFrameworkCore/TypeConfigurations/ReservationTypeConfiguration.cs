using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationModel = Reservation.Domain.Reservation.Reservation;

namespace Reservation.Infrastructure.EntityFrameworkCore.TypeConfigurations;

public class ReservationTypeConfiguration : IEntityTypeConfiguration<ReservationModel>
{
    public void Configure(EntityTypeBuilder<ReservationModel> builder)
    {
        builder.ToTable("reservations");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Status).HasConversion<string>();
    }
}
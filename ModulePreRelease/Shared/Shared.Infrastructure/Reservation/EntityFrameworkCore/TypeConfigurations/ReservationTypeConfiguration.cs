using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationModel = Reservation.Domain.Reservation.Reservation;

namespace Shared.Infrastructure.Reservation.EntityFrameworkCore.TypeConfigurations;

public class ReservationTypeConfiguration : IEntityTypeConfiguration<ReservationModel>
{
    public void Configure(EntityTypeBuilder<ReservationModel> builder)
    {
        builder.ToTable("reservations");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Status).HasConversion<string>();
    }
}
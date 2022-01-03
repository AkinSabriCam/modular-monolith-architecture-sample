using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Reservation.EntityFrameworkCore.TypeConfigurations;

namespace Shared.Infrastructure.Reservation.EntityFrameworkCore;

public class ReservationDbContext : DbContext
{
    public ReservationDbContext(DbContextOptions<ReservationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("reservation");
        modelBuilder.ApplyConfiguration(new ReservationTypeConfiguration());
    }
}
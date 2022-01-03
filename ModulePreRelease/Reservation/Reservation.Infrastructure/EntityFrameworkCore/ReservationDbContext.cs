using Microsoft.EntityFrameworkCore;
using Reservation.Infrastructure.EntityFrameworkCore.TypeConfigurations;

namespace Reservation.Infrastructure.EntityFrameworkCore;

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
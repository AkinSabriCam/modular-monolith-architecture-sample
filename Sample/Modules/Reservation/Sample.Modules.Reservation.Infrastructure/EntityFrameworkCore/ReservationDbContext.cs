using Microsoft.EntityFrameworkCore;
using Sample.Modules.Reservation.Infrastructure.EntityFrameworkCore.TypeConfigurations;

namespace Sample.Modules.Reservation.Infrastructure.EntityFrameworkCore;

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
using Reservation.Application.Shared;

namespace Shared.Infrastructure.Reservation.EntityFrameworkCore;

public class ReservationUnitOfWork : IUnitOfWork
{
    private readonly ReservationDbContext _dbContext;

    public ReservationUnitOfWork(ReservationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
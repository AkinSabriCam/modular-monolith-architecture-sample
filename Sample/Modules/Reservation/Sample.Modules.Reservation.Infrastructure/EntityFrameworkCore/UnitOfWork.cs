
using Sample.Modules.Reservation.Application.Contract.Internal;

namespace Sample.Modules.Reservation.Infrastructure.EntityFrameworkCore;

public class UnitOfWork : IUnitOfWork
{
    private readonly ReservationDbContext _dbContext;

    public UnitOfWork(ReservationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
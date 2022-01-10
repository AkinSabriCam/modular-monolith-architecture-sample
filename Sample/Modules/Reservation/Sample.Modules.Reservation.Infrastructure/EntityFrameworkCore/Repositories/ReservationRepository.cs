using Microsoft.EntityFrameworkCore;
using Sample.Modules.Reservation.Domain.Reservation;
using ReservationModel = Sample.Modules.Reservation.Domain.Reservation.Reservation;

namespace Sample.Modules.Reservation.Infrastructure.EntityFrameworkCore.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly DbSet<ReservationModel> _dbTable;

    public ReservationRepository(ReservationDbContext dbContext)
    {
        _dbTable = dbContext.Set<ReservationModel>();
    }

    public async Task Add(ReservationModel profile)
    { 
        await _dbTable.AddAsync(profile);
        await Task.CompletedTask;
    }

    public Task Update(ReservationModel profile)
    {
        _dbTable.Update(profile);
        return Task.CompletedTask;
    }

    public Task<List<ReservationModel>> Get()
    {
        return _dbTable.AsNoTracking().ToListAsync();
    }

    public async Task<ReservationModel> GetById(Guid id)
    {
        var reservation =  await _dbTable.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (reservation == null)
            throw new Exception($"The reservation is not in the database by this id {id}");

        return reservation;
    }

    public async Task<List<ReservationModel>> GetByProfileId(Guid id)
    {
        return await _dbTable.AsNoTracking().Where(x => x.ProfileId.Equals(id)).ToListAsync();
    }

    public async Task Delete(Guid id)
    {
        var reservation =  await _dbTable.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (reservation == null)
            throw new Exception($"The reservation is not in the database by this id {id}");

        _dbTable.Remove(reservation);
    }
}
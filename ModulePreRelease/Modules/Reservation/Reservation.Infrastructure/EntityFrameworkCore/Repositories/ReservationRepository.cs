using Microsoft.EntityFrameworkCore;
using Reservation.Domain.Reservation;
using ReservationModel = Reservation.Domain.Reservation.Reservation;

namespace Reservation.Infrastructure.EntityFrameworkCore.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly DbSet<ReservationModel> _dbTable;

    public ReservationRepository(ReservationDbContext dbContext)
    {
        _dbTable = dbContext.Set<ReservationModel>();
    }

    public async Task<ReservationModel> Add(ReservationModel profile)
    { 
        await _dbTable.AddAsync(profile);
        return await Task.FromResult(profile);
    }

    public Task<ReservationModel> Update(ReservationModel profile)
    {
        _dbTable.Update(profile);
        return Task.FromResult(profile);
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
using Folio.Domain.Folio;
using Microsoft.EntityFrameworkCore;

namespace Folio.Infrastructure.EntityFrameworkCore.Repositories;

public class FolioRepository : IFolioRepository
{
    private readonly DbSet<Domain.Folio.Folio> _dbTable;

    public FolioRepository(FolioDbContext dbContext)
    {
        _dbTable = dbContext.Set<Domain.Folio.Folio>();
    }
    
    public async Task<Domain.Folio.Folio> GetById(Guid id)
    {
        var folio = await _dbTable.FirstOrDefaultAsync(x => x.Id.Equals(id));
        
        if(folio == null)
            throw new Exception($"The folio is not in the database by this id {id}");

        return folio;
    }

    public Task<List<Domain.Folio.Folio>> GetByReservationId(Guid reservationId)
    {
        return _dbTable.AsNoTracking().Where(x => x.ReservationId.Equals(reservationId)).ToListAsync();
    }

    public Task<List<Domain.Folio.Folio>> GetByProfileId(Guid profileId)
    {
        return _dbTable.AsNoTracking().Where(x => x.ProfileId.Equals(profileId)).ToListAsync();
    }

    public Task<bool> IsExistOpenFolioByProfileId(Guid profileId)
    {
        return _dbTable.AsNoTracking().AnyAsync(x => x.ProfileId.Equals(profileId) && x.Balance > 0);
    }

    public Task<bool> IsExistOpenFolioByReservationId(Guid reservationId)
    {
        return _dbTable.AsNoTracking().AnyAsync(x => x.ReservationId.Equals(reservationId) && x.Balance > 0);
    }

    public Task<List<Domain.Folio.Folio>> Get()
    {
        return _dbTable.AsNoTracking().ToListAsync();
    }

    public Task Create(Domain.Folio.Folio entity)
    {
        _dbTable.Add(entity);
        return Task.CompletedTask;
    }

    public Task Update(Domain.Folio.Folio entity)
    {
        _dbTable.Update(entity);
        return Task.CompletedTask;
    }

    public async Task Delete(Guid id)
    {
        var folio = await _dbTable.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
        
        if(folio == null)
            throw new Exception($"The folio is not in the database by this id {id}");

        _dbTable.Remove(folio);
    }
}
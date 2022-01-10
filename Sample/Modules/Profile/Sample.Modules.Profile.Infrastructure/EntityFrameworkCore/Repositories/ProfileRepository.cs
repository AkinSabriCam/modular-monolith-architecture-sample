using Microsoft.EntityFrameworkCore;
using Sample.Modules.Profile.Domain.Profile;

namespace Sample.Modules.Profile.Infrastructure.EntityFrameworkCore.Repositories;

public class ProfileRepository : IProfileRepository
{
    private readonly DbSet<Domain.Profile.Profile> _dbTable;

    public ProfileRepository(ProfileDbContext dbContext)
    {
        _dbTable = dbContext.Set<Domain.Profile.Profile>();
    }

    public async Task Add(Domain.Profile.Profile profile)
    {
       await _dbTable.AddAsync(profile);
    }

    public Task<Domain.Profile.Profile> Update(Domain.Profile.Profile profile)
    {
         _dbTable.Update(profile);
         return Task.FromResult(profile);
    }

    public Task<List<Domain.Profile.Profile>> Get()
    {
        return _dbTable.AsNoTracking().ToListAsync();
    }

    public Task<List<Domain.Profile.Profile>> GetAllByIdList(List<Guid> ids)
    {
        return _dbTable.AsNoTracking().Where(x=> ids.Contains(x.Id)).ToListAsync();
    }

    public async Task<Domain.Profile.Profile> GetById(Guid id)
    {
        var entity =  await _dbTable.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (entity == null)
            throw new Exception($"The Profile is not in the database by this id {id}");

        return entity;
    }
    
    public async Task Delete(Guid id)
    {
        var entity = await _dbTable.FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (entity == null)
            throw new Exception($"The Profile is not in the database by this id {id}");
        
        _dbTable.Remove(entity);
    }
}
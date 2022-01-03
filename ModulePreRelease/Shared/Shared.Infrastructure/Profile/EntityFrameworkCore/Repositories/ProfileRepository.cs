using Microsoft.EntityFrameworkCore;
using Profile.Domain.Profile;

namespace Shared.Infrastructure.Profile.EntityFrameworkCore.Repositories;

public class ProfileRepository : IProfileRepository
{
    private readonly DbSet<global::Profile.Domain.Profile.Profile> _dbTable;

    public ProfileRepository(ProfileDbContext dbContext)
    {
        _dbTable = dbContext.Set<global::Profile.Domain.Profile.Profile>();
    }

    public async Task<global::Profile.Domain.Profile.Profile> Add(global::Profile.Domain.Profile.Profile profile)
    {
       await _dbTable.AddAsync(profile);
       return profile;
    }

    public Task<global::Profile.Domain.Profile.Profile> Update(global::Profile.Domain.Profile.Profile profile)
    {
         _dbTable.Update(profile);
         return Task.FromResult(profile);
    }

    public Task<List<global::Profile.Domain.Profile.Profile>> Get()
    {
        return _dbTable.AsNoTracking().ToListAsync();
    }

    public async Task<global::Profile.Domain.Profile.Profile> GetById(Guid id)
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
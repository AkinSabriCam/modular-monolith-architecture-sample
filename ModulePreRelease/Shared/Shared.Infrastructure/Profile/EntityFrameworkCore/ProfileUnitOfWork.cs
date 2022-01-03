using Profile.Application;

namespace Shared.Infrastructure.Profile.EntityFrameworkCore;

public class ProfileUnitOfWork : IUnitOfWork
{
    private readonly ProfileDbContext _dbContext;

    public ProfileUnitOfWork(ProfileDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
        await _dbContext.DisposeAsync();
    }
}
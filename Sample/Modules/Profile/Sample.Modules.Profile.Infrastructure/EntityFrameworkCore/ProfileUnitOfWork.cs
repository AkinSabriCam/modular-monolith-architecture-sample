using Sample.Modules.Profile.Application;

namespace Sample.Modules.Profile.Infrastructure.EntityFrameworkCore;

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
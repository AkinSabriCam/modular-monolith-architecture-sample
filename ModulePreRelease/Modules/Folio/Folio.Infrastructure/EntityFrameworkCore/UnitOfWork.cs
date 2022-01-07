using Folio.Application.Shared;

namespace Folio.Infrastructure.EntityFrameworkCore;

public class UnitOfWork : IUnitOfWork
{
    private readonly FolioDbContext _dbContext;

    public UnitOfWork(FolioDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
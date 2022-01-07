using System.Reflection;
using Folio.Infrastructure.EntityFrameworkCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Folio.Infrastructure.EntityFrameworkCore;

public class FolioDbContext : DbContext
{
    public FolioDbContext(DbContextOptions<FolioDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("folio");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FolioTypeConfiguration).GetTypeInfo().Assembly);
    }
}
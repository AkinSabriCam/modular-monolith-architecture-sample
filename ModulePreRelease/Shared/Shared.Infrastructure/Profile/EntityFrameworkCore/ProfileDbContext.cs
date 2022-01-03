using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Profile.EntityFrameworkCore.TypeConfigurations;

namespace Shared.Infrastructure.Profile.EntityFrameworkCore;

public class ProfileDbContext : DbContext
{
    public ProfileDbContext(DbContextOptions<ProfileDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("profile");
        modelBuilder.ApplyConfiguration(new ProfileTypeConfiguration());
    }
}
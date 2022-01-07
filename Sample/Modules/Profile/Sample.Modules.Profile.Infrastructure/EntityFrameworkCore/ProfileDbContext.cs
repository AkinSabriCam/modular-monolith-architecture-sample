using Microsoft.EntityFrameworkCore;
using Sample.Modules.Profile.Infrastructure.EntityFrameworkCore.TypeConfigurations;

namespace Sample.Modules.Profile.Infrastructure.EntityFrameworkCore;

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
using Microsoft.EntityFrameworkCore;
using Profile.Infrastructure.EntityFrameworkCore.TypeConfigurations;

namespace Profile.Infrastructure.EntityFrameworkCore;

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
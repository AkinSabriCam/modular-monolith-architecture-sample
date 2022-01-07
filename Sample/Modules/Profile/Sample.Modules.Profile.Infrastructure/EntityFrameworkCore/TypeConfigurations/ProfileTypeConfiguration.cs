using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sample.Modules.Profile.Infrastructure.EntityFrameworkCore.TypeConfigurations;

public class ProfileTypeConfiguration : IEntityTypeConfiguration<Domain.Profile.Profile>
{
    public void Configure(EntityTypeBuilder<Domain.Profile.Profile> builder)
    {
        builder.ToTable("profiles");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Type).HasConversion<string>();
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Profile.Infrastructure.EntityFrameworkCore.TypeConfigurations;

public class ProfileTypeConfiguration : IEntityTypeConfiguration<global::Profile.Domain.Profile.Profile>
{
    public void Configure(EntityTypeBuilder<global::Profile.Domain.Profile.Profile> builder)
    {
        builder.ToTable("profiles");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Type).HasConversion<string>();
    }
}
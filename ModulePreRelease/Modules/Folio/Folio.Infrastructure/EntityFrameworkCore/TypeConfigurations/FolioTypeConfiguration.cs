using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Folio.Infrastructure.EntityFrameworkCore.TypeConfigurations;

public class FolioTypeConfiguration : IEntityTypeConfiguration<Domain.Folio.Folio>
{
    public void Configure(EntityTypeBuilder<Domain.Folio.Folio> builder)
    {
        builder.ToTable("folios");
        builder.HasKey(x => x.Id);
    }
}
using Sample.Modules.Folio.Domain.Folio.Dtos;

namespace Sample.Modules.Folio.Domain.Folio;

public interface IFolioDomainService
{
    Task<Folio> Create(CreateFolioDto dto);
    Task Close(Guid id);
}
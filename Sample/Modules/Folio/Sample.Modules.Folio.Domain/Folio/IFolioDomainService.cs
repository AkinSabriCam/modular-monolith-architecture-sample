using Sample.Modules.Folio.Domain.Folio.Dtos;

namespace Sample.Modules.Folio.Domain.Folio;

public interface IFolioDomainService
{
    void Create(CreateFolioDto dto);
    Task Close(Guid id);
}
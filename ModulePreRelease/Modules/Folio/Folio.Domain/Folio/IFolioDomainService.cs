using Folio.Domain.Folio.Dtos;

namespace Folio.Domain.Folio;

public interface IFolioDomainService
{
    void Create(CreateFolioDto dto);
    Task Close(Guid id);
}
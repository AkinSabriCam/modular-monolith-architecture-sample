using Sample.Modules.Folio.Domain.Folio.Dtos;

namespace Sample.Modules.Folio.Domain.Folio;

public class FolioDomainService : IFolioDomainService
{
    private readonly IFolioRepository _folioRepository;

    public FolioDomainService(IFolioRepository folioRepository)
    {
        _folioRepository = folioRepository;
    }

    public void Create(CreateFolioDto dto)
    {
        var entity = new Folio(dto.ProfileId, dto.ReservationId, dto.Balance, dto.No);
        _folioRepository.Create(entity);
    }

    public async Task Close(Guid id)
    {
        var folio = await _folioRepository.GetById(id);
        folio.SetBalance(0);
        
        await _folioRepository.Update(folio);
    }
}
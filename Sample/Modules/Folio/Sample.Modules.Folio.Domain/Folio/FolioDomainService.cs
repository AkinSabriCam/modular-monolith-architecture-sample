using Sample.Modules.Folio.Domain.Folio.Dtos;

namespace Sample.Modules.Folio.Domain.Folio;

public class FolioDomainService : IFolioDomainService
{
    private readonly IFolioRepository _folioRepository;

    public FolioDomainService(IFolioRepository folioRepository)
    {
        _folioRepository = folioRepository;
    }

    public async Task<Folio> Create(CreateFolioDto dto)
    {
        var folio = new Folio(dto.ProfileId, dto.ReservationId, dto.Balance, dto.No);
        await _folioRepository.Create(folio);
        return folio;
    }

    public async Task Close(Guid id)
    {
        var folio = await _folioRepository.GetById(id);
        folio.SetBalance(0);
        
        await _folioRepository.Update(folio);
    }
}
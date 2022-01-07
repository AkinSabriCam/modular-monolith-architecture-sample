using Folio.Domain.Folio.Dtos;

namespace Folio.Domain.Folio;

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

    public async Task<Folio> Update(UpdateFolioDto dto)
    {
        var folio = await _folioRepository.GetById(dto.Id);
        
        folio.SetReservationId(dto.ReservationId);
        folio.SetProfileId(dto.ProfileId);
        folio.SetBalance(dto.Balance);
        folio.SetNo(dto.No);

        return folio;
    }

    public async Task Close(Guid id)
    {
        var folio = await _folioRepository.GetById(id);
        folio.SetBalance(0);
        await _folioRepository.Update(folio);
    }

    public Task Delete(Guid id)
    {
        return _folioRepository.Delete(id);
    }
}
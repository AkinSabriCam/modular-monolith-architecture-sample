namespace Folio.Domain.Folio;

public interface IFolioRepository
{
    Task<Folio> GetById(Guid id);
    Task<List<Folio>> GetByReservationId(Guid reservationId);
    Task<List<Folio>> GetByProfileId(Guid profileId);
    
    Task<bool> IsExistOpenFolioByProfileId(Guid profileId);
    Task<bool> IsExistOpenFolioByReservationId(Guid reservationId);

    Task<List<Folio>> Get();
    Task Create(Folio entity);
    Task Update(Folio entity);
    Task Delete(Guid id);
}
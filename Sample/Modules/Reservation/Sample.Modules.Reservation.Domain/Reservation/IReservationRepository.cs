namespace Sample.Modules.Reservation.Domain.Reservation;

public interface IReservationRepository
{
    Task<Reservation> Add(Reservation profile);
    Task<Reservation> Update(Reservation profile);
    Task<List<Reservation>> Get();
    Task<Reservation> GetById(Guid id);
    Task<List<Reservation>> GetByProfileId(Guid id);

    Task Delete(Guid id);
}
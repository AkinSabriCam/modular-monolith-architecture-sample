using Reservation.Domain.Reservation.Dtos;

namespace Reservation.Domain.Reservation;

public class ReservationDomainService : IReservationDomainService
{
    private readonly IReservationRepository _repository;

    public ReservationDomainService(IReservationRepository repository)
    {
        _repository = repository;
    }

    public Task<Reservation> Add(CreateReservationDto dto)
    {
        var reservation = new Reservation
        {
            Status = dto.Status,
            RoomNo = dto.RoomNo,
            ProfileId = dto.ProfileId
        };
        
        return _repository.Add(reservation);
    }

    public async Task<Reservation> Update(UpdateReservationDto dto)
    {
        var entity = await _repository.GetById(dto.ProfileId);

        entity.Status = dto.Status;
        entity.ProfileId = dto.ProfileId;
        entity.RoomNo = dto.RoomNo;

        return await _repository.Update(entity);
    }

    public Task Delete(Guid id)
    {
        return _repository.Delete(id);
    }

    public async Task CheckOut(Guid id)
    {
        var entity = await _repository.GetById(id);
        entity.Status = ReservationStatus.CheckOut;
        await _repository.Update(entity);
    }
}
using Sample.Modules.Reservation.Domain.Reservation.Dtos;

namespace Sample.Modules.Reservation.Domain.Reservation;

public class ReservationDomainService : IReservationDomainService
{
    private readonly IReservationRepository _repository;

    public ReservationDomainService(IReservationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Reservation> Add(CreateReservationDto dto)
    {
        var reservation = new Reservation
        {
            Status = dto.Status,
            RoomNo = dto.RoomNo,
            ProfileId = dto.ProfileId
        };
        
        await _repository.Add(reservation);
        return reservation;
    }

    public async Task<Reservation> Update(UpdateReservationDto dto)
    {
        var entity = await _repository.GetById(dto.ProfileId);

        entity.Status = dto.Status;
        entity.ProfileId = dto.ProfileId;
        entity.RoomNo = dto.RoomNo;

        await _repository.Update(entity);
        return entity;
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
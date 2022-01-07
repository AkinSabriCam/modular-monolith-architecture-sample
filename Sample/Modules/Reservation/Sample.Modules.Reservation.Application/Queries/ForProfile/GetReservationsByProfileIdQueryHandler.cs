using MediatR;
using Sample.Modules.Reservation.Domain.Reservation;

namespace Sample.Modules.Reservation.Application.Queries.ForProfile;

public class GetReservationsByProfileIdQueryHandler : IRequestHandler<GetReservationsByProfileIdQuery, List<ReservationDto>>
{
    private readonly IReservationRepository _repository;
    
    public GetReservationsByProfileIdQueryHandler(IReservationRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ReservationDto>> Handle(GetReservationsByProfileIdQuery request,
        CancellationToken cancellationToken)
    {
        var reservations = await _repository.GetByProfileId(request.ProfileId);

        if (!reservations.Any())
            return new List<ReservationDto>();

        return reservations.Select(res => new ReservationDto
        {
            Id = res.Id,
            Status = res.Status.ToString(),
            ConfirmationNo = res.ConfirmationNo,
            ProfileId = res.ProfileId,
            RoomNo = res.RoomNo,
        }).ToList();
    }
}
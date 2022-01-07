using MediatR;
using Sample.Modules.Reservation.Application.Contract.ProfileIntegration;
using Sample.Modules.Reservation.Domain.Reservation;

namespace Sample.Modules.Reservation.Application.Queries;

public class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, List<ReservationDto>>
{
    private readonly IReservationRepository _repository;
    private readonly IProfileService _profileService;

    public GetAllReservationsQueryHandler(IReservationRepository repository, IProfileService profileService)
    {
        _repository = repository;
        _profileService = profileService;
    }

    public async Task<List<ReservationDto>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
    {
        var reservations = await _repository.Get();
        var profiles = await _profileService.GetProfilesByIdList(reservations.Select(x => x.ProfileId).ToList());

        return reservations.Select(res => 
                new ReservationDto(
                    res.Id, res.ProfileId, res.ConfirmationNo, res.RoomNo, res.Status,
                    profiles.FirstOrDefault(x=>x.Id.Equals(res.ProfileId))
                  ))
            .ToList();
    }
}
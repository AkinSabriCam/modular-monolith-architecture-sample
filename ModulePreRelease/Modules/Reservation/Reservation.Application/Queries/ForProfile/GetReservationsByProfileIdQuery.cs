using Reservation.Application.Contract.ForProfile;

namespace Reservation.Application.Queries.ForProfile;

public class GetReservationsByProfileIdQuery : IQueryForProfileForPlural<ReservationDto>
{
    public Guid ProfileId { get; private set; }

    public GetReservationsByProfileIdQuery(Guid profileId)
    {
        ProfileId = profileId;
    }
}
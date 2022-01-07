using Folio.Application.Contract.Internal;

namespace Folio.Application.Queries;

public class GetFoliosByReservationIdQuery : IQueryForPlural<FolioDto>
{
    public Guid ReservationId { get; private set; }

    public GetFoliosByReservationIdQuery(Guid id)
    {
        ReservationId = id;
    }
}
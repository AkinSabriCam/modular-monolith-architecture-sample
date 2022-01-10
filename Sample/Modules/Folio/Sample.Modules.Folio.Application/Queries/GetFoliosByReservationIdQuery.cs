using Sample.Modules.Folio.Application.Contract.Internal;

namespace Sample.Modules.Folio.Application.Queries;

public class GetFoliosByReservationIdQuery : IQuery<List<FolioDto>>
{
    public Guid ReservationId { get; private set; }

    public GetFoliosByReservationIdQuery(Guid id)
    {
        ReservationId = id;
    }
}
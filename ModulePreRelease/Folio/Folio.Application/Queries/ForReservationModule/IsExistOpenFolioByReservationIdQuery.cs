using Folio.Application.Contract.ContractsForReservation;

namespace Folio.Application.Queries.ForReservationModule;

public class IsExistOpenFolioByReservationIdQuery : IQueryForReservation<bool>
{
    public Guid ReservationId { get; private set; }

    public IsExistOpenFolioByReservationIdQuery(Guid id)
    {
        ReservationId = id;
    }
}
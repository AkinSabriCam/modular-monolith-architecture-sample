using Sample.Modules.Folio.Application.Contract.ContractsForReservation;

namespace Sample.Modules.Folio.Application.Queries.ForReservationModule;

public class IsExistOpenFolioByReservationIdQuery : IQueryForReservation<bool>
{
    public Guid ReservationId { get; private set; }

    public IsExistOpenFolioByReservationIdQuery(Guid id)
    {
        ReservationId = id;
    }
}
using Folio.Application.Contract.ContractsForReservation;
using Folio.Application.Queries.ForReservationModule;
using Reservation.Application.Contract.FolioIntegration;

namespace Reservation.Infrastructure;

public class FolioService : IFolioService
{
    private readonly IFolioExecutorForReservation _folioExecutor;

    public FolioService(IFolioExecutorForReservation folioExecutor)
    {
        _folioExecutor = folioExecutor;
    }

    public Task<bool> IsExistOpenFolioByReservationId(Guid id)
    {
        return _folioExecutor.ExecuteQuery(new IsExistOpenFolioByReservationIdQuery(id));
    }
}
using Sample.Modules.Folio.Application.Contract.ContractsForReservation;
using Sample.Modules.Reservation.Application.Contract.FolioIntegration;
using Sample.Modules.Folio.Application.Queries.ForReservationModule;

namespace Sample.Modules.Reservation.Infrastructure;

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
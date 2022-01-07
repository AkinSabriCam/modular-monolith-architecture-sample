namespace Sample.Modules.Reservation.Application.Contract.FolioIntegration;

public interface IFolioService
{
    Task<bool> IsExistOpenFolioByReservationId(Guid id);
}
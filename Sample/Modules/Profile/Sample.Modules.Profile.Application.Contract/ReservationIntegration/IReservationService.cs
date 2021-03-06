namespace Sample.Modules.Profile.Application.Contract.ReservationIntegration;

public interface IReservationService
{
    Task<List<ReservationDto>> GetReservationsByProfileId(Guid id);
}
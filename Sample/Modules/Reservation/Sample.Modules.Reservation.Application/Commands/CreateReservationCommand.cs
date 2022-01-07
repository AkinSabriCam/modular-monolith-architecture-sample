using Sample.Modules.Reservation.Application.Contract.Internal;
using Sample.Modules.Reservation.Domain.Reservation;

namespace Sample.Modules.Reservation.Application.Commands;

public class CreateReservationCommand : ICommand
{
    public Guid ProfileId { get; set; }
    public string RoomNo { get; set; }
    public ReservationStatus Status { get; set; }
}
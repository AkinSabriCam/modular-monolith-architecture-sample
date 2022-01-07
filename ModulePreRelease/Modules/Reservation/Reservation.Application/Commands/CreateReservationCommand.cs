using Reservation.Application.Contract.Internal;
using Reservation.Domain.Reservation;

namespace Reservation.Application.Commands;

public class CreateReservationCommand : ICommand
{
    public Guid ProfileId { get; set; }
    public string RoomNo { get; set; }
    public ReservationStatus Status { get; set; }
}
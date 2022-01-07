using Reservation.Application.Contract.Internal;

namespace Reservation.Application.Commands;

public class CheckOutReservationCommand : ICommand
{
    public Guid Id { get; set; }
}
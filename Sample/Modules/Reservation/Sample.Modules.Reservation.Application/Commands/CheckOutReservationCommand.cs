using Sample.Modules.Reservation.Application.Contract.Internal;

namespace Sample.Modules.Reservation.Application.Commands;

public class CheckOutReservationCommand : ICommand
{
    public Guid Id { get; set; }
}
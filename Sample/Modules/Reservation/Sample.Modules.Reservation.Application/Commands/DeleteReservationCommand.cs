
using Sample.Modules.Reservation.Application.Contract.Internal;

namespace Sample.Modules.Reservation.Application.Commands;

public class DeleteReservationCommand : ICommand
{
    public Guid Id { get; private set; }

    public DeleteReservationCommand(Guid id)
    {
        Id = id;
    }
}
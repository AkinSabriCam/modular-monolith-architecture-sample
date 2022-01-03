
using Reservation.Application.Contract.Internal;

namespace Reservation.Application.Commands;

public class DeleteReservationCommand : ICommand
{
    public Guid Id { get; private set; }

    public DeleteReservationCommand(Guid id)
    {
        Id = id;
    }
}
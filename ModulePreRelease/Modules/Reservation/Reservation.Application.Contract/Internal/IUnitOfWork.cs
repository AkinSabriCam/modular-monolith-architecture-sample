namespace Reservation.Application.Contract.Internal;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
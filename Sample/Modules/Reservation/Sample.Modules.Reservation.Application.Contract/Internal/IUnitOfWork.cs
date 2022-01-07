namespace Sample.Modules.Reservation.Application.Contract.Internal;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
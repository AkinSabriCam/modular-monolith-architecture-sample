namespace Sample.Modules.Reservation.Application.Contract.Internal;

public interface IReservationExecutor
{
    Task ExecuteCommand(ICommand command);
    Task<TResult> ExecuteQuery<TResult>(IQuery<TResult> query);
    Task<List<TResult>> ExecuteQuery<TResult>(IQueryForPlural<TResult> query);

}
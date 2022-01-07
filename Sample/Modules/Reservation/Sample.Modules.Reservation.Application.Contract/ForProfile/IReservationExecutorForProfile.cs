namespace Sample.Modules.Reservation.Application.Contract.ForProfile;

public interface IReservationExecutorForProfile
{
    Task ExecuteCommand(ICommandForProfile commandForProfile);
    Task<TResult> ExecuteQuery<TResult>(IQueryForProfile<TResult> query);
    Task<List<TResult>> ExecuteQuery<TResult>(IQueryForProfileForPlural<TResult> query);

}
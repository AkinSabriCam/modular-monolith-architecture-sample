namespace Sample.Modules.Folio.Application.Contract.ContractsForReservation;

public interface IFolioExecutorForReservation
{
    Task ExecuteCommand(ICommandForReservation command);
    Task<TResponse> ExecuteQuery<TResponse>(IQueryForReservation<TResponse> query);
}
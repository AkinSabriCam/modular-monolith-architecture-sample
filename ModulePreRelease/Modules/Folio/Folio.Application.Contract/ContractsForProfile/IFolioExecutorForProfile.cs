namespace Folio.Application.Contract.ContractsForProfile;

public interface IFolioExecutorForProfile
{
    Task ExecuteCommand(ICommandForProfile command);
    Task<TResponse> ExecuteQuery<TResponse>(IQueryForProfile<TResponse> command);
    Task<List<TResponse>> ExecuteQuery<TResponse>(IQueryForPluralForProfile<TResponse> command);
}
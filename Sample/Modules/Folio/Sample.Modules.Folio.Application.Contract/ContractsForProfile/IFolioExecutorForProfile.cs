namespace Sample.Modules.Folio.Application.Contract.ContractsForProfile;

public interface IFolioExecutorForProfile
{
    Task ExecuteCommand(ICommandForProfile command);
    Task<TResponse> ExecuteQuery<TResponse>(IQueryForProfile<TResponse> command);
}
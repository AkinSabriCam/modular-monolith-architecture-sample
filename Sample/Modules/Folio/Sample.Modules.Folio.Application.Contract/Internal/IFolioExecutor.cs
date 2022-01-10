namespace Sample.Modules.Folio.Application.Contract.Internal;

public interface IFolioExecutor
{
    Task ExecuteCommand(ICommand command);
    Task<TResult> ExecuteQuery<TResult>(IQuery<TResult> query);
}
namespace Sample.Modules.Profile.Application.Contract.Internal;

public interface IProfileExecutor
{
    Task ExecuteCommand(ICommand command);
    Task<TResponse> ExecuteQuery<TResponse>(IQuery<TResponse> command);
}
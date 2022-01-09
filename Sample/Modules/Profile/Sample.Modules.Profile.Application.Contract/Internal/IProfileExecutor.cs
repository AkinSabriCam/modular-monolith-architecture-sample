using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.Modules.Profile.Application.Contract.Internal;

public interface IProfileExecutor
{
    Task ExecuteCommand(ICommand command);
    Task<TResponse> ExecuteQuery<TResponse>(IQuery<TResponse> command);
    Task<List<TResponse>> ExecuteQuery<TResponse>(IQueryForPlural<TResponse> command);
}
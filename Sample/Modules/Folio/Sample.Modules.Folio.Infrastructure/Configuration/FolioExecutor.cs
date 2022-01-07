using Autofac;
using MediatR;
using Sample.Modules.Folio.Application.Contract.Internal;

namespace Sample.Modules.Folio.Infrastructure.Configuration;

public class FolioExecutor : IFolioExecutor
{
    public async Task ExecuteCommand(ICommand command)
    {
        await using var scope = FolioStartup.BeginScope();
        var mediator = scope.Resolve<IMediator>();
        await mediator.Send(command);
    }

    public async Task<TResult> ExecuteQuery<TResult>(IQuery<TResult> query)
    {
        await using var scope = FolioStartup.BeginScope();
        var mediator = scope.Resolve<IMediator>();
        return await mediator.Send(query);
    }

    public async Task<List<TResult>> ExecuteQuery<TResult>(IQueryForPlural<TResult> query)
    {
        await using var scope = FolioStartup.BeginScope();
        var mediator = scope.Resolve<IMediator>();
        return await mediator.Send(query);
    }
}
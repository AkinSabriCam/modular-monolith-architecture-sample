using Autofac;
using MediatR;
using Sample.Modules.Profile.Application.Contract.Internal;

namespace Sample.Modules.Profile.Infrastructure.Configuration;

public class ProfileExecutor : IProfileExecutor
{ 
    public async Task ExecuteCommand(ICommand command)
    {
        await using var scope = ProfileStartup.BeginScope();
        var mediator = scope.Resolve<IMediator>();
        await mediator.Send(command);
    }

    public async Task<TResponse> ExecuteQuery<TResponse>(IQuery<TResponse> command)
    {
        await using var scope = ProfileStartup.BeginScope();
        var mediator = scope.Resolve<IMediator>();
        return await mediator.Send(command);
    }

    public async Task<List<TResponse>> ExecuteQuery<TResponse>(IQueryForPlural<TResponse> command)
    {
        await using var scope = ProfileStartup.BeginScope();
        var mediator = scope.Resolve<IMediator>();
        return await mediator.Send(command);
    }
}
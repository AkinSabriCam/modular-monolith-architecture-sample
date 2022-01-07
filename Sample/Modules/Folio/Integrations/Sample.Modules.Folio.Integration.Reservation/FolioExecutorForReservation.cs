using Autofac;
using Sample.Modules.Folio.Infrastructure.Shared;
using MediatR;
using Sample.Modules.Folio.Application.Contract.ContractsForReservation;

namespace Sample.Modules.Folio.Integration.Reservation;

public class FolioExecutorForReservation : IFolioExecutorForReservation
{
    public async Task ExecuteCommand(ICommandForReservation command)
    {
        await using var scope = FolioContainerProvider.BeginScope();
        var mediator = scope.Resolve<IMediator>();
        await mediator.Send(command);
    }

    public async Task<TResponse> ExecuteQuery<TResponse>(IQueryForReservation<TResponse> query)
    {
        await using var scope = FolioContainerProvider.BeginScope();
        var mediator = scope.Resolve<IMediator>();
        return await mediator.Send(query);
    }

    public async Task<List<TResponse>> ExecuteQuery<TResponse>(IQueryForPluralForReservation<TResponse> query)
    {
        await using var scope = FolioContainerProvider.BeginScope();
        var mediator = scope.Resolve<IMediator>();
        return await mediator.Send(query);
    }
}
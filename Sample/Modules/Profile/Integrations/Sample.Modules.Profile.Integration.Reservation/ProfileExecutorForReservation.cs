using Autofac;
using MediatR;
using Sample.Modules.Profile.Application.Contract.ContractsForReservation;
using Sample.Modules.Profile.Infrastructure.Shared;

namespace Sample.Modules.Profile.Integration.Reservation;

public class ProfileExecutorForReservation : IProfileExecutorForReservation
{
    public async Task ExecuteCommand(ICommandForReservation commandForProfile)
    {
        await using var scope = ProfileContainerProvider.BeginScope();
        var mediator = scope.Resolve<IMediator>();
        await mediator.Send(commandForProfile);
    }

    public async Task<TResult> ExecuteQuery<TResult>(IQueryForReservation<TResult> query)
    {
        await using var scope = ProfileContainerProvider.BeginScope();
        var mediator = scope.Resolve<IMediator>();
        return await mediator.Send(query);
    }
}
using Autofac;
using MediatR;
using Reservation.Application.Shared.Profile;

namespace Shared.Infrastructure.Reservation.Configuration;

public class ReservationExecutorForProfile : IReservationExecutorForProfile
{
    public async Task ExecuteCommand(ICommandForProfile commandForProfile)
    {
        await using var scope = ReservationStartup.BeginScope();
        var mediator = scope.Resolve<IMediator>();
        await mediator.Send(commandForProfile);
    }

    public async Task<TResult> ExecuteQuery<TResult>(IQueryForProfile<TResult> query)
    {
        await using var scope = ReservationStartup.BeginScope();
        var mediator = scope.Resolve<IMediator>();
        return await mediator.Send(query);
    }

    public async Task<List<TResult>> ExecuteQuery<TResult>(IQueryForProfileForPlural<TResult> query)
    {
        await using var scope = ReservationStartup.BeginScope();
        var mediator = scope.Resolve<IMediator>();
        return await mediator.Send(query);
    }
}
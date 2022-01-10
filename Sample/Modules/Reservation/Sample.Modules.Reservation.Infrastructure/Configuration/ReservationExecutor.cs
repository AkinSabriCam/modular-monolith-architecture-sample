using Autofac;
using MediatR;
using Sample.Modules.Reservation.Application.Contract.Internal;

namespace Sample.Modules.Reservation.Infrastructure.Configuration;

public class ReservationExecutor : IReservationExecutor
{
    public async Task ExecuteCommand(ICommand command)
    {
        await using var scope = ReservationStartup.BeginScope();
        var mediator = scope.Resolve<IMediator>();
        await mediator.Send(command);
    }

    public async Task<TResult> ExecuteQuery<TResult>(IQuery<TResult> query)
    {
        await using var scope = ReservationStartup.BeginScope();
        var mediator = scope.Resolve<IMediator>();
        return await mediator.Send(query);
    }
}
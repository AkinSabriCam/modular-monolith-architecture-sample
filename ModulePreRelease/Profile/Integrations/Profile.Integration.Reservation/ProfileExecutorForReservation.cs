using Autofac;
using MediatR;
using Profile.Application.Contract.ContractsForReservation;
using Profile.Infrastructure.Shared;

namespace Profile.Integration.Reservation
{
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

        public async Task<List<TResult>> ExecuteQuery<TResult>(IQueryForReservationForPlural<TResult> query)
        {
            await using var scope = ProfileContainerProvider.BeginScope();
            var mediator = scope.Resolve<IMediator>();
            return await mediator.Send(query);
        }
    }
}

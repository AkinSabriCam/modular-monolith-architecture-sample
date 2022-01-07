using MediatR;

namespace Sample.Modules.Profile.Application.Contract.ContractsForReservation
{
    public interface IQueryForReservation<out TResponse> : IRequest<TResponse>
    {
    }
}

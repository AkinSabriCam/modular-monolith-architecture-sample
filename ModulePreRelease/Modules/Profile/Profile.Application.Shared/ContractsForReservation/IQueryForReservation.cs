using MediatR;

namespace Profile.Application.Contract.ContractsForReservation
{
    public interface IQueryForReservation<out TResponse> : IRequest<TResponse>
    {
    }
}

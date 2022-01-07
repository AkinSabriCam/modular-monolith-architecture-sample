using MediatR;

namespace Profile.Application.Contract.ContractsForReservation
{
    public interface IQueryForReservationForPlural<TResponse> : IRequest<List<TResponse>>
    {
    }
}

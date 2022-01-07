using MediatR;

namespace Folio.Application.Contract.ContractsForReservation;

public interface IQueryForReservation<TResponse> : IRequest<TResponse>
{
    
}
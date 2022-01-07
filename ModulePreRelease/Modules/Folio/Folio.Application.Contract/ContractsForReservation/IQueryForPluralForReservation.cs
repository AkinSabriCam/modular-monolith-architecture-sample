using MediatR;

namespace Folio.Application.Contract.ContractsForReservation;

public interface IQueryForPluralForReservation<TResponse> : IRequest<List<TResponse>>
{
    
}
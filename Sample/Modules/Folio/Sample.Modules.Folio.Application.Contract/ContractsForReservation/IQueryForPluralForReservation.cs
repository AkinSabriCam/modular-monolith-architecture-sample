using MediatR;

namespace Sample.Modules.Folio.Application.Contract.ContractsForReservation;

public interface IQueryForPluralForReservation<TResponse> : IRequest<List<TResponse>>
{
    
}
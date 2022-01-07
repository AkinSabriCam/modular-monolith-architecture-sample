using MediatR;

namespace Sample.Modules.Folio.Application.Contract.ContractsForReservation;

public interface IQueryForReservation<TResponse> : IRequest<TResponse>
{
    
}
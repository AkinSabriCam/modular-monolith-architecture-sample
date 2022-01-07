using MediatR;

namespace Folio.Application.Contract.Internal;

public interface IQueryForPlural<TResponse> : IRequest<List<TResponse>>
{
    
}
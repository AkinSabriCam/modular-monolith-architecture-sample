using MediatR;

namespace Folio.Application.Contract.Internal;

public interface IQuery<TResponse> : IRequest<TResponse>
{
    
}
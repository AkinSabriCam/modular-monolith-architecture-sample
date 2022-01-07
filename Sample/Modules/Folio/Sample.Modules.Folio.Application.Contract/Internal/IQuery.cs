using MediatR;

namespace Sample.Modules.Folio.Application.Contract.Internal;

public interface IQuery<TResponse> : IRequest<TResponse>
{
    
}
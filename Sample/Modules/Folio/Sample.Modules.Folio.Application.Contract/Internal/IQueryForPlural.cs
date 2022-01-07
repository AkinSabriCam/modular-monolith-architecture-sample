using MediatR;

namespace Sample.Modules.Folio.Application.Contract.Internal;

public interface IQueryForPlural<TResponse> : IRequest<List<TResponse>>
{
    
}
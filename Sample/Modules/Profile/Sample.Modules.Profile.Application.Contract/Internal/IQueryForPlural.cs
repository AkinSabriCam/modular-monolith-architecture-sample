using MediatR;

namespace Sample.Modules.Profile.Application.Contract.Internal;

public interface IQueryForPlural<TResponse> : IRequest<List<TResponse>>
{
    
}
using MediatR;

namespace Profile.Application.Contract.Internal;

public interface IQueryForPlural<TResponse> : IRequest<List<TResponse>>
{
    
}
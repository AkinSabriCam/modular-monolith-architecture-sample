using MediatR;

namespace Profile.Application.Contract.Internal;

public interface IQuery<TResponse> : IRequest<TResponse>
{
    
}
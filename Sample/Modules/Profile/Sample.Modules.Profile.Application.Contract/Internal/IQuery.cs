using MediatR;

namespace Sample.Modules.Profile.Application.Contract.Internal;

public interface IQuery<TResponse> : IRequest<TResponse>
{
    
}
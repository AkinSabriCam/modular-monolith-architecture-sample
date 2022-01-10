using MediatR;

namespace Sample.Modules.Reservation.Application.Contract.Internal;

public interface IQuery<TResponse> : IRequest<TResponse>
{
    
}
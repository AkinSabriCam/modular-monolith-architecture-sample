using MediatR;

namespace Sample.Modules.Reservation.Application.Contract.Internal;

public interface IQuery<TResponse> : IRequest<TResponse>
{
    
}

public interface IQueryForPlural<TResponse> : IRequest<List<TResponse>>
{
    
}
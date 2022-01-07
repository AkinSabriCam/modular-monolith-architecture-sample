using MediatR;

namespace Sample.Modules.Reservation.Application.Contract.ForProfile;

public interface IQueryForProfile<TResponse> : IRequest<TResponse>
{
    
}

public interface IQueryForProfileForPlural<TResponse> : IRequest<List<TResponse>>
{
    
}
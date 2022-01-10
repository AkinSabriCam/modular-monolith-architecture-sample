using MediatR;

namespace Sample.Modules.Reservation.Application.Contract.ForProfile;

public interface IQueryForProfile<TResponse> : IRequest<TResponse>
{
    
}
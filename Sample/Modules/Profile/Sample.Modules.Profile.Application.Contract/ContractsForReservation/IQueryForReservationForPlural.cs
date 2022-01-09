using System.Collections.Generic;
using MediatR;

namespace Sample.Modules.Profile.Application.Contract.ContractsForReservation
{
    public interface IQueryForReservationForPlural<TResponse> : IRequest<List<TResponse>>
    {
    }
}

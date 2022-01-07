using MediatR;

namespace Folio.Application.Contract.ContractsForProfile;

public interface IQueryForPluralForProfile<TResponse> : IRequest<List<TResponse>>
{
    
}
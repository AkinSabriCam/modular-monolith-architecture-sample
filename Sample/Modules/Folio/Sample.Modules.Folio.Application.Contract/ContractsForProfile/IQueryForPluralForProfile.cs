using MediatR;

namespace Sample.Modules.Folio.Application.Contract.ContractsForProfile;

public interface IQueryForPluralForProfile<TResponse> : IRequest<List<TResponse>>
{
    
}
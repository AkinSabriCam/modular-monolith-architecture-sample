using Folio.Application.Contract.ContractsForProfile;

namespace Folio.Application.Queries.ForProfileModule;

public class IsExistOpenFolioByProfileIdQuery : IQueryForProfile<bool>
{
    public Guid ProfileId { get; private set; }

    public IsExistOpenFolioByProfileIdQuery(Guid id)
    {
        ProfileId = id;
    }
}
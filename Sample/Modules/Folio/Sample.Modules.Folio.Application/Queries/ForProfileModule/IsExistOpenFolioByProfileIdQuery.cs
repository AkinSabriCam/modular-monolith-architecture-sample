using Sample.Modules.Folio.Application.Contract.ContractsForProfile;

namespace Sample.Modules.Folio.Application.Queries.ForProfileModule;

public class IsExistOpenFolioByProfileIdQuery : IQueryForProfile<bool>
{
    public Guid ProfileId { get; private set; }

    public IsExistOpenFolioByProfileIdQuery(Guid id)
    {
        ProfileId = id;
    }
}
using Sample.Modules.Profile.Application.Contract.FolioIntegration;
using Sample.Modules.Folio.Application.Contract.ContractsForProfile;
using Sample.Modules.Folio.Application.Queries.ForProfileModule;

namespace Sample.Modules.Profile.Infrastructure;

public class FolioService : IFolioService
{
    private readonly IFolioExecutorForProfile _folioExecutor;

    public FolioService(IFolioExecutorForProfile folioExecutor)
    {
        _folioExecutor = folioExecutor;
    }

    public Task<bool> IsExistOpenFolioByProfileId(Guid id)
    {
        return _folioExecutor.ExecuteQuery(new IsExistOpenFolioByProfileIdQuery(id));
    }
}
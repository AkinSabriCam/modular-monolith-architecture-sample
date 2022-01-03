using Folio.Application.Contract.ContractsForProfile;
using Folio.Application.Queries.ForProfileModule;
using Profile.Application.Contract.FolioIntegration;

namespace Profile.Infrastructure;

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
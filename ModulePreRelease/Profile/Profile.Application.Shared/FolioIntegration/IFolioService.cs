namespace Profile.Application.Contract.FolioIntegration;

public interface IFolioService
{
    Task<bool> IsExistOpenFolioByProfileId(Guid id);
}
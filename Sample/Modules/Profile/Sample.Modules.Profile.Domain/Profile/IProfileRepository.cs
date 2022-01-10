namespace Sample.Modules.Profile.Domain.Profile;

public interface IProfileRepository
{
    Task Add(Profile profile);
    Task<List<Profile>> Get();
    Task<List<Profile>> GetAllByIdList(List<Guid> ids);

    Task<Profile> GetById(Guid id);
    Task Delete(Guid id);
}
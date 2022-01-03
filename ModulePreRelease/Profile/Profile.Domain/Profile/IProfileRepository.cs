namespace Profile.Domain.Profile;

public interface IProfileRepository
{
    Task<Profile> Add(Profile profile);
    Task<Profile> Update(Profile profile);
    Task<List<Profile>> Get();
    Task<List<Profile>> GetAllByIdList(List<Guid> ids);

    Task<Profile> GetById(Guid id);
    Task Delete(Guid id);
}
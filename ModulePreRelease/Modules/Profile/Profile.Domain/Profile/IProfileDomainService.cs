using Profile.Domain.Profile.Dtos;

namespace Profile.Domain.Profile;

public interface IProfileDomainService
{
    public Task<Profile> Create(CreateProfileDto dto);
    public Task<Profile> Update(UpdateProfileDto dto);
    public Task Delete(Guid id);
}
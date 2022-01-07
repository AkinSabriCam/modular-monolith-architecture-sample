using Sample.Modules.Profile.Domain.Profile.Dtos;

namespace Sample.Modules.Profile.Domain.Profile;

public interface IProfileDomainService
{
    public Task<Profile> Create(CreateProfileDto dto);
    public Task<Profile> Update(UpdateProfileDto dto);
    public Task Delete(Guid id);
}
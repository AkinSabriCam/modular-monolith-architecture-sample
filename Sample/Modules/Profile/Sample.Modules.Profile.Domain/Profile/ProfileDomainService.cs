using Sample.Modules.Profile.Domain.Profile.Dtos;

namespace Sample.Modules.Profile.Domain.Profile;

public class ProfileDomainService : IProfileDomainService
{
    private readonly IProfileRepository _repository;

    public ProfileDomainService(IProfileRepository repository)
    {
        _repository = repository;
    }

    public async Task<Profile> Create(CreateProfileDto dto)
    {
        var entity = new Profile(dto.Type);
        entity.SetFirstName(dto.FirstName);
        entity.SetLastName(dto.LastName);

        await _repository.Add(entity);

        return entity;
    }

    public async Task<Profile> Update(UpdateProfileDto dto)
    {
        var entity = await _repository.GetById(dto.Id);
            
        
        entity.SetFirstName(dto.FirstName);
        entity.SetLastName(dto.LastName);
        entity.Type = dto.Type;
       
        await _repository.Update(entity);
        return entity;
    }
    
    public Task Delete(Guid id)
    {
        return _repository.Delete(id);
    }
}
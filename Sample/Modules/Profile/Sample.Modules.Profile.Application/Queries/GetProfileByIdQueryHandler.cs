using MediatR;
using Sample.Modules.Profile.Domain.Profile;

namespace Sample.Modules.Profile.Application.Queries;

public class GetProfileByIdQueryHandler : IRequestHandler<GetProfileByIdQuery, ProfileDto>
{
    private IProfileRepository _repository;

    public GetProfileByIdQueryHandler(IProfileRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProfileDto> Handle(GetProfileByIdQuery request, CancellationToken cancellationToken)
    {
        var profile = await _repository.GetById(request.Id);
        return new ProfileDto()
        {
            Id = profile.Id,
            Type = profile.Type,
            FirstName = profile.FirstName,
            LastName = profile.LastName
        };
    }
}
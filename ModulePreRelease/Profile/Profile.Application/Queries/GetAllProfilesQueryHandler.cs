using MediatR;
using Profile.Domain.Profile;

namespace Profile.Application.Queries;

public class GetAllProfilesQueryHandler : IRequestHandler<GetAllProfilesQuery, List<ProfileDto>>
{
    private readonly IProfileRepository _repository;

    public GetAllProfilesQueryHandler(IProfileRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ProfileDto>> Handle(GetAllProfilesQuery request, CancellationToken cancellationToken)
    {
        var profiles = await _repository.Get();

        return profiles.Select(x => new ProfileDto()
        {
            Id = x.Id,
            Type = x.Type,
            FirstName = x.FirstName,
            LastName = x.LastName
        }).ToList();
    }
}
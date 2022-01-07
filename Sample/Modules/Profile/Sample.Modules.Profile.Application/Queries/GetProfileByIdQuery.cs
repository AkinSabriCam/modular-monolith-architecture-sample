using Sample.Modules.Profile.Application.Contract.Internal;

namespace Sample.Modules.Profile.Application.Queries;

public class GetProfileByIdQuery : IQuery<ProfileDto>
{
    public Guid Id { get; private set; }

    public GetProfileByIdQuery(Guid id)
    {
        Id = id;
    }
}
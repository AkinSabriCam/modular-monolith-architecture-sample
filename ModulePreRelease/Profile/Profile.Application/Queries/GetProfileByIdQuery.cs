using Profile.Application.Contract.Internal;

namespace Profile.Application.Queries;

public class GetProfileByIdQuery : IQuery<ProfileDto>
{
    public Guid Id { get; private set; }

    public GetProfileByIdQuery(Guid id)
    {
        Id = id;
    }
}
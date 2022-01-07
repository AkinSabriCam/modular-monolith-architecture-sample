using Sample.Modules.Profile.Domain.Profile;

namespace Sample.Modules.Profile.Application.Queries;

public class ProfileDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ProfileType Type { get; set; }
}
using Profile.Domain.Profile;

namespace Profile.Application.Queries;

public class ProfileDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ProfileType Type { get; set; }
}
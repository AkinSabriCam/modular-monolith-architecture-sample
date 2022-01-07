using Sample.Modules.Profile.Domain.Profile;

namespace Sample.Modules.Profile.Domain.Profile.Dtos;

public class CreateProfileDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ProfileType Type { get; set; }


    public CreateProfileDto(string firstName, string lastName, ProfileType type)
    {
        FirstName = firstName;
        LastName = lastName;
        Type = type;
    }
}
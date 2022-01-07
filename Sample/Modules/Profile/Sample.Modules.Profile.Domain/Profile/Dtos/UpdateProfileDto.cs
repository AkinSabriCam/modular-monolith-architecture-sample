namespace Sample.Modules.Profile.Domain.Profile.Dtos;

public class UpdateProfileDto
{
    public UpdateProfileDto(Guid id, string firstName, string lastName, ProfileType type)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Type = type;
    }

    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ProfileType Type { get; set; }   
}
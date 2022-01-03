using Profile.Application.Contract.Internal;
using Profile.Domain.Profile;

namespace Profile.Application.Commands;

public class CreateProfileCommand : ICommand
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ProfileType Type { get; set; }   
}
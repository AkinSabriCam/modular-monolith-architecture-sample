using Sample.Modules.Profile.Domain.Profile;
using Sample.Modules.Profile.Application.Contract.Internal;

namespace Sample.Modules.Profile.Application.Commands;

public class CreateProfileCommand : ICommand
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ProfileType Type { get; set; }   
}
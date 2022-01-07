using Sample.Modules.Profile.Application.Contract.Internal;

namespace Sample.Modules.Profile.Application.Commands;

public class DeleteProfileCommand : ICommand
{
    public Guid Id { get; private set; }

    public DeleteProfileCommand(Guid id)
    {
        Id = id;
    }
}
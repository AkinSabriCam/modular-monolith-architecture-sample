using Sample.Modules.Folio.Application.Contract.Internal;

namespace Sample.Modules.Folio.Application.Commands;

public class CloseFolioCommand : ICommand
{
    public Guid Id { get; set; }

}
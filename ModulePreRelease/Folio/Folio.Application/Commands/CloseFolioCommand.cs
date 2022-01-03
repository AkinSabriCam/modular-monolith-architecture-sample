using Folio.Application.Contract.Internal;

namespace Folio.Application.Commands;

public class CloseFolioCommand : ICommand
{
    public Guid Id { get; set; }

}
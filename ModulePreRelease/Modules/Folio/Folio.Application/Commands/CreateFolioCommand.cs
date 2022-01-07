using ICommand = Folio.Application.Contract.Internal.ICommand;

namespace Folio.Application.Commands;

public class CreateFolioCommand : ICommand
{
    public Guid? ProfileId { get; set; }
    public Guid? ReservationId { get; set; }
    public string  No { get; set; }
    public decimal Balance { get; set; }
}
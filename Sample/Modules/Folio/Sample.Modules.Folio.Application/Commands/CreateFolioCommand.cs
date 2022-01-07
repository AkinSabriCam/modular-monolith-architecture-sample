using ICommand = Sample.Modules.Folio.Application.Contract.Internal.ICommand;

namespace Sample.Modules.Folio.Application.Commands;

public class CreateFolioCommand : ICommand
{
    public Guid? ProfileId { get; set; }
    public Guid? ReservationId { get; set; }
    public string  No { get; set; }
    public decimal Balance { get; set; }
}
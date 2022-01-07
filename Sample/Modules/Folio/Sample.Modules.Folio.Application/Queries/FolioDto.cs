namespace Sample.Modules.Folio.Application.Queries;

public class FolioDto
{
    public Guid Id { get; set; }
    public string No { get; set; }
    public decimal Balance { get; set; }
    public Guid? ProfileId { get; set; }
    public Guid? ReservationId { get; set; }
}
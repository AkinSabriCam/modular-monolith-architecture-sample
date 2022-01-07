namespace Sample.Modules.Folio.Domain.Folio.Dtos;

public class CreateFolioDto
{
    public Guid? ProfileId { get; set; }
    public Guid? ReservationId { get; set; }

    public string  No { get; set; }
    public decimal Balance { get; set; }
}
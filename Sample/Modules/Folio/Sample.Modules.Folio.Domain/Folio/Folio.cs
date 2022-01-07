namespace Sample.Modules.Folio.Domain.Folio;

public class Folio
{
    public Guid Id { get; }
    public Guid? ProfileId { get; }
    public Guid? ReservationId { get; }

    public decimal Balance { get; private set; }
    public string No { get; }
    
    public Folio(Guid? profileId, Guid? reservationId, decimal balance, string no)
    {
        Id = Guid.NewGuid();
        ProfileId = profileId;
        ReservationId = reservationId;
        Balance = balance;
        No = no;
    }
    
    public void SetBalance(decimal balance)
    {
        Balance = balance;
    }
}
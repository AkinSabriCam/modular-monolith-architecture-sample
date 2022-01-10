namespace Sample.Modules.Folio.Domain.Folio;

public class Folio
{
    public Guid Id { get; }
    public Guid? ProfileId { get; set; }
    public Guid? ReservationId { get; set; }

    public decimal Balance { get; private set; }
    public string No { get; set; }
    
    public Folio(Guid? profileId, Guid? reservationId, decimal balance, string no)
    {
        Id = Guid.NewGuid();
        ProfileId = profileId;
        ReservationId = reservationId;
        Balance = balance;
        No = no;
    }

    // for entityframework
    public Folio()
    {
        Id = Guid.NewGuid();
    }
    
    public void SetBalance(decimal balance)
    {
        Balance = balance;
    }
}
namespace Sample.Modules.Folio.Domain.Folio;

public class Folio
{
    public Guid Id { get; private set; }
    public Guid? ProfileId { get; set; }
    public Guid? ReservationId { get; set; }

    public decimal Balance { get; private set; }
    public string No { get; private set; }
    
    public Folio(Guid? profileId, Guid? reservationId, decimal balance, string no)
    {
        Id = Guid.NewGuid();
        ProfileId = profileId;
        ReservationId = reservationId;
        Balance = balance;
        No = no;
    }

    public void SetProfileId(Guid? profileId)
    {
        ProfileId = profileId;
    }
    
    public void SetReservationId(Guid? reservationId)
    {
        ReservationId = reservationId;
    }
    
    public void SetBalance(decimal balance)
    {
        Balance = balance;
    }
    
    public void SetNo(string no)
    {
        No = no;
    }
}
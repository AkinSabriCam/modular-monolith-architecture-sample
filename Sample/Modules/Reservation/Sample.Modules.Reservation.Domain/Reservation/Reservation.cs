namespace Sample.Modules.Reservation.Domain.Reservation;

public class Reservation
{
    public Guid Id { get; set; }
    public Guid ProfileId { get; set; }
    public string ConfirmationNo { get; set; }
    public string RoomNo { get; set; }
    public ReservationStatus Status { get; set; }

    public Reservation()
    {
        Id = Guid.Empty;
        ConfirmationNo = Random.Shared.Next(1000, 10000).ToString();
    }
}

public enum ReservationStatus
{
    Reserved,
    CheckIn,
    CheckOut
}
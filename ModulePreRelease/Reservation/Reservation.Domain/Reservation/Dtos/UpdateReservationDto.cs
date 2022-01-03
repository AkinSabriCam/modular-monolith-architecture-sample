namespace Reservation.Domain.Reservation.Dtos;

public class UpdateReservationDto
{
    public Guid Id { get; set; }
    public Guid ProfileId { get; set; }
    public string RoomNo { get; set; }
    public ReservationStatus Status { get; set; }
}
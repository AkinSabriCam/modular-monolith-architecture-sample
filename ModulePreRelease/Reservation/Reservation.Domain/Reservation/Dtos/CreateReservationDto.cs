namespace Reservation.Domain.Reservation.Dtos;

public class CreateReservationDto
{
    public Guid  ProfileId { get; set; }
    public string RoomNo { get; set; }
    public ReservationStatus Status { get; set; }
}
using Reservation.Application.Contract.ProfileIntegration;
using Reservation.Domain.Reservation;

namespace Reservation.Application.Queries;

public class ReservationDto
{
    public ReservationDto(
        Guid id, 
        Guid profileId, 
        string confirmationNo, 
        string roomNo,
        ReservationStatus status, 
        ProfileIntegrationDto? profile)
    {
        Id = id;
        ProfileId = profileId;
        ConfirmationNo = confirmationNo;
        RoomNo = roomNo;
        Status = status;
        Profile = profile;
    }

    public Guid Id { get; set; }
    public Guid ProfileId { get; set; }
    public string ConfirmationNo { get; set; }
    public string RoomNo { get; set; }
    public ReservationStatus Status { get; set; }
    public ProfileIntegrationDto? Profile { get; set; }
}
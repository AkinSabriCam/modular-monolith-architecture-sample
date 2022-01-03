﻿using Profile.Application.Contract.ReservationIntegration;
using Reservation.Application.Contract.ForProfile;
using Reservation.Application.Queries.ForProfile;
using ReservationDto = Profile.Application.Contract.ReservationIntegration.ReservationDto;

namespace Profile.Infrastructure;

public class ReservationService : IReservationService
{
    private readonly IReservationExecutorForProfile _reservationExecutorForProfile;

    public ReservationService(IReservationExecutorForProfile reservationExecutorForProfile)
    {
        _reservationExecutorForProfile = reservationExecutorForProfile;
    }

    public async Task<List<ReservationDto>> GetReservationsByProfileId(Guid id)
    {
        var reservations = await _reservationExecutorForProfile.ExecuteQuery(new GetReservationsByProfileIdQuery(id));
        
        // can use mapper to cast these same classes
        return reservations.Select(x => new ReservationDto()
        {
            Id = x.Id,
            ConfirmationNo = x.ConfirmationNo,
            ProfileId = x.ProfileId,
            RoomNo = x.RoomNo,
            Status = x.Status
        }).ToList();
    }
}
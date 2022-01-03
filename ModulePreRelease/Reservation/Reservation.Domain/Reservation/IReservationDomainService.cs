﻿using Reservation.Domain.Reservation.Dtos;

namespace Reservation.Domain.Reservation;

public interface IReservationDomainService
{
    Task<Reservation> Add(CreateReservationDto dto);
    Task<Reservation> Update(UpdateReservationDto dto);
    Task Delete(Guid id);
    Task CheckOut(Guid id);
}
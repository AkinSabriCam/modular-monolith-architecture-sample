using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.Modules.Profile.Application.Contract.ReservationIntegration;

public interface IReservationService
{
    Task<List<ReservationDto>> GetReservationsByProfileId(Guid id);
}
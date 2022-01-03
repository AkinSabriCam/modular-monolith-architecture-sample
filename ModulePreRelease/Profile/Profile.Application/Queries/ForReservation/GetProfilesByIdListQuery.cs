﻿using Profile.Application.Contract.ContractsForReservation;

namespace Profile.Application.Queries.ForReservation
{
    public class GetProfilesByIdListQuery : IQueryForReservation<List<ProfileForReservationDto>>
    {
        public List<Guid> Ids { get; private set; }

        public GetProfilesByIdListQuery(List<Guid> ids)
        {
            Ids = ids;
        }
    }
}

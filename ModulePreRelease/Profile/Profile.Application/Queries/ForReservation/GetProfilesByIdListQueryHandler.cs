using MediatR;
using Profile.Application.Contract.ContractsForReservation;
using Profile.Domain.Profile;

namespace Profile.Application.Queries.ForReservation
{
    public class GetProfilesByIdListQueryHandler : IRequestHandler<GetProfilesByIdListQuery, List<ProfileForReservationDto>>
    {
        private readonly IProfileRepository _repository;

        public GetProfilesByIdListQueryHandler(IProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProfileForReservationDto>> Handle(GetProfilesByIdListQuery request, CancellationToken cancellationToken)
        {
            var profiles = await _repository.GetAllByIdList(request.Ids);
            return profiles.Select(profile=>  new ProfileForReservationDto()
            {
                Id = profile.Id,
                FirstName = profile.FirstName,
                LastName = profile.LastName
            }).ToList();
        }
    }
}

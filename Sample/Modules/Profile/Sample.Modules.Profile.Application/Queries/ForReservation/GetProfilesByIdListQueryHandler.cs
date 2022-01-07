using MediatR;
using Sample.Modules.Profile.Application.Contract.ContractsForReservation;
using Sample.Modules.Profile.Domain.Profile;

namespace Sample.Modules.Profile.Application.Queries.ForReservation
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

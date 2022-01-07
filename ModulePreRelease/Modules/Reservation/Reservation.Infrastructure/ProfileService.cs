using Profile.Application.Contract.ContractsForReservation;
using Profile.Application.Queries.ForReservation;
using Reservation.Application.Contract.ProfileIntegration;

namespace Reservation.Infrastructure
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileExecutorForReservation _profileExecutorForReservation;

        public ProfileService(IProfileExecutorForReservation profileExecutorForReservation)
        {
            _profileExecutorForReservation = profileExecutorForReservation;
        }

        public async Task<List<ProfileIntegrationDto>> GetProfilesByIdList(List<Guid> profileIds)
        {
            var profiles = await _profileExecutorForReservation.ExecuteQuery(new GetProfilesByIdListQuery(profileIds));

            return profiles.Select(profile=>  new ProfileIntegrationDto()
            {
                Id = profile.Id,
                FirstName = profile.FirstName,
                LastName = profile.LastName
            }).ToList();
        }
    }
}

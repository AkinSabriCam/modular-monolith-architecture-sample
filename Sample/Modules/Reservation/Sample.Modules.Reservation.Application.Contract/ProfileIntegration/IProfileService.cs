namespace Sample.Modules.Reservation.Application.Contract.ProfileIntegration
{
    public interface IProfileService
    {
        Task<List<ProfileIntegrationDto>> GetProfilesByIdList(List<Guid> profileIds);
    }
}

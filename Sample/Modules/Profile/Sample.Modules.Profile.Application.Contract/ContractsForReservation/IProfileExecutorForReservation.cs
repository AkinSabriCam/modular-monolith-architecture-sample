namespace Sample.Modules.Profile.Application.Contract.ContractsForReservation
{
    public interface IProfileExecutorForReservation
    {
        Task ExecuteCommand(ICommandForReservation command);
        Task<TResponse> ExecuteQuery<TResponse>(IQueryForReservation<TResponse> command);
    }
}

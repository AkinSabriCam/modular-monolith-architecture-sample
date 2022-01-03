namespace Profile.Application;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
namespace Sample.Modules.Profile.Application;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
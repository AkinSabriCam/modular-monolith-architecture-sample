namespace Folio.Application.Shared;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
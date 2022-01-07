using Autofac;

namespace Sample.Modules.Folio.Infrastructure.Shared;

public static class FolioContainerProvider
{
    private static IContainer _container;

    public static void SetContainer(IContainer container)
    {
        _container = container;
    }
    
    public static ILifetimeScope BeginScope()
    {
        return _container.BeginLifetimeScope();
    }
}
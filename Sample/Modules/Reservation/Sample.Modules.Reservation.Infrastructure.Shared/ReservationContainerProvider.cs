using Autofac;
using Autofac.Core;

namespace Sample.Modules.Reservation.Infrastructure.Shared;

public class ReservationContainerProvider
{
    private static IContainer _container;

    public static void SetContainer(ContainerBuilder containerBuilder)
    {
        _container = containerBuilder.Build();
    }

    public static ILifetimeScope BeginScope()
    {
        return _container.BeginLifetimeScope();
    }
}
using System.Reflection;
using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Reservation.Application.Commands;
using Reservation.Application.Shared;
using Reservation.Application.Shared.Profile;
using Reservation.Domain.Reservation;
using Reservation.Infrastructure.Configuration;
using Shared.Infrastructure.Reservation.EntityFrameworkCore;
using Shared.Infrastructure.Reservation.EntityFrameworkCore.Repositories;
using Module = Autofac.Module;

namespace Shared.Infrastructure.Reservation.Configuration;

public class ReservationStartup
{
    private static IContainer? _container;
    private static ContainerBuilder? _containerBuilder;

    public static void Initialize(string connString)
    {
        _containerBuilder = new ContainerBuilder();

        _containerBuilder.Register(x =>
        {
            var optionsBuilder = new DbContextOptionsBuilder<ReservationDbContext>();
            optionsBuilder.UseNpgsql(connString);
            return new ReservationDbContext(optionsBuilder.Options);
        }).InstancePerLifetimeScope();

        _containerBuilder.RegisterType<ReservationDomainService>().As<IReservationDomainService>().InstancePerLifetimeScope();
        _containerBuilder.RegisterType<ReservationUnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        _containerBuilder.RegisterType<ReservationRepository>().As<IReservationRepository>().InstancePerLifetimeScope();
        _containerBuilder.RegisterType<ReservationExecutor>().As<IReservationExecutor>().InstancePerLifetimeScope();
        _containerBuilder.RegisterType<ReservationExecutorForProfile>().As<IReservationExecutorForProfile>().InstancePerLifetimeScope();

        _containerBuilder.RegisterMediatR(typeof(CreateReservationCommand).GetTypeInfo().Assembly);

        _container = _containerBuilder.Build();
    }

    public static ILifetimeScope BeginScope()
    {
        return _container.BeginLifetimeScope();
    }
}
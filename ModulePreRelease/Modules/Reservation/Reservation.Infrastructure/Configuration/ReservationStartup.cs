using System.Reflection;
using Autofac;
using Folio.Application.Contract.ContractsForReservation;
using Folio.Integration.Reservation;
using MediatR.Extensions.Autofac.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Profile.Application.Contract.ContractsForReservation;
using Profile.Integration.Reservation;
using Reservation.Application.Commands;
using Reservation.Application.Contract.FolioIntegration;
using Reservation.Application.Contract.Internal;
using Reservation.Application.Contract.ProfileIntegration;
using Reservation.Domain.Reservation;
using Reservation.Infrastructure.EntityFrameworkCore;
using Reservation.Infrastructure.EntityFrameworkCore.Repositories;
using Reservation.Infrastructure.Shared;

namespace Reservation.Infrastructure.Configuration;

public class ReservationStartup
{
    public static void Initialize(string connString)
    {
        var containerBuilder = ReservationContainerProvider.GetContainerBuilder();

        containerBuilder.Register(x =>
        {
            var optionsBuilder = new DbContextOptionsBuilder<ReservationDbContext>();
            optionsBuilder.UseNpgsql(connString);
            return new ReservationDbContext(optionsBuilder.Options);
        }).InstancePerLifetimeScope();

        containerBuilder.RegisterType<ReservationDomainService>().As<IReservationDomainService>().InstancePerLifetimeScope();
        containerBuilder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        containerBuilder.RegisterType<ReservationRepository>().As<IReservationRepository>().InstancePerLifetimeScope();
        
        containerBuilder.RegisterType<ProfileExecutorForReservation>().As<IProfileExecutorForReservation>().InstancePerLifetimeScope();
        containerBuilder.RegisterType<ProfileService>().As<IProfileService>().InstancePerLifetimeScope();

        containerBuilder.RegisterType<FolioExecutorForReservation>().As<IFolioExecutorForReservation>().InstancePerLifetimeScope();
        containerBuilder.RegisterType<FolioService>().As<IFolioService>().InstancePerLifetimeScope();

        containerBuilder.RegisterMediatR(typeof(CreateReservationCommand).GetTypeInfo().Assembly);
        ReservationContainerProvider.SetContainer(containerBuilder);
    }

    public static ILifetimeScope BeginScope()
    {
        return ReservationContainerProvider.BeginScope();
    }
}
using System.Reflection;
using Autofac;
using Sample.Modules.Folio.Integration.Reservation;
using MediatR.Extensions.Autofac.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Sample.Modules.Profile.Integration.Reservation;
using Sample.Modules.Reservation.Application.Commands;
using Sample.Modules.Reservation.Application.Contract.FolioIntegration;
using Sample.Modules.Reservation.Application.Contract.Internal;
using Sample.Modules.Reservation.Application.Contract.ProfileIntegration;
using Sample.Modules.Folio.Application.Contract.ContractsForReservation;
using Sample.Modules.Profile.Application.Contract.ContractsForReservation;
using Sample.Modules.Reservation.Domain.Reservation;
using Sample.Modules.Reservation.Infrastructure.EntityFrameworkCore;
using Sample.Modules.Reservation.Infrastructure.EntityFrameworkCore.Repositories;
using Sample.Modules.Reservation.Infrastructure.Shared;

namespace Sample.Modules.Reservation.Infrastructure.Configuration;

public static class ReservationStartup
{
    public static void Initialize(string connString)
    {
        var containerBuilder = new ContainerBuilder();

        containerBuilder.Register(_ =>
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
        MigrateDatabase().Wait();
    }

    public static ILifetimeScope BeginScope()
    {
        return ReservationContainerProvider.BeginScope();
    }
    
    private static async Task MigrateDatabase()
    {
        var scope = BeginScope();
        var dbContext = scope.Resolve<ReservationDbContext>();
        await dbContext.Database.MigrateAsync();
    }
}
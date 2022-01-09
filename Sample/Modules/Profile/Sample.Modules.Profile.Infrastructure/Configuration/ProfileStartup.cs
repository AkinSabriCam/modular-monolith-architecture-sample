using System.Reflection;
using Autofac;
using Sample.Modules.Folio.Integration.Profile;
using MediatR.Extensions.Autofac.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Sample.Modules.Profile.Application;
using Sample.Modules.Profile.Application.Commands;
using Sample.Modules.Profile.Infrastructure.Shared;
using Sample.Modules.Reservation.Integration.Profile;
using Sample.Modules.Folio.Application.Contract.ContractsForProfile;
using Sample.Modules.Profile.Application.Contract.FolioIntegration;
using Sample.Modules.Profile.Application.Contract.ReservationIntegration;
using Sample.Modules.Profile.Domain.Profile;
using Sample.Modules.Profile.Infrastructure.EntityFrameworkCore;
using Sample.Modules.Profile.Infrastructure.EntityFrameworkCore.Repositories;
using Sample.Modules.Reservation.Application.Contract.ForProfile;

namespace Sample.Modules.Profile.Infrastructure.Configuration;

public static class ProfileStartup
{
    public static void Initialize(string connString)
    {
        var builder = new ContainerBuilder();

        builder.Register(_ =>
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProfileDbContext>();
            optionsBuilder.UseNpgsql(connString);
            return new ProfileDbContext(optionsBuilder.Options);
        }).InstancePerLifetimeScope();

        builder.RegisterType<ProfileRepository>().As<IProfileRepository>().InstancePerLifetimeScope();
        builder.RegisterType<ProfileDomainService>().As<IProfileDomainService>().InstancePerLifetimeScope();
        builder.RegisterType<ProfileUnitOfWork>().As<IUnitOfWork>();
        
        builder.RegisterType<ReservationService>().As<IReservationService>().InstancePerLifetimeScope();
        builder.RegisterType<ReservationExecutorForProfile>().As<IReservationExecutorForProfile>().InstancePerLifetimeScope();
        
        builder.RegisterType<FolioExecutorForProfile>().As<IFolioExecutorForProfile>().InstancePerLifetimeScope();
        builder.RegisterType<FolioService>().As<IFolioService>().InstancePerLifetimeScope();

        builder.RegisterMediatR(typeof(CreateProfileCommand).GetTypeInfo().Assembly);
        ProfileContainerProvider.SetContainer(builder);
    }

    public static ILifetimeScope BeginScope()
    {
        return ProfileContainerProvider.GetContainer().BeginLifetimeScope();
    }
}
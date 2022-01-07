using System.Reflection;
using Autofac;
using Folio.Application.Contract.ContractsForProfile;
using Folio.Integration.Profile;
using MediatR.Extensions.Autofac.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Profile.Application;
using Profile.Application.Commands;
using Profile.Application.Contract.FolioIntegration;
using Profile.Application.Contract.ReservationIntegration;
using Profile.Domain.Profile;
using Profile.Infrastructure.EntityFrameworkCore;
using Profile.Infrastructure.EntityFrameworkCore.Repositories;
using Profile.Infrastructure.Shared;
using Reservation.Application.Contract.ForProfile;
using Reservation.Integration.Profile;

namespace Profile.Infrastructure.Configuration;

public class ProfileStartup
{
    public static void Initialize(string connString)
    {
        var builder = new ContainerBuilder();

        builder.Register(x =>
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
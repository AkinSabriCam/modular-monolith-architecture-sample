using System.Reflection;
using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Profile.Application;
using Profile.Application.Commands;
using Profile.Application.Shared.Internal;
using Profile.Domain.Profile;
using Shared.Infrastructure.Profile.EntityFrameworkCore;
using Shared.Infrastructure.Profile.EntityFrameworkCore.Repositories;
using Module = Autofac.Module;

namespace Shared.Infrastructure.Profile.Configuration;

public class ProfileStartup
{
    private static ContainerBuilder _builder;
    private static IContainer _container;

    public static void Initialize(string connString)
    {
        _builder = new ContainerBuilder();

        _builder.Register(x =>
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProfileDbContext>();
            optionsBuilder.UseNpgsql(connString);
            return new ProfileDbContext(optionsBuilder.Options);
        }).InstancePerLifetimeScope();

        _builder.RegisterType<ProfileRepository>().As<IProfileRepository>().InstancePerLifetimeScope();
        _builder.RegisterType<ProfileDomainService>().As<IProfileDomainService>().InstancePerLifetimeScope();
        //_builder.RegisterType<ProfileExecutor>().As<IProfileExecutor>().InstancePerLifetimeScope();
        _builder.RegisterType<ProfileUnitOfWork>().As<IUnitOfWork>();

        _builder.RegisterMediatR(typeof(CreateProfileCommand).GetTypeInfo().Assembly);


        _container = _builder.Build();
    }
    

    public static ILifetimeScope BeginScope()
    {
        return _container.BeginLifetimeScope();
    }
}
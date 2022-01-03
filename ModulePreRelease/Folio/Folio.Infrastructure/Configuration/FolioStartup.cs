using System.Reflection;
using Autofac;
using Folio.Application.Commands;
using Folio.Application.Shared;
using Folio.Domain.Folio;
using Folio.Infrastructure.EntityFrameworkCore;
using Folio.Infrastructure.EntityFrameworkCore.Repositories;
using Folio.Infrastructure.Shared;
using MediatR.Extensions.Autofac.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Folio.Infrastructure.Configuration;

public class FolioStartup
{
    private static ContainerBuilder? _containerBuilder;

    public static void Initialize(string connString)
    {
        _containerBuilder = new ContainerBuilder();

        _containerBuilder.Register(x =>
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<FolioDbContext>();
            dbContextOptionsBuilder.UseNpgsql(connString);
            return new FolioDbContext(dbContextOptionsBuilder.Options);
        }).InstancePerLifetimeScope();
        
        _containerBuilder.RegisterType<FolioRepository>().As<IFolioRepository>().InstancePerLifetimeScope();
        _containerBuilder.RegisterType<FolioDomainService>().As<IFolioDomainService>().InstancePerLifetimeScope();
        _containerBuilder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        _containerBuilder.RegisterMediatR(typeof(CreateFolioCommand).GetTypeInfo().Assembly);

        FolioContainerProvider.SetContainer(_containerBuilder.Build());
    }

    public static ILifetimeScope BeginScope()
    {
        return FolioContainerProvider.BeginScope();
    }
}
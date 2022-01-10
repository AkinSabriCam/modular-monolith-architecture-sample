using System.Reflection;
using Autofac;
using Folio.Application.Shared;
using Sample.Modules.Folio.Infrastructure.Shared;
using MediatR.Extensions.Autofac.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Sample.Modules.Folio.Application.Commands;
using Sample.Modules.Folio.Domain.Folio;
using Sample.Modules.Folio.Infrastructure.EntityFrameworkCore;
using Sample.Modules.Folio.Infrastructure.EntityFrameworkCore.Repositories;

namespace Sample.Modules.Folio.Infrastructure.Configuration;

public static class FolioStartup
{
    private static ContainerBuilder? _containerBuilder;

    public static void Initialize(string connString)
    {
        _containerBuilder = new ContainerBuilder();

        _containerBuilder.Register(_ =>
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
        MigrateDatabase().Wait();
    }

    public static ILifetimeScope BeginScope()
    {
        return FolioContainerProvider.BeginScope();
    }
    
    private static async Task MigrateDatabase()
    {
        var scope = BeginScope();
        var dbContext = scope.Resolve<FolioDbContext>();
        await dbContext.Database.MigrateAsync();
    }
}
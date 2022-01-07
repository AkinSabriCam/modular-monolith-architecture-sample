using Autofac;

namespace Sample.Modules.Profile.Infrastructure.Shared
{
    public static class ProfileContainerProvider
    {
        private static IContainer _container;

        public static IContainer GetContainer()
        {
            return _container;
        }

        public static void SetContainer(ContainerBuilder containerBuilder)
        {
            _container = containerBuilder.Build();
        }

        public static ILifetimeScope BeginScope()
        {
            return _container.BeginLifetimeScope();
        }
    }
}

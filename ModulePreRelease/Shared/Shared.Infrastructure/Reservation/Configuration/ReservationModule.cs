using Autofac;
using Reservation.Application.Shared.Profile;

namespace Shared.Infrastructure.Reservation.Configuration
{
    public class ReservationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ReservationExecutorForProfile>().As<IReservationExecutorForProfile>()
                .InstancePerLifetimeScope();
            /*
            builder.RegisterType<ReservationRepository>().As<IReservationRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ReservationDomainService>().As<IReservationDomainService>()
                .InstancePerLifetimeScope();*/

        }
    }
}

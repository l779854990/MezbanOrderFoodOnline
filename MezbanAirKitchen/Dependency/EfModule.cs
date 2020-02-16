using Autofac;
using MezbanData.DbContext;
using MezbanInfrastructure.Repository;

namespace MezbanAirKitchen.Dependency
{
    public class EfModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());

            builder.RegisterType(typeof(MezbanAirKitchenEntities)).InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
        }
    }
}
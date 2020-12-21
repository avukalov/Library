using Autofac;
using Library.Repository.Common;

namespace Library.Repository
{
    public class RepositoryDIModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            
        }
    }
}

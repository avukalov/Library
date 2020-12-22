using Autofac;
using Library.DAL.Entities;
using Library.Models.Common.Utils;
using Library.Models.Utils;
using Library.Repository.Common;

namespace Library.Repository
{
    public class RepositoryDIModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            //builder.Register()
            //builder.RegisterType<ISortHelper<BookEntity>>().As<IQueryHelper<BookEntity>>();
            builder.RegisterType<SortHelper<BookEntity>>().As<ISortHelper<BookEntity>>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            
        }
    }
}

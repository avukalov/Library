using Autofac;
using Library.DAL.Entities;
using Library.Models;
using Library.Models.Common.Utilities;
using Library.Models.Utilities;
using Library.Repository.Common;

namespace Library.Repository
{
    public class RepositoryDIModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<QueryHelper<BookEntity, BookParameters>>().As<IQueryHelper<BookEntity, BookParameters>>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<SqlRepository>().As<ISqlRepository>();
            
        }
    }
}

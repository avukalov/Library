using Autofac;
using Library.Service.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Service
{
    public class ServiceDIModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<BookService>().As<IBookService>().InstancePerLifetimeScope();
            builder.RegisterType<AuthorService>().As<IAuthorService>().InstancePerLifetimeScope();
        }
    }
}

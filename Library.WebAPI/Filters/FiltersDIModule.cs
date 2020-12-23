using Autofac;
using Library.WebAPI.Filters.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebAPI.Filters
{
    public class FiltersDIModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<ValidationFilterAttribute>();
            builder.RegisterType<AuthorEntityExistsAttribute>();
            builder.RegisterType<BookEntityExistsAttribute>();
        }
    }
}

using Autofac;
using Library.Common.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Common
{
    public class CommonDIModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<LoggerManager>().As<ILoggerManager>().SingleInstance();
        }
    }
}

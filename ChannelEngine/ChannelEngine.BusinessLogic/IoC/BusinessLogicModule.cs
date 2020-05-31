using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Autofac;
using Module = Autofac.Module;

namespace ChannelEngine.BusinessLogic.IoC
{
    public class BusinessLogicModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var suffixesToRegister = new[] { "Service" };

            builder
                .RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => suffixesToRegister.Any(suffix => t.Name.EndsWith(suffix)))
                .AsImplementedInterfaces()
                .AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}

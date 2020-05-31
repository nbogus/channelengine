using System.Linq;
using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace ChannelEngine.Services.Ioc
{
    public class ServiceModule: Module
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

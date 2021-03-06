using System.Reflection;
using Abstractions.Auth;
using Autofac;
using AutoMapper;
using BLL.Auth;
using Module = Autofac.Module;

namespace BLL
{
    public class BllModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //configure all services
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //Configure AutoMapper
            builder.RegisterInstance(new MapperConfiguration(cfg => { cfg.AddMaps(Assembly.GetExecutingAssembly()); })
                .CreateMapper());

            // Auth
            builder.RegisterType<JwtAuthManager>()
                .As<IJwtAuthManager>()
                .SingleInstance();
        }
    }
}
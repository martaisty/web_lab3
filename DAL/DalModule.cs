using System.Reflection;
using Abstractions;
using Autofac;
using Module = Autofac.Module;

namespace DAL
{
    public class DalModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //register all repositories
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();
        }
    }
}
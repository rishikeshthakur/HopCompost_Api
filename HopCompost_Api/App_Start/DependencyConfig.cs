using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using HopCompost_DataAccess;
using HopCompost_DataAccess.Base;
using HopCompost_Service.Base;

namespace HopCompost_Api
{
    public class DependencyConfig
    {
        private static readonly Assembly ServiceAssembly = typeof(ServiceBase).Assembly;
        private static readonly Assembly MapperAssembly = typeof(MapperBase).Assembly;

        public static void Configure(ContainerBuilder builder)
        {
            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToArray();

            builder.RegisterType<HopCompost_DbEntities>().As<IDbContext>().InstancePerRequest();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(IRepository<>).Assembly).AsClosedTypesOf(typeof(IRepository<>)).InstancePerRequest();

            builder.RegisterAssemblyTypes(ServiceAssembly).Where(type => typeof(ServiceBase).IsAssignableFrom(type) && !type.IsAbstract).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(MapperAssembly).Where(type => typeof(MapperBase).IsAssignableFrom(type) && !type.IsAbstract).AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterApiControllers(assemblies);

            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
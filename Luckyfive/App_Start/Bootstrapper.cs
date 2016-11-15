using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Luckyfive.DataAccess.Infrastructure;
using Luckyfive.Service.Mappings;
using Luckyfive.Web.Controllers;

namespace Luckyfive.Web
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
            AutoMapperConfiguration.Configure();
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            builder.RegisterAssemblyTypes(Assembly.Load("Luckyfive.DataAccess"))
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(Assembly.Load("Luckyfive.Service"))
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof (AccountController).Assembly)
                .Where(t => t.Name.EndsWith("Controller"))
                .AsSelf().InstancePerLifetimeScope();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
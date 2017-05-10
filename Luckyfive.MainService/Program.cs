using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Luckyfive.DataAccess.Infrastructure;
using Luckyfive.DataAccess.Repositories;
using Luckyfive.Service;
using Luckyfive.Service.Abstraction;

namespace Luckyfive.MainService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {

            var builder = new ContainerBuilder();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<DbFactory>().As<IDbFactory>();
            builder.RegisterType<AvertismentRepository>().As<IAvertismentRepository>();
            builder.RegisterType<PhotoRepository>().As<IPhotoRepository>();
            builder.RegisterType<AdvertismentService>().As<IAdvertismentService>();
            builder.RegisterType<SeviceMain>();
            var container = builder.Build();


            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                container.Resolve<SeviceMain>()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}

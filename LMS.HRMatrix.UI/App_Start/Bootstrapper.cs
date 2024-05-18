using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMS.HRMatrix.Data.Repositories;
using LMS.HRMatrix.Mappings;
using LMS.HRMatrix.Service;
using Autofac;
using LMS.HRMatrix.Data.Infrastructure;
using System.Reflection;
using System.Web.Mvc;
using Autofac.Integration.Mvc;

namespace LMS.HRMatrix
{
    public class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
            AutoMapperConfiguration.Configure();
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(EmployeeRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            // Services
            builder.RegisterAssemblyTypes(typeof(EmployeeService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
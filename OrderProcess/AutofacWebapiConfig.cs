using Autofac;
using Autofac.Integration.WebApi;
using OrderProcess.Data.AdoNet;
using OrderProcess.Data.Interface;
using System.Reflection;
using System.Web.Http;
using OrderProcess.Data.EntityFramework;
using OrderProcess.Domain;

namespace OrderProcess
{
    public class AutofacWebapiConfig
    {

        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
           
            builder.RegisterType<AppConfigConnectionFactory>()
               .As<IConnectionFactory>().WithParameter("connectionName", "Logistics")
               .InstancePerLifetimeScope();

            builder.RegisterType<AdoNetContext>()
               .As<IAdoNetContext>()
               .InstancePerRequest();

            builder.RegisterType<ProductRepository>()
                .As<IProductRepository>()
                .InstancePerRequest();

            builder.RegisterType<ProductOnHandRepository>()
                .As<IProductOnHandRepository>()
                .InstancePerRequest();

            builder.RegisterType<AdminOrchestration>()
                .As<IAdminOrchestration>()
                .InstancePerRequest();

            builder.RegisterType<UserIdentityRepository>()
                .As<IEFUserIdentityRepository>()
                .InstancePerRequest();

            builder.RegisterType<TicketRepository>()
                .As<ITicketRepository>()
                .InstancePerRequest();

            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }

    }
}
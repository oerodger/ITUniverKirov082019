using Autofac;
using Autofac.Integration.Mvc;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Owin;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication1.App_Start;
using WebApplication1.Controllers;
using WebApplication1.DAL;
using WebApplication1.DAL.Repositories;

[assembly: OwinStartup(typeof(Startup))]
namespace WebApplication1.App_Start
{
    public partial class Startup
    {
        public static void Configuration(IAppBuilder app)
        { 
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var connectionString = ConfigurationManager.ConnectionStrings["MSSQL"];
            if (connectionString == null)
            {
                throw new Exception("Не найдена строка подключения");
            }

            var containerBuilder = new ContainerBuilder();
            containerBuilder.Register(x => { 
                var cfg = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012
                        .ConnectionString(connectionString.ConnectionString)
                        .Dialect<MsSql2012Dialect>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<User>())                    
                    .CurrentSessionContext("call");
                    var conf = cfg.BuildConfiguration();
                    var schemeExport = new SchemaUpdate(conf);
                    schemeExport.Execute(true, true);
                return cfg.BuildSessionFactory();
            }).As<ISessionFactory>().SingleInstance();
            containerBuilder
                .Register(x => x.Resolve<ISessionFactory>().OpenSession())
                .As<ISession>()
                .InstancePerRequest();
            containerBuilder.RegisterControllers(Assembly.GetAssembly(typeof(HomeController)));
            containerBuilder.RegisterModule(new AutofacWebTypesModule());
            containerBuilder.RegisterType<UserRepository>();
            var container = containerBuilder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            app.UseAutofacMiddleware(container);
        }
    }
}